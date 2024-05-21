using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    private const string MusicVolumePrefKey = "MusicVolume";
    private const string SFXVolumePrefKey = "SFXVolume";

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    private void Start()
    {
        // Загрузка сохранённых значений громкости
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumePrefKey, 1.0f); // По умолчанию громкость музыки 100%
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumePrefKey, 1.0f); // По умолчанию громкость эффектов 100%

        // Установка начальных значений слайдера
        musicVolumeSlider.value = savedMusicVolume;
        sfxVolumeSlider.value = savedSFXVolume;

        // Обновление громкости
        UpdateMusicVolume(savedMusicVolume);
        UpdateSFXVolume(savedSFXVolume);

        // Подписываемся на изменение значения слайдера
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);
    }

    private void UpdateMusicVolume(float value)
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = value;
        }

        PlayerPrefs.SetFloat(MusicVolumePrefKey, value);
        PlayerPrefs.Save();
    }

    private void UpdateSFXVolume(float value)
    {
        if (sfxAudioSource != null)
        {
            sfxAudioSource.volume = value;
        }

        PlayerPrefs.SetFloat(SFXVolumePrefKey, value);
        PlayerPrefs.Save();
    }
}