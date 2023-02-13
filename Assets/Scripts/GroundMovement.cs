using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed;
    private BoxCollider2D box;
    private float groundWith;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWith = box.size.x;
    }

    private void Update()
    {
        // Time.deltaTime, -> Bilgisayar sistemin'deki (ĞGpu, Cpu) zamanları eşitlemek için kullınlmaktadır.
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -groundWith)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWith, transform.position.y);
        }
    }
}
