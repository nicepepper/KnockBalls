using System;
using System.Collections;
using System.Collections.Generic;
using CustomGameEvent;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        
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

        private void OnGamePaused()
        {
            
        }
    }

}
