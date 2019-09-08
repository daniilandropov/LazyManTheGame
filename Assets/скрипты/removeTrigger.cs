using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeTrigger : MonoBehaviour {

    public GameObject Prefab;

    void OnTriggerEnter2D()
    {
        Destroy(Prefab);
	}
	

}
