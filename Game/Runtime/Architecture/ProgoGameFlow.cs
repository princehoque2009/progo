using System;

namespace Progo.Game
{
    public enum GameScreen
    {
        Boot,
        Authentication,
        Profile,
        MainMenu,
        Lobby,
        MapSelect,
        Loading,
        World,
        Results
    }

    public enum MatchState
    {
        Waiting,
        Ready,
        Loading,
        InProgress,
        Finished
    }

    public sealed class ProgoGameFlow
    {
        public GameScreen Screen { get; private set; } = GameScreen.Boot;
        public MatchState Match { get; private set; } = MatchState.Waiting;

        public event Action<GameScreen> ScreenChanged;
        public event Action<MatchState> MatchChanged;

        public void GoTo(GameScreen screen)
        {
            Screen = screen;
            ScreenChanged?.Invoke(screen);
        }

        public void SetMatchState(MatchState state)
        {
            Match = state;
            MatchChanged?.Invoke(state);
        }
    }
}
