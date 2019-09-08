using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject Prefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        NewHero NewHero = other.GetComponent<NewHero>();

        if (NewHero)
        {
            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
            Destroy(gameObject);
        }
        
    }
}
