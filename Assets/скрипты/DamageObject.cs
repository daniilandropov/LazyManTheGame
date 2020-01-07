using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

    [SerializeField]
    private int урон = 1;

    [SerializeField]
    public bool ИсчезатьПослеКасания;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is NewHero)
        {
            unit.ReciveDamage(урон);
        }

        Monster monster = collider.GetComponent<Monster>();

        if (monster && monster is Monster)
        {
            monster.ReciveDamage(урон, false);
        }

        if(ИсчезатьПослеКасания)
            Destroy(gameObject);
    }

}
