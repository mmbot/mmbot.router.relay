﻿using System;
using MMBot.Router.Nancy;
using Owin;
using SignalR.Owin.Relay.Client;

namespace MMBot.Router.Relay
{
    public class RelayRouter : NancyRouter
    {
        private Robot _robot;
        private int _port;
        private bool _isConfigured;
        private string _hostname;
        private RelayClient _client;

        public override void Configure(Robot robot, int port)
        {
            _port = port;
            _robot = robot;
            _hostname = robot.GetConfigVariable("MMBOT_ROUTER_HOSTNAME");

            if (string.IsNullOrEmpty(_hostname))
            {
                throw new ArgumentException("The MMBOT_ROUTER_HOSTNAME configuration value is not supplied. Please check your mmbot.ini file");
            }
            _isConfigured = true;
        }

        public override void Start()
        {
            if (!_isConfigured)
            {
                throw new InvalidOperationException("The router has not yet been configured. You must call Configure before calling start");
            }
            var relayUri = string.Format("http://{0}:{1}/relay", _hostname, _port);
            try
            {
                _client = RelayClient.Create(app => app.UseNancy(options => options.Bootstrapper = new Bootstrapper(this)), relayUri);

                _client.Start();

                _robot.Logger.Info("The relay router is connected to " + relayUri);
            }
            catch (Exception e)
            {
                _robot.Logger.Error("Could not connect to relay router " + relayUri, e);
            }
        }

        public override void Stop()
        {
            _client.Stop();
        }
    }
}