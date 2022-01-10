using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private float backGroundSpeed = 2.0f;
    float moveCheck;


    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        moveCheck = transform.position.y;
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        moveCheck -= backGroundSpeed * Time.deltaTime;
        transform.position = new Vector3(pos.x, moveCheck, pos.y);
        if (moveCheck < -11.0f)
            moveCheck = 10.0f;
    }
}
