using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNewMusic : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        NewHero NewHero = other.GetComponent<NewHero>();

        if (NewHero)
        {
            audio.Stop();
            audio.clip = audioClip;
            audio.Play();
            Destroy(gameObject);
        }

    }
}
