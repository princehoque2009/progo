# Progo

A standalone browser-playable 3D desert road-trip prototype, with a Unity-oriented architecture for the larger multiplayer game.

## Play in a browser

The repository now has a **root `index.html`**, so Vercel and Netlify can deploy the project from the repository root without setting `web/` as the root directory.

### Vercel

- Import `princehoque2009/progo`.
- Framework preset: **Other** / static.
- Build command: empty.
- Output directory: `.`.
- Deploy the `main` branch.

### Netlify

- Import the GitHub repository.
- Build command: empty.
- Publish directory: `.`.

## Browser controls

- Enter your driver name and click **START DRIVING**.
- Click the game window to lock the mouse.
- `WASD` / arrow keys — walk and drive.
- Mouse — look around.
- `E` — enter / exit the car when close.
- `ESC` — release the mouse / return toward the menu.

## Current browser prototype

- First-person 3D camera
- Procedural desert ground and highway
- Road markings and desert props
- Driveable prototype vehicle
- Vehicle entry / exit loop
- Basic speed HUD
- Browser-only static deployment

The current browser build is a **single-player prototype**. True account authentication, persistent profiles, friends, lobbies, matchmaking, and authoritative multiplayer require a backend and multiplayer server; those systems are documented in `docs/GAME_ARCHITECTURE.md` and remain separate from this static preview.
