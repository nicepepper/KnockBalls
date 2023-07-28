using UnityEngine;

namespace Enemy
{
    public abstract class EnemyView : MonoBehaviour
    {
        public bool IsIninted { get; protected set; }
        
        protected Animator _animator;
        protected Enemy _enemy;

        protected const string DIED_KEY = "Died";

        public virtual void Init(Enemy enemy)
        {
            _animator = GetComponent<Animator>();
            _enemy = enemy;
        }

        public virtual void Die()
        {
            _animator.SetBool(DIED_KEY, true);
        }
    }
}
