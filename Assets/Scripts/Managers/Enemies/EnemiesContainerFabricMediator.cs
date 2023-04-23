namespace enemy
{
    public class EnemiesContainerFabricMediator
    {
        public EnemiesContainerFabricMediator(EnemiesContainer container, EnemiesFactory fabric)
        {
            fabric.Spawned += container.Add;
            fabric.Died += container.Remove;
        }
    }
}