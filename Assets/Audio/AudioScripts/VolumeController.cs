using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;
    private const float _multiplyer = 20f;


    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplyer;
        mixer.SetFloat(volumeParameter, _volumeValue);
    }


    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter,Mathf.Log10(slider.value) * _multiplyer);
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplyer);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }
}
