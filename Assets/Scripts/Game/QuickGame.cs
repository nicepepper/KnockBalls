using CustomGameEvent;
using Enemy;
using UnityEngine;

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
        private PlayerData _playerData = new PlayerData();
        
        private void Awake()
        {
            GameEvent.OnEnemyKilled.AddListener(() =>
            {
                _killCount++;
            });
            GameEvent.OnPrepare += OnGamePrepare;
            GameEvent.OnStart += OnGameStart;
            GameEvent.OnQuit += OnGameQuit;
        }
        
        private void OnDestroy()
        {
            GameEvent.OnPrepare -= OnGamePrepare;
            GameEvent.OnStart -= OnGameStart;
            GameEvent.OnQuit -= OnGameQuit;
        }
        
        private void Start()
        {
            PlayerData.Current = _playerData;
            SaveLoad.Load();
            //SaveLoad.DeleteSave();
        }

        private void Update()
        {
            if (!CheckGameOver())
            {
                _enemies.GameUpdate();
                Physics.SyncTransforms();
            }
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
        
        private void OnGameQuit()
        {
            Application.Quit();
        }
        
        private bool CheckGameOver()
        {
            if (_enemies.Count() == _livingEnemies)
            {
                _playerData.Score = _killCount;
                GameEvent.SendGameOver(_killCount);
                OnGamePrepare();
                GameEvent.Current = GameStage.END;
                return true;
            }
            return false;
        }
    }
}
