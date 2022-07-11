using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    [SerializeField] public Slider slideToggle;
    Resolution[] resolutions;
    public float volume;
    [SerializeField] readonly string keyVolume = "KEY_VOLUME";

    private void Awake()
    {

        volume = PlayerPrefs.GetFloat(keyVolume, 0);
    }


    private void Start()
    {
        resolutions = Screen.resolutions;

        slideToggle.value = volume;


    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        volume = slideToggle.value;
        PlayerPrefs.SetFloat(keyVolume, volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}