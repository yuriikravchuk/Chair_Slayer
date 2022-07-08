public class PlayerFire
{
    private Gun _gun;

    public PlayerFire(Gun gun)
    {
        _gun = gun;
    }

    public void TryFire() => _gun.TryShoot();

    public void SetGun(Gun gun) => _gun = gun;

}
