using System;
using System.Collections;
using System.Collections.Generic;
using CustomGameEvent;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class QuickGame : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        private EnemyCollection _enemies = new EnemyCollection();
        [SerializeField] private AudioSource _menuSound;
        [SerializeField] private AudioSource _battlefield;

        private void Awake()
        {
            GameEvent.OnPrepare += OnGamePrepare;
            GameEvent.OnStart += OnGameStart;
            GameEvent.OnQuit += OnGameQuit;
            GameEvent.OnChangedStage += OnChangedGameStage;
        }

        private void OnDestroy()
        {
            GameEvent.OnPrepare -= OnGamePrepare;
            GameEvent.OnStart -= OnGameStart;
            GameEvent.OnQuit -= OnGameQuit;
            GameEvent.OnChangedStage -= OnChangedGameStage;
        }

        private void Update()
        {
            _enemies.GameUpdate();
            Physics.SyncTransforms();
        }

        private void OnGamePrepare()
        {
            _menuSound.Play();
            _battlefield.Stop();
            _enemySpawner.StopAllCoroutines();
            _enemies.DestroyEnemies();
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnGameStart()
        {
            _menuSound.Stop();
            _battlefield.Play();
            _enemySpawner.SpawnEnemy(_enemies);
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void OnGameQuit()
        {
            Application.Quit();
        }

        private void OnChangedGameStage()
        {
            
        }
    }
}
