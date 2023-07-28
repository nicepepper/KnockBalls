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
        [SerializeField] private GameObject _uiGameOver;
        [SerializeField] private GameObject _uiRecords;
        [SerializeField] private GameObject _uiCredits;
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnQuit;
        
        private void Awake()
        {
            GameEvent.OnChangedStage += OnChangedGameStage;
            _btnStart.onClick.AddListener(GameController.StartGame);
            _btnQuit.onClick.AddListener(GameController.QuitGame);
        }

        private void OnDestroy()
        {
            GameEvent.OnChangedStage -= OnChangedGameStage;
        }

        public void ToMainMenu()
        {
            DeactivateAllUI();
            _uiMainMenu.SetActive(true);
        }

        public void CloseSavePanel()
        {
            _uiMainMenu.SetActive(true);
        }
        
        public void ToRecords()
        {
            DeactivateAllUI();
            _uiRecords.SetActive(true);
        }
        
        public void ToCredits()
        {
            DeactivateAllUI();
            _uiCredits.SetActive(true);
        }

        private void OnChangedGameStage()
        {
            Debug.Log(GameEvent.Current);
            var state = GameEvent.Current;
            _uiMainMenu.SetActive(state == GameStage.PREPARE);
            _uiGameplay.SetActive(state == GameStage.START);
            _uiGameOver.SetActive(state == GameStage.END);
        }

        private void DeactivateAllUI()
        {
            _uiMainMenu.SetActive(false);
            _uiGameplay.SetActive(false);
            _uiGameOver.SetActive(false);
            _uiRecords.SetActive(false);
            _uiCredits.SetActive(false);
        }
    }
}


