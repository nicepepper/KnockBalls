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
        [SerializeField] private EnemyFactory _enemyFactory;
        private EnemyCollection _enemies = new EnemyCollection();
        
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
            SpawnEnemy();
            _enemies.GameUpdate();
            Physics.SyncTransforms();
        }

        private void SpawnEnemy()
        {
            Enemy.Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, 2));
            _enemies.Add(enemy);
        }

        private void OnGamePrepare()
        {
            
        }

        private void OnGameStart()
        {
            
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
