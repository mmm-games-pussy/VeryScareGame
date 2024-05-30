using UnityEngine;

public class PutinScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    public string GetDescription()
    {
        return "����� [E] ����� <color=green>��������</color> �������";
    }

    public void Interact()
    {
        PlaySound(_clip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && _audioSource != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}