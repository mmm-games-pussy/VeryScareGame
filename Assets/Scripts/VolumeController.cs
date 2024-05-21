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
        // �������� ���������� �������� ���������
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumePrefKey, 1.0f); // �� ��������� ��������� ������ 100%
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumePrefKey, 1.0f); // �� ��������� ��������� �������� 100%

        // ��������� ��������� �������� ��������
        musicVolumeSlider.value = savedMusicVolume;
        sfxVolumeSlider.value = savedSFXVolume;

        // ���������� ���������
        UpdateMusicVolume(savedMusicVolume);
        UpdateSFXVolume(savedSFXVolume);

        // ������������� �� ��������� �������� ��������
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