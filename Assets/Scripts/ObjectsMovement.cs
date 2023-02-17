using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    private float speed = 4.0f;
    private float groundWith;
    private float obstacleWidth;


    private void Start()
    {
        // Bu script'i kullanan gameObject'in CompareTag keyword'u ile Tag'ni sorgulayarak 
        // Ground'u mu yoksa, Obstaclemı sorusuna cevap arıyoruz.
        if (gameObject.CompareTag("Ground"))
        {
            groundWith = this.gameObject.GetComponent<BoxCollider2D>().size.x;
        }

        if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if (GameManager.isGameOver == false)
        {
            // Time.deltaTime, -> Bilgisayar sistemin'deki (ĞGpu, Cpu) zamanları eşitlemek için kullınlmaktadır.
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        // Compare Tag, Bu script'i kullanan yapıların tag'i sorgulamaktadır.
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWith)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWith, transform.position.y);
            }
        }

        // Compare Tag, Bu script'i kullanan yapıların tag'i sorgulamaktadır.
        if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.camArea.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
