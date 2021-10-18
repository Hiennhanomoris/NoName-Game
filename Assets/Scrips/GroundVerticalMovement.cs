using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVerticalMovement : MonoBehaviour
{
    private float pos;
    [SerializeField] private int dir;
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    void Awake()
    {
        pos = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < pos - distance)
        {
            transform.position = new Vector3(transform.position.x, pos - distance, transform.position.z);
            dir *= -1;
        }
        if(transform.position.y > pos + distance)
        {
            transform.position = new Vector3(transform.position.x, pos + distance, transform.position.z);
            dir *= -1;
        }

        transform.Translate(Vector2.up * dir * speed);
    }
}
