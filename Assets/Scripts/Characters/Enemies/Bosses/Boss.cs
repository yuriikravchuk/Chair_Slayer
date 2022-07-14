namespace enemy
{
    [System.Serializable]
    public class Boss : Enemy
    {
        protected override void OnDie()
        {
            Destroy(gameObject);
        }

        protected override void OnEnter()
        {
            
        }
    }
}