using UnityEngine;
using Unity.Audio;

[RequireComponent(typeof(Collider))]
public class TriggerSoundWithChance : MonoBehaviour
{
    [Range(0, 100)]
    public float playChance = 5f;
    public AudioClip soundClip; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

 
        audioSource.clip = soundClip;
        audioSource.playOnAwake = false;

        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (Random.Range(0f, 100f) < playChance)
        {
            audioSource.PlayOneShot(soundClip);
        }

        Destroy(gameObject, soundClip.length);
    }
}