# Progo — Full Game Architecture

## Player flow

Boot → Account → Login/Register → Profile → Main Menu → Lobby → Party/Invite Friends → Map Select → Ready → Match/World → Explore → Enter Vehicle → Drive → Rest Stops/Events → Results → Rewards → Lobby.

## Core systems

### Account
- Registration and login UI contracts
- Player profile
- Display name
- Progression, currency, owned vehicles
- Server-authoritative persistence
- Never store passwords in the game client

### Main menu
- Play
- Friends/party
- Garage
- Profile
- Settings
- News

### Lobby
- Public matchmaking
- Private lobby
- Invite friends
- Player list
- Ready state
- Host controls
- Map selection
- Maximum party size configurable by server

### Maps
1. Sunset Highway — starter desert highway
2. Red Canyon — canyon roads and tunnels
3. Salt Flats — open high-speed area
4. Ghost Town — abandoned settlement and side roads
5. Mountain Pass — later expansion map

Maps should be data-driven so new maps do not require rewriting multiplayer code.

### World gameplay
- First-person and third-person camera modes
- Walking
- Vehicle interaction
- Door animations
- Driver/passenger seats
- Vehicle physics
- Fuel
- Repair points
- Gas stations
- Motels/rest stops
- Dynamic weather
- Day/night
- AI traffic later
- Discoverable locations

### Multiplayer
Server authority for:
- player identity
- lobby membership
- ready state
- vehicle ownership
- vehicle transform/state
- important gameplay events
- rewards and progression

Client authority for:
- local camera
- input collection
- local UI
- presentation effects

Use interpolation for remote player and vehicle movement. Never trust client-supplied currency, rewards, or ownership changes.

### Data model
PlayerProfile:
- accountId
- displayName
- level
- experience
- currency
- ownedVehicleIds
- selectedVehicleId
- discoveredLocationIds
- settings

LobbyState:
- lobbyId
- hostId
- mapId
- players
- readyPlayers
- private/public
- matchState

VehicleState:
- networkId
- ownerPlayerId
- vehicleDefinitionId
- position
- rotation
- velocity
- fuel
- damage
- occupants

## Backend boundaries

The client should communicate with backend services through authenticated APIs. A dedicated multiplayer game server owns live world state. A persistent account service owns profiles and progression. A lobby/matchmaking service creates and assigns sessions.

Recommended production stack:
- Unity client
- Dedicated authoritative game server
- HTTPS API for account/profile operations
- Database for persistent profiles
- Matchmaking/lobby service
- Optional relay/NAT traversal layer

## Security

Authentication credentials must be handled by the backend/auth provider, not by Unity PlayerPrefs or local files. The client is untrusted. Validate every economy, inventory, progression, and matchmaking action server-side.

## Development milestones

1. Offline vertical slice
2. Account/profile API contract
3. Main menu + lobby UI
4. Dedicated multiplayer prototype
5. Vehicle networking
6. First complete desert map
7. Persistence and progression
8. Friends/invites
9. Content pipeline for additional maps/cars
10. Production hardening, telemetry, moderation, anti-cheat, deployment
