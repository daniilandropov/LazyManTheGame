using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walker : Monster {

    [SerializeField]
    private float speed = 1.0F;

    [SerializeField]
    private bool jumper = false; // он прыгун?

    [SerializeField]
    private bool earth_touch_jumper = false; // прыгает касаясь земли?

    [SerializeField]
    private float jumpForce = 1.0F; // и если да, то на сколько высоко?

    [SerializeField]
    protected bool isLeft = false;

    [SerializeField]
    protected bool debuging = false;

    private Bullet bullet;
    

    protected void Start()
    {
        base.Start();
        direction = transform.right;

        if (isLeft)
        {
            direction *= -1.0F;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
        }
    }

    private void Movie()
    {
        Collider2D[] coliders = Physics2D.OverlapAreaAll(head[4].position, head[5].position); // точки касания для разворота
        
        if (coliders.Length > 0 && coliders.All(x=>x.GetComponentInParent<BulletDestroy>() || x.GetComponentInParent<timeToGOBACK>() || x.GetComponentInParent<Monster>()))
        {
            direction *= -1.0F;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        if (jumper) // прыгун
        {
            if (coliders.Length > 0 && coliders.All(x => x.GetComponentInParent<BulletDestroy>() || x.GetComponentInParent<timeToGOBACK>() || x.GetComponentInParent<NewHero>()))
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (earth_touch_jumper)
        {
            Collider2D[] coliders_nogi = Physics2D.OverlapAreaAll(head[6].position, head[7].position); // ноги прыжок

            if ((coliders_nogi.Length > 0 && coliders.All(x => x.GetComponentInParent<BulletDestroy>())))
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        Collider2D[] headColliders = Physics2D.OverlapAreaAll(head[2].position, head[3].position);

        if (headColliders.Length > 0 && headColliders.All(x => x.GetComponentInParent<NewHero>()))
        {
            LazyMan.Jump(15.0F);
            ReciveDamage(1, true);
        }
    }

    protected override void Update()
    {
        if(active) Movie();
    }


}
