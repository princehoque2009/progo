using System.Collections.Generic;

namespace Progo.Game
{
    public static class MapCatalog
    {
        public static readonly IReadOnlyList<MapDefinition> All = new[]
        {
            new MapDefinition
            {
                Id = "sunset-highway",
                DisplayName = "Sunset Highway",
                SceneName = "Worlds/SunsetHighway",
                MaxPlayers = 8
            },
            new MapDefinition
            {
                Id = "red-canyon",
                DisplayName = "Red Canyon",
                SceneName = "Worlds/RedCanyon",
                MaxPlayers = 8
            },
            new MapDefinition
            {
                Id = "salt-flats",
                DisplayName = "Salt Flats",
                SceneName = "Worlds/SaltFlats",
                MaxPlayers = 8
            },
            new MapDefinition
            {
                Id = "ghost-town",
                DisplayName = "Ghost Town",
                SceneName = "Worlds/GhostTown",
                MaxPlayers = 8
            }
        };
    }
}
