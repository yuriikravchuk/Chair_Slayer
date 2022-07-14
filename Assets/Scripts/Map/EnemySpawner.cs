using UnityEngine;
using enemy;
using System;

public class EnemySpawner : MonoBehaviour
{
    public bool SpawnActive = true;

    private IDamageable _player;
    private Transform _target;
    private Room[,] _rooms;
    private EnemiesManager _enemiesHandler;
    private readonly int[] _spawnChance = { 101, 102 };
    private readonly int _spawnSpeed = 7;
    private float _maxX, _maxY;
    private float _lastSpawnTime;

    private void Update()
    {
        TrySpawnEnemies();
        //SDebug.Log(_enemiesHandler._enemies.ToList().Count);
    }

    public void Init(IDamageable player, Transform target, Room[,] rooms, EnemiesManager enemiesHandler)
    {
        _player = player;
        _target = target;
        _rooms = rooms;
        _maxX = _rooms.GetLength(0);
        _maxY = _rooms.GetLength(1);
        _enemiesHandler = enemiesHandler;
    }

    public void TrySpawnEnemies()
    {
        if (SpawnActive && Time.time > _lastSpawnTime + _spawnSpeed)
        {
            _lastSpawnTime = Time.time;
            SpawnEnemies();
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

    private void SpawnEnemiesInRoom(Wall[] wallls)
    {
        for (int i = 0; i < wallls.Length; i++)
        {
            if (wallls[i] != null && wallls[i].gameObject.activeSelf && !wallls[i].HasRoomInBack)
            {
                SimpleEnemy enemy = GetEnemy();
                wallls[i].EnemySpawner.Spawn(enemy);
            }
        }
    }

    private SimpleEnemy GetEnemy()
    {
        int random = UnityEngine.Random.Range(1, 100);
        for (int i = 1; i <= _spawnChance.Length; i++)
        {
            if (random <= _spawnChance[i])
            {
                SimpleEnemy enemy = PoolManager.Get(i).GetComponent<SimpleEnemy>();
                enemy.Init(_player, _target, _enemiesHandler);
                return enemy;
            }
        }
        throw new InvalidOperationException();
    }
}
