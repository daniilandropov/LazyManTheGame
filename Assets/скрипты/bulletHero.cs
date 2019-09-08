using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHero : MonoBehaviour {

    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        MonoBehaviour unit = collider.GetComponent<MonoBehaviour>();

        if (unit && unit.gameObject != parent)
        {
            trigger trigger = collider.GetComponent<trigger>();

            if (!trigger)
            {
                Destroy(gameObject);
            }

        }

        Monster Monster = collider.GetComponent<Monster>();

        if (Monster)
        {
            Destroy(gameObject);

            BulletDestroy.BangHere(collider.transform);
        }

        EmenyBullet emenyBullet = collider.GetComponent<EmenyBullet>();

        if (emenyBullet)
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2Dd(Collider2D collider)
    {
        OnTriggerEnter2D(collider);
    }
}
