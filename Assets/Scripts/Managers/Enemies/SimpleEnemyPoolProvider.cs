using enemy;

public class SimpleEnemyPoolProvider : ISimpleEnemyProvider
{
    public SimpleEnemy GetSimpleEnemy(int enemyType) 
        => PoolsContainer.Get(enemyType).GetComponent<SimpleEnemy>();
}
