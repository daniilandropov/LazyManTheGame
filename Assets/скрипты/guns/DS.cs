using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DS : bulletHero
{
    private float speed = 12.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, 2.5F);
    }

    protected virtual void Update()
    {
        direction.y = 0.2F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
