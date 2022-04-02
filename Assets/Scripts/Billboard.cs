using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void LateUpdate()
    {
        var target = Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}

