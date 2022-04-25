using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField] private Slider slider;
    private float volume = 0.6f;
    void Start()
    {
        slider.value = volume;
        audioSource.volume = volume;
    }


    public void SetVolume()
    {
        volume = slider.value;
        audioSource.volume = volume;
    }

    void LoadStats()
    {
        
    }
}