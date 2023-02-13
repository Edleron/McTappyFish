using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Todo : proje başladıktan sonra, git uset değiştirilecek.
    // Todo : Commitler bu sebeple gözükmüyor.
    public GameObject obstacle;
    public float lifeTime = 3.5f;
    public float maxY;
    public float minY;


    private float randomY;
    private float timer;

    private void Start()
    {

    }

    private void Update()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer > lifeTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }
}
