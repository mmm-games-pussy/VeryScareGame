using System.Collections;
using UnityEngine;

public class Scene1StartVoice : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private GameObject _door;

    private void Start()
    {
        StartCoroutine(VoiceLine());
    }

    IEnumerator VoiceLine()
    {
        yield return new WaitForSeconds(38f);

        PlaySound(_audioClip);

        _door.SetActive(true);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}