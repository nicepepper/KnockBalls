using CustomGameEvent;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RemainingEnemyText : MonoBehaviour
    {
        private Text _text;
        private void Awake()
        {
            _text = gameObject.GetComponent<Text>();
            GameEvent.OnEnemyCreated.AddListener(EnemyRemaining);
            GameEvent.OnGameOver.AddListener(Clear);
        }

        private void EnemyRemaining(int remaining)
        {
            _text.text = "Enemy: " + remaining;
        }

        private void Clear(int killCount)
        {
            _text.text = "Enemy: 0" ;
        }
    }
}
