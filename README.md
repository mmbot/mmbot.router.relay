# mmbot.router.relay

This project implements a router for [mmbot](https://github.com/mmbot/mmbot) that uses a [publicly hosted SignalR web site](https://github.com/petegoo/SignalR.Owin.Relay) as a relay for web hooks etc rather than run mmbot on the internets.


## Installation
* Install the SignalR website from [SignalR.Owin.Relay](https://github.com/petegoo/SignalR.Owin.Relay).
* From your mmbot working directory run 

```
nuget install mmbot.router.relay -o packages

```
* In your mmbot.ini file add the following section

```
[ROUTER]
HOSTNAME = myhostname.whatever.com
ENABLED = true
PORT = 8080
NAME = RelayRouter

```