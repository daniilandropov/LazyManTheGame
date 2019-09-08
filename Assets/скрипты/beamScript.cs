using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class beamScript : MonoBehaviour {

    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    [SerializeField]
    private string levelName;

    private float speed = 90.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    private SpriteRenderer sprite;

    protected virtual void Update()
    {
        direction.y = -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        NewHero unit = collider.GetComponent<NewHero>();

        if (unit && unit is NewHero)
        {
            SceneManager.LoadScene(levelName);
        }
    }

}
