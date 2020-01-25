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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NewHero unit = collision.gameObject.GetComponent<NewHero>();

        if (unit)
        {
            if (takeAudioSource != null && takeAudio != null)
                takeAudioSource.PlayOneShot(takeAudio);

            unit.Health = hp_points;
            Destroy(gameObject);
        }
    }
}
