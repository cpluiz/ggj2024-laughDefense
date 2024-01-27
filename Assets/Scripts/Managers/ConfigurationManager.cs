using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private FloatVariable _generalVolume;
    [SerializeField] private FloatVariable _musicVolume;
    [SerializeField] private FloatVariable _sfxVolume;

    [Space, Header("References")]
    [SerializeField] private UnityEngine.UI.Slider _generalVolumeSlider;
    [SerializeField] private UnityEngine.UI.Slider _musicVolumeSlider;
    [SerializeField] private UnityEngine.UI.Slider _sfxVolumeSlider;

    private void Awake()
    {
        LoadSavedValues();
        _generalVolumeSlider.value = _generalVolume.Value;
        _musicVolumeSlider.value = _musicVolume.Value;
        _sfxVolumeSlider.value = _sfxVolume.Value;
    }

    private void OnDestroy()
    {
        SaveValues();
    }

    private void LoadSavedValues()
    {
        _generalVolume.Value = PlayerPrefs.GetFloat("generalVolume", 100);
        _musicVolume.Value = PlayerPrefs.GetFloat("musicVolume", 100);
        _sfxVolume.Value = PlayerPrefs.GetFloat("sfxVolume", 100);
    }

    private void SaveValues()
    {
        PlayerPrefs.SetFloat("generalVolume", _generalVolume.Value);
        PlayerPrefs.SetFloat("musicVolume", _musicVolume.Value);
        PlayerPrefs.SetFloat("sfxVolume", _sfxVolume.Value);
    }

    public void UpdateGeneralVolume(float value)
    {
        _generalVolume.Value = value;
    }
    public void UpdateMusicVolume(float value)
    {
        _musicVolume.Value = value;
    }
    public void UpdateSFXVolume(float value)
    {
        _sfxVolume.Value = value;
    }
}
