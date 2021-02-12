﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftBound = -5;
    private float bottomLimit = -6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= leftBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.y <= bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
