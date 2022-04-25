using UnityEngine;
using UnityEngine.UI;
namespace enemy
{
    public class Enemy : MonoBehaviour
    {
        public Image UIHP;
        [SerializeField] protected float maxHealth;
        protected float health;
        [SerializeField] protected float speed;
        protected Character character;
        [SerializeField] protected float atackSpeed;
        [SerializeField] protected float lastAtackTime;
        [SerializeField] protected float maxAtackDistance;
        public Transform center;
        public float Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                UIHP.fillAmount = value / maxHealth;
                if (health <= 0)
                {
                    BoostController.instance.SpawnBoost(transform);
                    EnemiesManager.instance.RemoveFromList(this);
                }
            }
        }
    }
}

