# Frameworks
.NET 8 - The beauty of Entity Framework

(.NET 9 is not Backward Compatible)

Ele cruza o código com a Telemetria.

Scenario: 

1. A truck sends a high temperature DTC
2. Backend will automatically check if de colling liquid is low
3.Is the truck going up a mountain?

History: 

If a vehicle sends the same DTC on and off and on and off, the algorythm can predict that it will fail in the next 500 kilometers

A single if statement could be what prevents a 40-ton truck from losing its brakes.

In a given brand-agnostic Platform, does one use a Factory pattern in the Backend to handle the specificities of each CAN-bus protocol, or is there a normalization layer that handles this before it reaches the core services?
