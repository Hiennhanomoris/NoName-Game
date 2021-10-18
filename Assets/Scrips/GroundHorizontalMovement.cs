using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float pos;
    [SerializeField] private int dir;
    [SerializeField] private float distance;

    // Start is called before the first frame update
    void Awake()
    {
        pos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x < pos - distance)
        {
            transform.position = new Vector3(pos - distance, transform.position.y, transform.position.z);
            dir *= -1;
        } 
        if(transform.position.x > pos + distance)
        {
            transform.position = new Vector3(pos + distance, transform.position.y, transform.position.z);
            dir *= -1;
        }

        transform.Translate(Vector2.right * speed * dir);
    }
}
