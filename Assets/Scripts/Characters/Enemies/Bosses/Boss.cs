namespace enemy
{
    [System.Serializable]
    public class Boss : Enemy
    {
        public int Level { get; protected set; }
        protected override void OnDie() => Destroy(gameObject);

        public override void Enter()
        {
            
        }
    }
}