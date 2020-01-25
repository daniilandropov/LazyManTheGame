using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

    [SerializeField]
    private string levelName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NewHero unit = collision.gameObject.GetComponent<NewHero>();

        if (unit && unit is NewHero)
        {
            SceneManager.LoadScene(levelName);
        }
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
