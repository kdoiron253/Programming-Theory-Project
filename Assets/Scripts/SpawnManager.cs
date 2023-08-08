using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnPositionX = 13f;
    private float spawnRangeY = 3.5f;
    private float randomWallSpawnTimer;
    private float minWallSpawnTimer = 1.5f;
    private float maxWallSpawnTimer = 4f;
    private float wallObstacleTimer = 0f;


	// Start is called before the first frame update
	void Start()
    {
        RandomSpawnTimerGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        // make sure a wall hasn't been hit, then spawn more walls
        if (wallObstacleTimer > randomWallSpawnTimer && !ObstacleRegularWall.isHit) {
            SpawnWallObstacle();
            wallObstacleTimer = 0;
            RandomSpawnTimerGenerator();
        } else {
            wallObstacleTimer += Time.deltaTime;
        }
        
    }

	// ABSTRACTION
	private void SpawnWallObstacle()
    {
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector3 spawnPosition = new Vector3(spawnPositionX, randomY, 0);

        GameObject wallObstacle = PoolingScript.SharedInstance.GetPooledWallObstacle();
        {
            wallObstacle.transform.position = spawnPosition;
            wallObstacle.transform.rotation = wallObstacle.transform.rotation;
            wallObstacle.SetActive(transform);
        }
    }

    private void RandomSpawnTimerGenerator()
    {
		randomWallSpawnTimer = Random.Range(minWallSpawnTimer, maxWallSpawnTimer);
	}
}
