using System.Collections;
using UnityEngine;

public class LaptopScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipBuy;

    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _door;

    [SerializeField] private AudioClip _audioClipVoice;

    private bool _isBuyed = false;

    public string GetDescription()
    {
        if (_isBuyed == true)
            return "";
        else
            return "Нажми [E] чтобы <color=green>купить</color> оружие";
    }

    public void Interact()
    {
        if (_isBuyed == false)
        {
            _gun.SetActive(true);
            _door.SetActive(true);

            PlaySound(_audioClipBuy);
            StartCoroutine(StartVoiceLine());
        }
    }

    IEnumerator StartVoiceLine()
    {
        yield return new WaitForSeconds(1f);
        PlaySound(_audioClipVoice);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}