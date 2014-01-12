# mmbot.router.relay

This project implements a router for [mmbot](https://github.com/mmbot/mmbot) that uses a publicly hosted SignalR web site as a relay for web hooks etc rather than run mmbot on the internets.


## Installation
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