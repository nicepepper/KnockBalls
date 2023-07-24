using UnityEngine;

namespace CustomGameEvent
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            PreapareGame();
        }

        public static void PreapareGame()
        {
            GameEvent.Current = GameStage.PREPARE;
        }

        public static void StartGame()
        {
            GameEvent.Current = GameStage.START;
        }

        public static void StopGame()
        {
            GameEvent.Current = GameStage.STOP;
        }

        public static void EndGame()
        {
            GameEvent.Current = GameStage.END;
        }

        public static void QuitGame()
        {
            GameEvent.Current = GameStage.QUIT;
        }
    }
}
