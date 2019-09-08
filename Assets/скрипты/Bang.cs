using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour {

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        Destroy(gameObject.GetComponentInParent<shouldBeDestroied>().gameObject, 0.37F);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
