using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_script : MonoBehaviour
{
    public int hp_points = 1;

    [SerializeField]
    public AudioClip takeAudio;
    [SerializeField]
    AudioSource takeAudioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        NewHero NewHero = other.GetComponent<NewHero>();

        if (NewHero)
        {
            if (takeAudioSource != null && takeAudio != null)
                takeAudioSource.PlayOneShot(takeAudio);

            NewHero.Health = hp_points;
            Destroy(gameObject);
        }

    }
}
