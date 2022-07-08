using UnityEngine;
[RequireComponent(typeof(UIView))]
public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private UIView _view;
    private Wallet _model;

    public void Init (int coinsAmount)
    {
        _model = new Wallet(coinsAmount);
        UpdateView();
    }

    public void AddCoins(int value)
    {
        _model.AddCoins(value);
        UpdateView();
    }

    public void SpendCoins(int value)
    {
        _model.SpendCoins(value);
        UpdateView();
    }

    private void UpdateView()
        => _view.UpdateValue(_model.CoinsAmount.ToString());
}
