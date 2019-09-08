using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal_script : MonoBehaviour
{
    public int hp_points = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        NewHero NewHero = other.GetComponent<NewHero>();

        if (NewHero)
        {
            NewHero.Health = hp_points;
            Destroy(gameObject);
        }

    }
}
