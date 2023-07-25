using System;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "KnockBalls/EnemyFactory")]
    public class EnemyFactory : GameObjectFactory
    {
        [Serializable]
        class EnemyConfig
        {
            public Enemy Prefab;
            [FloatRangeSlider(0f, 5f)]
            public FloatRange Speed = new FloatRange(1f);
            [FloatRangeSlider(10f, 100f)]
            public FloatRange Health = new FloatRange(20);
        }

        [SerializeField] 
        private EnemyConfig _red, _purple;

        public Enemy Get(EnemyType type)
        {
            var config = GetConfig(type);
            Enemy instance = CreateGameObjectInstance(config.Prefab);
            instance.Initialize(config.Speed.RandomValueInRange, config.Health.RandomValueInRange);
            instance.OriginFactory = this;
            return instance;
        }

        private EnemyConfig GetConfig(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.RED:
                    return _red;
                case EnemyType.PURPLE:
                    return _purple;
            }
            Debug.LogError($"NO config for {type}");
            return _red;
        }

        public void Reclaim(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }
    }
}