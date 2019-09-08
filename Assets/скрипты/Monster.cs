using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit {

    [SerializeField]
    private int health = 1;

    public override void ReciveDamage(int урон)
    {
        health = health - урон;
        if (health < 1)
        {
            Die();
        }
    }

    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }

    
}
