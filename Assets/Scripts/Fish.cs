using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _myRb;
    [SerializeField] private float _speed = 9.0f;

    private int maxAngle = 20;
    private int minAngle = -60;
    private int angle = 0;
    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        FishMovement();
        FishRotate();
    }

    private void FishMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _myRb.velocity = Vector2.zero;
            _myRb.velocity = new Vector2(_myRb.velocity.x, _speed);
        }
    }

    private void FishRotate()
    {
        if (_myRb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_myRb.velocity.y < -3)
        {
            if (angle > minAngle)
            {
                angle = angle - 1;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
