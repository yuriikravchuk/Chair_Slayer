using UnityEngine;
using UnityEngine.UI;
using playerStateMachine;

public class Starter : MonoBehaviour
{
    [SerializeField] private PlayerFacade _player;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private FireButton _fireButton;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WalletPresenter _walletPresenter;
    [SerializeField] private LevelPresenter _levelPresenter;
    [SerializeField] private Button pause;
    [SerializeField] private Button resume;

    //private BoostSpawner _boostController;
    private EnemiesManager _enemiesManager;
    private MapGeneratorsFacade _mapGenerator;


    private void Awake()
    {
        Map map = GetMap();
        _enemiesManager = new EnemiesManager();
        _enemySpawner = Instantiate(_enemySpawner);
        _enemySpawner.Init(_player, _player.transform, map.Rooms, _enemiesManager);

        _player.Init(_enemiesManager);
        var playerStateMachine = new PlayerStateMachine(_playerView, _player);
        var inputMediator = new InputMediator(_joystick, _fireButton, playerStateMachine);
        _joystick.Init(inputMediator);

        BreakingWall BreakingWall = Instantiate(MapConfig.WreckingWall);
        WallWrecker wallWrecker = _player.GetComponent<WallWrecker>();
        wallWrecker.Init(BreakingWall, playerStateMachine);

        var saveBinder = new SaveBinder(_levelPresenter, _walletPresenter);
        saveBinder.Bind();

        var gameStateMachine = new GameStateSwitcher(map, _enemySpawner, playerStateMachine);
        new BraveStateMediator(gameStateMachine, _enemiesManager);
        new DefaultStateMediator(gameStateMachine, wallWrecker);
        new PauseStateMediator(gameStateMachine, pause, resume);
        new BossStateMediator(gameStateMachine, wallWrecker);
    }

    private Map GetMap()
    {
        _mapGenerator = new MapGeneratorsFacade();
        return _mapGenerator.Generate();
    }

}
