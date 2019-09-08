using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shhoter : Monster {

    [SerializeField]
    private float rate = 2.0F;

    [SerializeField]
    private bool isLeft = false;

    [SerializeField]
    private bool BOSS = false;

    [SerializeField]
    private int boosSize = 5;

    [SerializeField]
    private float boosDistance = 5.0F;

    private EmenyBullet bullet;

    private SpriteRenderer sprite;

    private Transform[] head;

    private Vector3 direction;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<EmenyBullet>("CARTR");

        direction = transform.right;

        if (isLeft)
        {
            direction *= -1.0F;
            sprite.flipX = direction.x < 0.0F;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction,  Time.deltaTime);
        }
    }
    
    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        var povorot = isLeft ? -1.0F : 1.0F;
        Vector3 pos = transform.position;

        if (BOSS)
        {
            float myFloat;
            int myInt;
            System.Random rnd = new System.Random();

            myInt = rnd.Next(0, boosSize);
            myFloat = myInt + 0.5f;

            pos.y += myFloat;
            pos.x += boosDistance * povorot;
        }
        else
        {
            pos.y += 0.5F;
            pos.x += 0.8F * povorot;
        }
        
        EmenyBullet newBullet = Instantiate(bullet, pos, bullet.transform.rotation) as EmenyBullet;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        newBullet.Parent = gameObject;

    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        NewHero unit = collider.GetComponent<NewHero>();

        if (unit && unit is NewHero)
        {
            Collider2D[] coliders = Physics2D.OverlapAreaAll(head[2].position, head[1].position);

            if (coliders.Length > 1)
            {
                ReciveDamage(1);
                unit.Jump();
            }
            else unit.ReciveDamage(1);
        }

        bulletHero bulletHero = collider.GetComponent<bulletHero>();

        if (bulletHero)
        {
            ReciveDamage(1);

        }
    }

}
