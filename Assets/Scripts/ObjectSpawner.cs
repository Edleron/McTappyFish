using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject obstacle;
    private float lifeTime = 2.5f;

    private float timer;
    private bool isInitialized = false;

    private void Start()
    {
        isInitialized = true;
        FishMovement.instantObstacle += InstantiateObstacle;
    }

    private void OnEnable()
    {
        if (isInitialized)
            FishMovement.instantObstacle += InstantiateObstacle;
    }


    private void OnDisable()
    {
        FishMovement.instantObstacle -= InstantiateObstacle;
    }

    private void Update()
    {
        if (GameManager.isGameOver == false && GameManager.isGameStarted == true)
        {
            timer += Time.deltaTime;
            if (timer > lifeTime)
            {
                InstantiateObstacle();
                timer = 0;
            }
        }
    }

    public void InstantiateObstacle()
    {
        float yPos = Random.Range(0.25f, -5.25f);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, yPos);
        Debug.Log("Event - Delegate Obstacle Intantiate Statements Process Featrues");
    }
}
