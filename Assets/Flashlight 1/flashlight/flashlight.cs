using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light lightSource;
    public AudioClip switchOnSound;
    public AudioClip switchOffSound;

    private AudioSource audioSource;

    void Start()
    {
        lightSource.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            lightSource.enabled = !lightSource.enabled;

            if (lightSource.enabled)
            {
                PlaySound(switchOnSound);
            }
            else
            {
                PlaySound(switchOffSound);
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}