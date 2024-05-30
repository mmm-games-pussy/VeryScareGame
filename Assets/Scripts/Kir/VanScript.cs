using UnityEngine;
using UnityEngine.SceneManagement;

public class VanScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

    public string GetDescription()
    {
        return "Нажми [E] чтобы <color=green>уехать</color> домой";
    }

    public void Interact()
    {
        if (StaticInfo.CapturedImages.Count >= 3)
            SceneManager.LoadScene(4);
        else
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