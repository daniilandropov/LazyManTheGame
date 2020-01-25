using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class volkBOSS : Monster
{
    [SerializeField]
    private List<GameObject> points;

    [SerializeField]
    private List<GameObject> аптечки;

    [SerializeField]
    private List<GameObject> супостаты;

    [SerializeField]
    private GameObject конец;

    [SerializeField]
    private float speed;
    
    private System.Random rnd;

    private Transform tragetPoint;
    
    void Start()
    {
        base.Start();
        rnd = new System.Random();
        tragetPoint = points.First().transform;
    }

    private void Movie(Transform goToPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, goToPoint.position, speed * Time.deltaTime);
    }
    
    private void Update()
    {
        if (rnd.Next(2000) < 5)
        {
            var супостат = супостаты[rnd.Next(супостаты.Count)];
            Instantiate(супостат, this.transform.position, супостат.transform.rotation);
        }

        if (rnd.Next(2000) < 5)
        {
            var аптечка = аптечки[rnd.Next(аптечки.Count)];
            Instantiate(аптечка, this.transform.position, аптечка.transform.rotation);
        }

        if (this.transform.position == tragetPoint.position)
            tragetPoint.position = points[rnd.Next(points.Count)].transform.position;
        if (active) Movie(tragetPoint);
        else MovieDown();
    }

    void MovieDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up * -1.0F, speed * Time.deltaTime);
    }

    protected override void Die()
    {
        if (!active)
            return;
        active = false;
        boxCollider.enabled = false;
        Instantiate(конец, this.transform.position, конец.transform.rotation);
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, -1, 1));
        Destroy(gameObject, 2.5F);
    }

    protected void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
}
