using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEBOY : bulletHero
{
    private float speed = 12.0F;

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
        Direction.y = -0.4F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, speed * Time.deltaTime);
    }

}
