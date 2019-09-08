using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public static void BangHere(Transform transformers)
    {
        var BangProj = Resources.Load("BangProj");
        Bang rwerwer = Instantiate(BangProj, transformers.position, transformers.rotation) as Bang;
    }
}
