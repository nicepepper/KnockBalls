using System;
using System.Collections;
using System.Collections.Generic;
using CustomGameEvent;
using Enemy;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Game
{
    public class QuickGame : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private AudioSource _menuSound;
        [SerializeField] private AudioSource _battlefieldSound;
        [Header("Amount of enemies to Game Over")] [SerializeField]
        private int _livingEnemies = 10;
        
        private EnemyCollection _enemies = new EnemyCollection();
        private int _killCount = 0;
        
        private void Awake()
        {
            GameEvent.OnEnemyKilled.AddListener(() =>
            {
                _killCount++;
            });
            GameEvent.OnPrepare += OnGamePrepare;
            GameEvent.OnStart += OnGameStart;
            //GameEvent.OnEnd += OnEndGame;
            GameEvent.OnQuit += OnGameQuit;
        }

        private void OnDestroy()
        {
            GameEvent.OnPrepare -= OnGamePrepare;
            GameEvent.OnStart -= OnGameStart;
            //GameEvent.OnEnd -= OnEndGame;
            GameEvent.OnQuit -= OnGameQuit;
        }

        private void Update()
        {
            CheckGameOver();
            _enemies.GameUpdate();
            Physics.SyncTransforms();
        }

        private void OnGamePrepare()
        {
            _menuSound.Play();
            _battlefieldSound.Stop();
            _enemySpawner.StopAllCoroutines();
            _enemies.DestroyEnemies();
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnGameStart()
        {
            _menuSound.Stop();
            _battlefieldSound.Play();
            _enemySpawner.SpawnEnemy(_enemies);
            Cursor.lockState = CursorLockMode.Confined;
            _killCount = 0;
        }

        private void OnEndGame()
        {
            
        }

        private void OnGameQuit()
        {
            Application.Quit();
        }
        
        private void CheckGameOver()
        {
            if (_enemies.Count() == _livingEnemies)
            {
                OnGamePrepare();
                GameEvent.Current = GameStage.END;
                GameEvent.SendGameOver(_killCount);
            }
        }
    }
}
