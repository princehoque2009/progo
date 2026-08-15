using UnityEngine;

namespace Progo.Game
{
    public sealed class ProgoGameManager : MonoBehaviour
    {
        public static ProgoGameManager Instance { get; private set; }

        [SerializeField] private bool pauseWithEscape = true;
        public bool IsPaused { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (pauseWithEscape && Input.GetKeyDown(KeyCode.Escape))
                SetPaused(!IsPaused);
        }

        public void SetPaused(bool paused)
        {
            IsPaused = paused;
            Time.timeScale = paused ? 0f : 1f;
            Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
