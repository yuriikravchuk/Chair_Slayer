using UnityEngine;
using enemy;
using System;

public class EnemySpawner : UnityEngine.Object
{
    public bool SpawnActive = true;

    private readonly int[] _spawnChance = { 90, 101 };
    private IDamageable _player;
    private Transform _target;
    private Room[,] _rooms;

    private int _spawnSpeed = 7;
    private float _lastSpawnTime;
    private bool _spawnActive;

    private float _maxX, _maxY;

    public EnemySpawner(IDamageable player, Transform target, Room[,] rooms)
    {
        _player = player;
        _target = target;
        _rooms = rooms;
        _maxX = _rooms.GetLength(0);
        _maxY = _rooms.GetLength(1);
        _lastSpawnTime = Time.time;
    }

    private SimpleEnemy GetEnemy()
    {
        int random = UnityEngine.Random.Range(1, 100);
        for (int i = 0; i < _spawnChance.Length; i++)
        {
            if (random <= _spawnChance[i])
            {
                SimpleEnemy enemy = PoolManager.Get(i + 1).GetComponent<SimpleEnemy>();
                enemy.Init(_player, _target);
                return enemy;
            }
        }
        throw new InvalidOperationException();
    }

    public void TrySpawnEnemies()
    {
        if (SpawnActive && Time.time > _lastSpawnTime + _spawnSpeed)
        {
            SpawnEnemies();
            //_door.SetBool("open", true);
            //StartCoroutine(WaitUntilEnemyEntryRoom(position, enemy));
        }
    }

    private void SpawnEnemies()
    {
        for (int x = 0; x < _maxX; x++)
        {
            for (int y = 0; y < _maxY; y++)
            {
                if (_rooms[x, y].Active == true)
                    SpawnEnemiesInRoom(_rooms[x, y].walls);
            }
        }
    }

    private void SpawnEnemiesInRoom(Wall[] walls)
    {
        for (int i = 0; i < walls.Length; i++)
        {
            if (walls?[i].gameObject.activeSelf == true)
                SpawnEnemy(walls[i].SpawnPosition, walls[i].SpawnRotation);
        }
    }

    private SimpleEnemy SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        SimpleEnemy enemy = GetEnemy();
        enemy.transform.position = position;
        enemy.transform.rotation = rotation;
        return enemy;
    }
}
