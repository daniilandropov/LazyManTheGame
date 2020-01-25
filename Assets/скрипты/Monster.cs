using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Monster : Unit {

    [SerializeField]
    private int health = 1;

    [SerializeField]
    private Sprite sprite_damage;

    protected Transform[] head;

    new protected Rigidbody2D rigidbody;
    protected BoxCollider2D boxCollider;

    protected Vector3 direction;

    protected NewHero LazyMan;

    public SpriteRenderer sprite;
    [SerializeField]
    private Sprite defaultSprite;

    [SerializeField]
    public AudioClip damageAudio;
    [SerializeField]
    AudioSource damageAudioSource;


    protected bool active = true;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        head = GetComponentsInChildren<Transform>();
    }

    public void ReciveDamage(int урон, bool sound)
    {
        if(damageAudioSource!= null && damageAudio != null && sound)
            damageAudioSource.PlayOneShot(damageAudio);
        
        health = health - урон;
        if (health < 1)
        {
            Die();
        }
        else
        {
            if (sprite_damage != null)
            {
                sprite.sprite = sprite_damage;
                Invoke("SetDefaultSprite", 0.1F);
            }
        }
    }

    protected void SetDefaultSprite()
    {
        sprite.sprite = defaultSprite;
    }

    protected override void Die()
    {
        if (!active)
            return;
        active = false;
        boxCollider.enabled = false;
        rigidbody.AddForce(transform.up * 10.0F, ForceMode2D.Impulse);
        Invoke("ВнизГоловой", 0.3F);
        Destroy(gameObject, 2.5F);
    }

    protected void ВнизГоловой()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, -1, 1));
    }

    protected void Start()
    {
        LazyMan = GameObject.FindObjectOfType<NewHero>();
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        bulletHero bulletHero = collider.GetComponent<bulletHero>();

        if (bulletHero)
        {
            ReciveDamage(1, true);
        }

        DamageObject damageObject = collider.GetComponent<DamageObject>();

        if (damageObject)
        {
            ReciveDamage(100, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NewHero unit = collision.gameObject.GetComponent<NewHero>();

        if (unit)
        {
            unit.Jump(unit.jumpForce);
            unit.ReciveDamage(1);
        }
    }

    protected virtual void Update() { }

    
}
