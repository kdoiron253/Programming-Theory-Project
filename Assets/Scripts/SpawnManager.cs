using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject endWall;

    private float spawnPositionX = 13f;
    private float spawnRangeY = 3.5f;
    private float randomWallSpawnTimer;
    private float minWallSpawnTimer = 1.5f;
    private float maxWallSpawnTimer = 4f;
    private float wallObstacleTimer = 0f;
    private int wallCounter;
    private int wallCounterMax = 5;


	// Start is called before the first frame update
	void Start()
    {
        RandomSpawnTimerGenerator();
        wallCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // make sure a wall hasn't been hit, then spawn more walls
       
        if (wallObstacleTimer > randomWallSpawnTimer && !ObstacleRegularWall.isHit && wallCounter < wallCounterMax) {
            SpawnWallObstacle();
            wallCounter++;
            wallObstacleTimer = 0;
            RandomSpawnTimerGenerator();
        
        } else if (wallObstacleTimer > randomWallSpawnTimer && wallCounter == wallCounterMax) {
			SpawnEndWall();
			wallCounter = 0;
			wallObstacleTimer = 1;
			RandomSpawnTimerGenerator();
			// call random color picker
		} else {
            wallObstacleTimer += Time.deltaTime;
        }
        
    }

	// ABSTRACTION
	private void SpawnWallObstacle()
    {
        Vector3 spawnPosition = SpawnPositionGenerator();

        GameObject wallObstacle = PoolingScript.SharedInstance.GetPooledWallObstacle();
        {
            wallObstacle.transform.position = spawnPosition;
            wallObstacle.transform.rotation = wallObstacle.transform.rotation;
            wallObstacle.SetActive(transform);
        }
    }

    private Vector3 SpawnPositionGenerator()
    {
		float randomY = Random.Range(-spawnRangeY, spawnRangeY);

		Vector3 spawnPosition = new Vector3(spawnPositionX, randomY, 0);

        return spawnPosition;

	}

    private void SpawnEndWall()
    {
		Vector3 spawnPosition = SpawnPositionGenerator();
        Instantiate(endWall, spawnPosition, endWall.transform.rotation);

	}

	private void RandomSpawnTimerGenerator()
    {
		randomWallSpawnTimer = Random.Range(minWallSpawnTimer, maxWallSpawnTimer);
	}
}
