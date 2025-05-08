# TCP Chat Messenger (C# Console Application)

A simple terminal-based TCP messenger built in C# using SuperSimpleTcp.  
The server accepts multiple clients simultaneously, receives their messages, and broadcasts them to all connected participants. Ideal for learning TCP/IP communication, socket programming, and handling multiple client connections.

## Features

- TCP-based server with multi-client support
- Clients send messages to the server
- Server broadcasts incoming messages to all connected clients
- Clean and structured C# code using SuperSimpleTcp
- 100% console-based – no GUI

## Requirements

- .NET 6 or later
- `SuperSimpleTcp` NuGet package

## Getting Started

1. Start the server (`TcpServer`)
2. Launch one or more clients (`TcpClient`)
3. Type messages in the terminal and chat over LAN

## Notes

- Currently no encryption (plain TCP)
- Easily extendable: add a GUI, usernames, logging, or TLS support (e.g. using WatsonTcp)
