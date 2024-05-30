using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    [SerializeField] private List<AudioClip> _clips;

    [SerializeField] private Image _healthBar;

    public void StartVictory()
    {
        HideMobObjects();

        StartCoroutine(StartVictoryMusicAndVoice());
    }

    private void HideMobObjects()
    {
        _musicSource.Stop();
        _soundSource.Stop();
        _healthBar.enabled = false;
    }

    IEnumerator StartVictoryMusicAndVoice()
    {
        yield return new WaitForSeconds(2f);

        _soundSource.volume = 1;
        PlayVoice(_clips[0]);

        PlayMusic(_clips[1]);

        yield return new WaitForSeconds(20f);

        SceneManager.LoadScene(1);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip != null && _musicSource != null)
        {
            _musicSource.PlayOneShot(clip);
        }
    }

    private void PlayVoice(AudioClip clip)
    {
        if (clip != null && _soundSource != null)
        {
            _soundSource.PlayOneShot(clip);
        }
    }
}