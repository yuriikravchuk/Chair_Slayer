using UnityEngine;

[RequireComponent(typeof(UIView))]
public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private UIView _view;

    private Wallet _model;

    public void Init(int coinsAmount)
    {
        _model = new Wallet(coinsAmount);
        UpdateView();
    }

    public void IncreaseLevel(int value)
    {
        _model.AddCoins(value);
        UpdateView();
    }

    private void UpdateView()
        => _view.UpdateValue(_model.CoinsAmount.ToString());
}
