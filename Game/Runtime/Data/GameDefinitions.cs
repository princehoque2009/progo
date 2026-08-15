using System;
using System.Collections.Generic;

namespace Progo.Game
{
    [Serializable]
    public sealed class VehicleDefinition
    {
        public string Id;
        public string DisplayName;
        public float Mass = 1400f;
        public float MaxSpeed = 42f;
        public float Acceleration = 12f;
    }

    [Serializable]
    public sealed class MapDefinition
    {
        public string Id;
        public string DisplayName;
        public string SceneName;
        public int MaxPlayers = 8;
    }

    [Serializable]
    public sealed class PlayerProfile
    {
        public string AccountId;
        public string DisplayName;
        public int Level = 1;
        public int Experience;
        public int Currency;
        public string SelectedVehicleId;
        public List<string> OwnedVehicleIds = new();
        public List<string> DiscoveredLocationIds = new();
    }
}
