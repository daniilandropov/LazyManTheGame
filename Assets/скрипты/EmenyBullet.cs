using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyBullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    public Vector3 Direction;

    private float speed = 10.0F;

    [SerializeField]
    private bool bullet_destroy_ignore = false;

    [SerializeField]
    private float fade_time = 2.5F;
    
    private void Start()
    {
        Destroy(gameObject, fade_time);
    }

    protected virtual void Update()
    {
        Direction.y = 0.4F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NewHero NewHero = collision.gameObject.GetComponent<NewHero>();
        if (NewHero)
        {
            NewHero.ReciveDamage(1);
            Destroy(gameObject);

            BulletDestroy.BangHere(GetComponent<Collider2D>().transform);
        }

        bulletHero bulletHero = collision.gameObject.GetComponent<bulletHero>();

        if (bulletHero)
        {
            Destroy(gameObject);

            BulletDestroy.BangHere(GetComponent<Collider2D>().transform);
        }
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

        bulletHero bulletHero = collider.GetComponent<bulletHero>();

        if (bulletHero) 
        {
            Destroy(gameObject);

            BulletDestroy.BangHere(collider.transform);
        }
        
        BulletDestroy bd = collider.GetComponent<BulletDestroy>();

        if (bd && bd.gameObject != parent)
        {
            Destroy(gameObject);
        }
        
    }

}
