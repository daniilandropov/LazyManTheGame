using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

    [SerializeField]
    private string levelName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        NewHero unit = collider.GetComponent<NewHero>();

        if (unit && unit is NewHero)
        {
            SceneManager.LoadScene(levelName);
        }
    }

}
