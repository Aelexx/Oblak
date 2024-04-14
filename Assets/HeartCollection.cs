using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCollection : MonoBehaviour
{
    private static int heart = 0;
    public TextMeshProUGUI heartText;
    public AudioSource heartAudio;
    public AudioClip heartClip;

    private void OnTriggerEnter(Collider other)
    {   
        
        if(other.transform.tag == "TagHeart")
        {
            heartAudio = GetComponent<AudioSource>();
            heartAudio.PlayOneShot(heartClip);
            heart++;
            heartText.text = "Heart: " + heart.ToString();
            Debug.Log(heart);
            Destroy(other.gameObject);
        }
    }

}
