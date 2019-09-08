using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroyTrigger : MonoBehaviour {

    [SerializeField]
    public Transform Spawnpoint;
    [SerializeField]
    public GameObject Prefab;

    void OnDestroy()
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }
}
