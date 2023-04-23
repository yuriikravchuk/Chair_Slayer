using enemy;
using player;
using UnityEngine;
using map;

public class Starter : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine _playerStateMachine;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private WallWrecker wallWrecker;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private FireButton _fireButton;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WalletPresenter _walletPresenter;
    [SerializeField] private LevelPresenter _levelPresenter;

    private const int PLAYEER_HEALTH = 100;

    private void Awake()
    {
        Map map = GetMap();
        map.StartRoom.Activate();

        var saveBinder = new SaveBinder(_levelPresenter, _walletPresenter);
        saveBinder.Bind();

        
        ISimpleEnemyProvider enemyProvider = new SimpleEnemyPoolProvider();
        IBossProvider bossProvider = ScriptableObject.CreateInstance<BossConfig>();

        var enemiesContainer = new EnemiesContainer();
        var enemiesFabric = new EnemiesFactory(enemyProvider, bossProvider);
        new EnemiesContainerFabricMediator(enemiesContainer, enemiesFabric);

        _playerStateMachine.Init(_playerView);
        var player = new Player(PLAYEER_HEALTH, _playerStateMachine.GetStartState());
        _playerView.Init(player, enemiesContainer, map.StartPosition);
        new PlayerStateMediator(player, _playerStateMachine);

        _enemySpawner = Instantiate(_enemySpawner);
        _enemySpawner.Init(player, _playerView.transform, map.Rooms, enemiesFabric);

        BreakingWall breakingWall = Instantiate(MapConfig.WreckingWall);
        wallWrecker.Init(breakingWall, _playerStateMachine);

        var gameStateMachine = new GameStateSwitcher(map, _enemySpawner, _playerStateMachine);
        new BraveStateMediator(gameStateMachine, enemiesContainer);
        new DefaultStateMediator(gameStateMachine, wallWrecker);

        var inputMediator = new InputMediator(_joystick, _fireButton, _playerStateMachine);
        _joystick.Init(inputMediator);
    }

    private Map GetMap() 
        => new MapBuildingDirector().GetMap();
}
