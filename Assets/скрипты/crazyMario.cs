using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crazyMario : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject Prefab;


    public float задержка = 2.0F;
    private float ВремениОсталось = 0.0f;

    private void Awake()
    {
        ВремениОсталось = задержка;
    }
    
    private void Update()
    {
        if(ВремениОсталось <= 0){
            Spawner();
        }

        ВремениОсталось -= Time.deltaTime;
    }
    
    void Spawner()
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        Destroy(gameObject);
    }
}
