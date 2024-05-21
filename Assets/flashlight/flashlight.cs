using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light lightSource;
    public AudioClip switchOnSound;
    public AudioClip switchOffSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        lightSource.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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