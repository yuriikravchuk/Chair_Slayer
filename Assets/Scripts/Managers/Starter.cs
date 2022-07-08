using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private PlayerFacade _player;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private FireButton _fireButton;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WalletPresenter _walletPresenter;
    [SerializeField] private LevelPresenter _levelPresenter;

    //private BoostSpawner _boostController;
    private EnemiesManager _enemiesManager;
    private MapGeneratorsFacade _mapGenerator;


    private void Awake()
    {
        InitInput();

        Map map = GetMap();
        BreakingWall BreakingWall = Instantiate(MapConfig.WreckingWall);
        WallWrecker wallWrecker = _player.GetComponent<WallWrecker>();
        wallWrecker.Init(BreakingWall);

        _enemiesManager = new EnemiesManager();
        _enemySpawner = Instantiate(_enemySpawner);
        _enemySpawner.Init(_player, _player.transform, map.Rooms, _enemiesManager);

        _player.Init(_enemiesManager);
        var saveBinder = new SaveBinder(_levelPresenter, _walletPresenter);
        saveBinder.Bind();


        var gameStateMachine = new GameStateSwitcher(map, _enemySpawner, _player);
        new BraveStateMediator(gameStateMachine, _enemiesManager);
        new DefaultStateMediator(gameStateMachine, wallWrecker);
    }

    private Map GetMap()
    {
        _mapGenerator = new MapGeneratorsFacade();
        return _mapGenerator.Generate();
    }

    private void InitInput()
    {
        var inputMediator = new InputMediator(_joystick, _fireButton, _player);
        _joystick.Init(inputMediator);
    }
}
