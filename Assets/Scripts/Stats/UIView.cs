using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateValue(string value)
        => _text.text = value.ToString();
}
