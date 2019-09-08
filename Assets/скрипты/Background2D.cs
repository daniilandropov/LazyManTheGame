using UnityEngine;
using System.Collections;

public class Background2D : MonoBehaviour
{

    public Transform bg1;
    public float speedBG1 = 0.015f;

    public Transform bg2;
    public float speedBG2 = 0.010f;

    public Transform bg3;
    public float speedBG3 = 0.005f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
    }

    Vector3 GetVector(Vector3 position, float speed)
    {
        float posX = position.x;
        posX += cam.velocity.x * speed;
        return new Vector3(posX, position.y, position.z);
    }

    

    void Update()
    {
        if (bg1) bg1.position = GetVector(bg1.position, speedBG1);
        if (bg2) bg2.position = GetVector(bg2.position, speedBG2);
        if (bg3) bg3.position = GetVector(bg3.position, speedBG3);
    }
}