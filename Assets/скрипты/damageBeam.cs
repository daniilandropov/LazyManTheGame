using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBeam : DamageObject
{
    [SerializeField]
    private float speed = 50.0F;

    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public float Waiting = 1.0F;
    private float VremeniOstalos = 0.0f;
    public bool Spawn;

    public GameObject Prefab; // если да, то сунуть ее сюда

    [SerializeField]
    public string dir = "bottom";

    private SpriteRenderer sprite;
    public Transform Spawnpoint;

    protected virtual void Update()
    {
        //Debug.Log(Spawn);
        if (dir == "bottom")
        {
            direction.y = -1.0F;
        }

        if (dir == "left")
        {
            direction.x = -1.0F;
        }

        if (dir == "top")
        {
            direction.y = 1.0F;
        }

        if (dir == "сЛевойПоЕбалу")
        {
            direction.y = -0.5F;
            direction.x = -0.5F;
        }

        if (dir == "сПравойПоЕбалу")
        {
            direction.y = -0.5F;
            direction.x = 0.5F;
        }

        if (Spawn)
        {
            if (VremeniOstalos <= 0)
            {
                Spawner();
            }
        }

        if (Spawn)
            VremeniOstalos -= Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 5.5F);
    }

    private void Awake()
    {
        VremeniOstalos = Waiting;
    }

    void Spawner()
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        Destroy(gameObject);
    }

}
