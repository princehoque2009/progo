# Progo

A standalone multiplayer 3D desert road-trip game prototype.

## Direction

- First-person player POV
- Walk around the world
- Enter and exit cars
- Animated vehicle doors
- Driver and passenger seats
- Drivable vehicles
- Multiplayer-ready architecture
- Desert highway environment

## Prototype architecture

This repository starts with engine-agnostic game architecture and Unity-ready C# gameplay scripts. Art, scenes, networking transport, and platform-specific configuration can be added incrementally.

## Controls (prototype)

- WASD — move / drive
- Mouse — look
- E — interact / enter vehicle
- F — exit vehicle
- Shift — sprint

## Development

The first milestone is the vehicle interaction loop: approach car → open door → enter seat → switch to interior POV → drive → exit.
