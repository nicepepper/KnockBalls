using System;
using CustomGameEvent;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _uiMainMenu;
        [SerializeField] private GameObject _uiGameplay;
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnQuit;
        [SerializeField] private Button _btnToMenu;

        private void Awake()
        {
            GameEvent.OnChangedStage += OnChangedGameStage;
            _btnStart.onClick.AddListener(GameController.StartGame);
            _btnQuit.onClick.AddListener(GameController.QuitGame);
            _btnToMenu.onClick.AddListener(GameController.PreapareGame);
        }

        private void OnDestroy()
        {
            GameEvent.OnChangedStage -= OnChangedGameStage;
        }

        private void OnChangedGameStage()
        {
            Debug.Log(GameEvent.Current);
            var state = GameEvent.Current;
            _uiMainMenu.SetActive(state == GameStage.PREPARE);
            _uiGameplay.SetActive(state == GameStage.START);
        }
    }
}


