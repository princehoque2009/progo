using System;
using System.Collections.Generic;

namespace Progo.Game
{
    [Serializable]
    public sealed class LobbyPlayer
    {
        public string PlayerId;
        public string DisplayName;
        public bool Ready;
    }

    [Serializable]
    public sealed class LobbyState
    {
        public string LobbyId;
        public string HostId;
        public string MapId;
        public bool IsPrivate;
        public List<LobbyPlayer> Players = new();
        public int MaxPlayers = 8;

        public bool CanStart()
        {
            if (Players.Count == 0 || string.IsNullOrWhiteSpace(MapId)) return false;
            foreach (var player in Players)
                if (!player.Ready) return false;
            return true;
        }
    }
}
