using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyBullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private float speed = 10.0F;

    private void Start()
    {
        Destroy(gameObject, 2.5F);
    }

    protected virtual void Update()
    {
        direction.y = 0.4F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        NewHero NewHero = collider.GetComponent<NewHero>();

        if (NewHero)
        {
            NewHero.ReciveDamage(1);
            Destroy(gameObject);

            BulletDestroy.BangHere(collider.transform);
        }

        Monster Monster = collider.GetComponent<Monster>();

        if (Monster)
        {
            Monster.ReciveDamage(1);
            Destroy(gameObject);

            BulletDestroy.BangHere(collider.transform);
        }

        bulletHero bulletHero = collider.GetComponent<bulletHero>();

        if (bulletHero) 
        {
            Destroy(gameObject);

            BulletDestroy.BangHere(collider.transform);
        }
        
        MonoBehaviour unit = collider.GetComponent<MonoBehaviour>();

        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }

}
