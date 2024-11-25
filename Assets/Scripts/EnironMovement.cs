using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnironMovement : MonoBehaviour
{
    public float speed = 5f;
    public float offset;
    private float backgroundLength;
    private Vector3 spawnPos;
    

    void Start()
    {
        spawnPos = transform.position;
        offset = GetComponent<BoxCollider2D>().size.x / 2;
        backgroundLength = GetComponent<BoxCollider2D>().size.x;
        Debug.Log(backgroundLength);
        Debug.Log(offset);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x <= spawnPos.x - backgroundLength)
        {
            transform.position = spawnPos;
        }
    }
}