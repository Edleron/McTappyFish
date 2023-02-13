using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    // Todo : proje başladıktan sonra, git uset değiştirilecek.
    // Todo : Commitler bu sebeple gözükmüyor.
    public float speed;
    private BoxCollider2D box;
    private float groundWith;
    private float obstacleWidth;

    private void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWith = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if (GameManager.gameOver == false)
        {
            // Time.deltaTime, -> Bilgisayar sistemin'deki (ĞGpu, Cpu) zamanları eşitlemek için kullınlmaktadır.
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWith)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWith, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
