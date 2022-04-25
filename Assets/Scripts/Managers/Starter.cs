using UnityEngine;

public class Starter : MonoBehaviour
{
    private BoostSpawner _boostController;
    private EnemiesManager _enemiesManager;
    private MapGeneratorsFacade _mapGenerator;

    [SerializeField] private PlayerFacade _player;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private FireButton _fireButton;
    [SerializeField] private Room _startRoom;
    [SerializeField] private Camera _mainCamera;
    private void Awake()
    {
        InitManagers();
        _player.Init();
        var inputMediator = new InputMediator(_joystick, _fireButton, _player);
        _joystick.Init(inputMediator);

        Map map = GetMap();
        Breaker breaker = _player.GetComponent<Breaker>();
        //var roomsUnlocker = new RoomsUnlocker(map, breaker);
        var enemySpawner = new EnemySpawner(_player, _player.transform, map.Rooms);

    }

    private void InitManagers()
    {
        //_boostController = new BoostSpawner();
        _enemiesManager = Singleton<EnemiesManager>.instance;
        _enemiesManager.Init(_mainCamera);
    }

    private Map GetMap()
    {
        _mapGenerator = new MapGeneratorsFacade(_startRoom);
        return _mapGenerator.Generate();
    }
}
