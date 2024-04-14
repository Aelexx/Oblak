using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject bullet;
    Vector3 distBullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;

    public AudioSource bulletSound;
    public AudioClip bulletClip;

    // Start is called before the first frame update
    void Start()
    {
        bullet.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {       
        if(Input.GetKeyDown(KeyCode.E))
        {
            bullet.GetComponent<Rigidbody>().isKinematic = false;
            var bulletMy = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            bulletMy.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            bulletSound = GetComponent<AudioSource>();
            bulletSound.PlayOneShot(bulletClip);
            
            if(bulletMy != null)
                {
                    Destroy(bulletMy, 5);                 
                }
        }

        if(Input.GetKey("backspace"))
        {
            bullet.GetComponent<Rigidbody>().isKinematic = false;
            var bulletMy = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            bulletMy.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            
            
            if(bulletMy != null)
                {
                    Destroy(bulletMy, 5);                 
                }
        }

    }
}
