using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x <= startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
