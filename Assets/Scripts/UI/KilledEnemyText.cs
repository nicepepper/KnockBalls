using CustomGameEvent;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KilledEnemyText : MonoBehaviour
    {
        private int _killed = 0;
        private Text _text;

        private void Awake()
        {
            _text = gameObject.GetComponent<Text>();
            GameEvent.OnEnemyKilled.AddListener(EnemyKilled);
            GameEvent.OnGameOver.AddListener(Clear);
        }

        private void EnemyKilled()
        {
            _killed++;
            _text.text = "Killed: " + _killed;
        }

        private void Clear(int killCount)
        {
            _killed = 0;
            _text.text = "Killed: " + _killed;
        }
    }
}
