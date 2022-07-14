namespace enemy
{
    [System.Serializable]
    public class Boss : Enemy
    {
        public int Level;
        protected override void OnEnter()
        {

        }

        protected override void OnDie()
        {
            Destroy(gameObject);
        }


    }
}