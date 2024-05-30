using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    private float fireRate = 0.2F;
    private float timeLastFired;
    private int magazineSize = 18;
    private int bulletsRemaining = 18;
    public AudioSource Audio;
    public AudioClip shot;
    public AudioSource reload;

   

    void Start()
    {
        timeLastFired = Time.time;
    }
    void Update()
    {
       Shoot();
       Reload();
    }

    public void Reload()
    {
       if(Input.GetKeyDown(KeyCode.R) && bulletsRemaining == 0)
       {
         Invoke("AddBullets", 2.5f);
         reload.Play();
       }

    }

    public void AddBullets()
    {
        bulletsRemaining = magazineSize;
    }

    public void Shoot()
    {
        if(Input.GetMouseButton(0) && Time.time - timeLastFired > fireRate && bulletsRemaining > 0)
       {    
           Instantiate(bullet, firePoint.position, firePoint.rotation);
           timeLastFired = Time.time;
           bulletsRemaining--;
           Audio.PlayOneShot(shot, 1f);
       } 
    }
}