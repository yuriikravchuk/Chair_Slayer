public class SaveBinder
{
    private readonly LevelPresenter _level;
    private readonly WalletPresenter _wallet;
    private readonly ISaveProvider<Save> _provider;

    public SaveBinder(LevelPresenter level, WalletPresenter wallet)
    {
        _level = level;
        _wallet = wallet;
        _provider = new SaveProvider<Save>();
    }


    public void Bind()
    {
        Save save = _provider.TryGetSave();
        _level.Init(save.Level);
        _wallet.Init(save.Money);
    }
}
