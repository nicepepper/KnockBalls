using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] public Text PlayerPosition;
        [SerializeField] public Text PlayerName;
        [SerializeField] public Text PlayerScore;
    
        public void SetPlayer(int position, PlayerData playerData)
        {
            this.PlayerPosition.text = position.ToString();
            this.PlayerName.text = playerData.Name;
            this.PlayerScore.text = playerData.Score.ToString();
        }
    }
}
