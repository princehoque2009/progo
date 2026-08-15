namespace Progo.Game
{
    public enum NetworkAuthority
    {
        Server,
        ClientPresentation
    }

    public static class NetworkRules
    {
        // Server-owned: identity, lobby membership, ready state, vehicle state,
        // rewards, progression, inventory and economy.
        // Client-owned: input, camera, local UI and presentation effects.
        public static bool IsServerOwned(string stateName)
        {
            return stateName is "identity" or "lobby" or "ready" or "vehicle" or
                "rewards" or "progression" or "inventory" or "economy";
        }
    }
}
