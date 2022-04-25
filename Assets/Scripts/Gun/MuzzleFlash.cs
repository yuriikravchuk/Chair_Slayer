using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] private Sprite[] _flashSprites;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    private int _flashIndex;
    private float _flashTime = 0.1f;
    public void Activate()
    {
        gameObject.SetActive(true);
        _flashIndex = Random.Range(0, _flashSprites.Length);
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _spriteRenderers[i].sprite = _flashSprites[_flashIndex];
        }
        Invoke("Deactivate", _flashTime);
    }

    private void Start()
    {
        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}