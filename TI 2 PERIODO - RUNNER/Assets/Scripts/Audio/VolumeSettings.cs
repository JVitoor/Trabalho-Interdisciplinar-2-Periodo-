using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sliderMusica;
    [SerializeField] Slider sliderSFX;
    [SerializeField] Slider sliderGeral;

    private void Start()
    {
        SettarVolumeMusica();
        SettarVolumeSFX();
        SettarVolumeGeral();
    }
    public void SettarVolumeMusica()
    {
        float volume = sliderMusica.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SettarVolumeSFX()
    {
        float volume = sliderSFX.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SettarVolumeGeral()
    {
        float volume = sliderGeral.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
}
