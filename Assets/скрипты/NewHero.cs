using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewHero : Unit {
    [SerializeField]
    private int lives = 5; //сколько раз можно отхватить пизды
    [SerializeField]
    private float speed = 5.0F; //быстрые ноги пизды не боятся
    [SerializeField]
    private float jumpForce = 15.0F; //прыгучесть

    private bool isGrounded = false; //заземление

    private DS DS;
    private PSP PSP;
    private GAMEBOY GAMEBOY;

    public float ShootSpeed = 1.0F;
    public float ShootTimer = 0.0f;

    public float AttackSpeed = 0.2F;
    public float AttackTimer = 0.0f;

    //protected Joystick joystick;
    //protected JoyButtonDS joyButtonDS;
    //protected JoyButtonPSP joyButtonPSP;
    //protected JoyButtonGB joyButtonGB;
    //protected JoyButtonSPACE joyButtonSPACE;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        //joystick = FindObjectOfType<Joystick>();
        //joyButtonDS = FindObjectOfType<JoyButtonDS>();
        //joyButtonPSP = FindObjectOfType<JoyButtonPSP>();
        //joyButtonGB = FindObjectOfType<JoyButtonGB>();
        //joyButtonSPACE = FindObjectOfType<JoyButtonSPACE>();
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        DS = Resources.Load<DS>("DS");
        PSP = Resources.Load<PSP>("PSP");
        GAMEBOY = Resources.Load<GAMEBOY>("GAMEBOY");
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if ((Input.GetKeyDown(KeyCode.Z)/* || joyButtonDS.Pressed*/) & ShootTimer <= 0) ShootDS();
        if ((Input.GetKeyDown(KeyCode.X)/* || joyButtonPSP.Pressed*/) & ShootTimer <= 0) ShootPSP();
        if ((Input.GetKeyDown(KeyCode.C) /*|| joyButtonGB.Pressed*/) & ShootTimer <= 0) ShootGAMEBOY();

        if (Input.GetButton("Horizontal")) Run(Input.GetAxis("Horizontal"));
        //if (joystick.Horizontal != 0) Run(joystick.Horizontal);
        if (Input.GetButtonDown("Jump")) Jump();
        //if (joyButtonSPACE.Pressed) Jump();
        

        if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }

        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
        }

        if(1 == 2)
            Console.WriteLine("никто никогда этого не увидит");
    }

    private void Run(float axis)
    {
        if (isGrounded) State = CharState.Run;

        Vector3 direction = transform.right * axis;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
    }

    private void ShootPSP()
    {
        Vector3 position = transform.position;
        position.y += 1.5F;
        PSP bullet;

        bullet = PSP;

        PSP newBullet = Instantiate(bullet, position, bullet.transform.rotation);

        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        newBullet.Parent = gameObject;

        ShootTimer = ShootSpeed;

    }

    private void ShootDS()
    {
        Vector3 position = transform.position;
        position.y += 1.5F;
        DS bullet;

        bullet = DS;

        DS newBullet = Instantiate(bullet, position, bullet.transform.rotation);

        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        newBullet.Parent = gameObject;

        ShootTimer = ShootSpeed;
    }

    private void ShootGAMEBOY()
    {
        Vector3 position = transform.position;
        position.y += 1.5F;
        GAMEBOY bullet;

        bullet = GAMEBOY;

        GAMEBOY newBullet = Instantiate(bullet, position, bullet.transform.rotation);

        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
        newBullet.Parent = gameObject;

        ShootTimer = ShootSpeed;
    }

    public void Jump()
    {
        if (isGrounded) rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        //joyButtonSPACE.SetPressedFalse();
    }

    public override void ReciveDamage(int урон)
    {
        Debug.Log("Урон:"+ урон);
        lives = lives - урон;

        if (lives < 1)
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            rigidbody.AddForce(transform.right * (sprite.flipX ? 1.0F : -1.0F) * 15.0F, ForceMode2D.Impulse);
            Debug.Log("Здоровье: "+lives);
        }
    }

    private void CheckGround()
    {
        Collider2D[] coliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = coliders.Length > 1;

        if(!isGrounded) State = CharState.Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit)
        {
            ReciveDamage(1);
        }
    }
}

public enum CharState
{
    Idle,
    Run,
    Jump,
    At
}