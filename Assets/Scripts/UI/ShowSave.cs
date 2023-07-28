using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using CustomGameEvent;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowSave : MonoBehaviour
    {
        [SerializeField] private Transform _playerInfoParent;
        [SerializeField] private GameObject _playerInfoPrefab;
        [SerializeField] private Button _saveBth;
        [SerializeField] private InputField _NameInputField;
        [SerializeField] private Text _scoreText;
        
        private int _score = 0;
        private List<GameObject> _allPrefabs = new List<GameObject>();
        
        private void Update()
        {
            if (PlayerData.Current.Score != _score)
            {
                _score = PlayerData.Current.Score;
                _scoreText.text = _score.ToString();
            }
        }
        
        public void ShowRating()
        {
            for (int i = 0; i < SaveLoad.SavePlayersData.Count; i++)
            {
                SpawnPlayerInfoPrefab(1 + i, SaveLoad.SavePlayersData[i]);
            }
        }

        public void ClearRating()
        {
            for (int i = 0; i < _allPrefabs.Count; i++)
            {
                Destroy(_allPrefabs[i].gameObject);
            }
            _allPrefabs.Clear();
        }
        
        public void SavePlayerResult()
        {
            PlayerData.Current.Name = _NameInputField.text;
            SaveLoad.Save();
            GameEvent.Current = GameStage.PREPARE;
        }

        public void CloseSavePnt()
        {
            GameEvent.Current = GameStage.PREPARE;
        }

        public void SetName(string name)
        {
            _saveBth.interactable = string.IsNullOrEmpty(name) ? false : true;
        }
        
        private void SpawnPlayerInfoPrefab(int position, PlayerData playerData)
        {
            GameObject newPlayerInfo = Instantiate(_playerInfoPrefab, _playerInfoParent);
            _allPrefabs.Add(newPlayerInfo);
            newPlayerInfo.GetComponent<PlayerInfo>().SetPlayer(position, playerData);
        }
    }
}
