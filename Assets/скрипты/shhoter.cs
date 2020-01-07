using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Component = System.ComponentModel.Component;

public class shhoter : Monster {

    [SerializeField]
    private float rate = 2.0F;

    [SerializeField]
    private bool BOSS = false;

    [SerializeField]
    private int boosSize = 5; // насколько большой босс

    private EmenyBullet bullet;

    [SerializeField]
    private string buulname = "CARTR";

    private float povorot = 1.0F;
    private float povorotHistory = 1.0F;

    protected void Start()
    {
        base.Start();
        bullet = Resources.Load<EmenyBullet>(buulname);
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        if (!active)
            return;
        Vector3 position = transform.position;
        position.y = head[4].position.y;
        position.x = head[4].position.x;

        if (BOSS)
        {
            float myFloat;
            int myInt;
            System.Random rnd = new System.Random();

            myInt = rnd.Next(0, boosSize);
            myFloat = myInt + 0.5f;

            position.y += myFloat;
        }

        var newBullet = Instantiate(bullet, position, bullet.transform.rotation);

        newBullet.Direction = newBullet.transform.right * povorot;
        newBullet.Parent = gameObject;
    }

    protected override void Update()
    {
        if(!active)
            return;

        Collider2D[] headColliders = Physics2D.OverlapAreaAll(head[2].position, head[3].position);

        if (headColliders.Length > 0 && headColliders.All(x => x.GetComponentInParent<NewHero>()))
        {
            LazyMan.Jump(15.0F);
            ReciveDamage(1, true);
        }

        povorot = LazyMan.transform.position.x <= head[1].position.x ? -1.0F : 1.0F; // узнаем, левее или правее от стрелюна игрок

        if (povorot != povorotHistory)
        {
            povorotHistory = povorot;
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }
    

}
