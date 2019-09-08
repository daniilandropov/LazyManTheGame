using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Walker : Monster {

    [SerializeField]
    private float speed = 1.0F;

    [SerializeField]
    private bool isLeft = false; // повернуть налево этого долбаеба изначально?

    [SerializeField]
    private bool jumper = false; // он прыгун?

    [SerializeField]
    private float jumpForce = 1.0F; // и если да, то на сколько высоко?

    private Bullet bullet;

    private Transform[] head;

    private SpriteRenderer sprite;

    private Vector3 direction;

    new private Rigidbody2D rigidbody;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        sprite = GetComponentInChildren<SpriteRenderer>();

        head = GetComponentsInChildren<Transform>();
    }

    private void Movie()
    {
        Collider2D[] coliders = Physics2D.OverlapAreaAll(head[3].position, head[4].position);
        Collider2D[] coliders1 = Physics2D.OverlapAreaAll(head[5].position, head[6].position);

        if ((coliders.Length > 1 && coliders.All(x=>!x.GetComponentInParent<NewHero>()))  || (coliders1.Length > 1 && coliders1.All(x => !x.GetComponentInParent<NewHero>())))
        {
            direction *= -1.0F;
            sprite.flipX = direction.x < 0.0F;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        if (jumper) // прыгун
        {
            var bias = 1.5F;
            var point1 = head[3].position;
            point1.x += bias;
            var point2 = head[4].position;
            point2.x += bias;

            var point3 = head[5].position;
            point3.x -= bias;
            var point4 = head[6].position;
            point4.x -= bias;

            Collider2D[] coliders2 = Physics2D.OverlapAreaAll(point1, point2);
            Collider2D[] coliders3 = Physics2D.OverlapAreaAll(point3, point4);

            if ((coliders2.Length > 1 && coliders2.All(x => !x.GetComponentInParent<BulletDestroy>())) || (coliders3.Length > 1 && coliders3.All(x => !x.GetComponentInParent<BulletDestroy>())))
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    protected override void Update()
    {
       Movie();
    }

    protected override void Start()
    {
        direction = transform.right;

        if (isLeft)
        {
            direction *= -1.0F;
            sprite.flipX = direction.x < 0.0F;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        NewHero unit = collider.GetComponent<NewHero>();

        if (unit && unit is NewHero)
        {
            Collider2D[] coliders = Physics2D.OverlapAreaAll(head[2].position, head[1].position);

            if (coliders.Length > 1) //исправить эту корявую хуету, домажит через пизду //более менее
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
