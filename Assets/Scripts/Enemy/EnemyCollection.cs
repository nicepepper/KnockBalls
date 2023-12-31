using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyCollection
    {
        private List<Enemy> _enemies = new List<Enemy>();

        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public int Count()
        {
            return _enemies.Count;
        }

        public void GameUpdate()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (!_enemies[i].GameUpdate())
                {
                    int lastIndex = _enemies.Count - 1;
                    _enemies[i] = _enemies[lastIndex];
                    _enemies.RemoveAt(lastIndex);
                    i -= 1;
                }
            }
        }

        public void DestroyEnemies()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].GameUpdate())
                {
                    _enemies[i].OriginFactory.Reclaim(_enemies[i]);
                }
            }
            _enemies.Clear();
        }
    }
}