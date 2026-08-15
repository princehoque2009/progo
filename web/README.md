# Progo Web Prototype

This is a browser-playable prototype that can be deployed as a static site on Vercel or Netlify.

## Run locally

From the `web` directory, use any static server, for example:

```bash
npx serve .
```

Then open the displayed local URL.

## Deploy

For Vercel or Netlify, set the project/root directory to `web` and use a static deployment. No build command is required.

## Controls

- Enter a display name and press PLAY
- Click/lock the mouse for first-person view
- WASD / arrow keys: walk or drive
- E: enter/exit the car when close
- ESC: return toward the menu

## Important

This is the first browser-playable vertical slice. It is not yet true multiplayer and it does not implement production account authentication. Those require a backend/auth service and an authoritative multiplayer server. The web version is intentionally separated from the Unity-oriented architecture so it can be previewed immediately on Vercel/Netlify.
