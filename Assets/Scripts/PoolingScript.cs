using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingScript : MonoBehaviour
{
	public static PoolingScript SharedInstance;

	public List<GameObject> pooledWallObstacles;
	public GameObject wallObstacleToPool;
	private int wallObstacleAmount = 10;


	private void Awake()
	{
		SharedInstance = this;
	}

	private void Start()
	{
		GameObject tmp;

		for (int i = 0; i < wallObstacleAmount; i++) {
			tmp = Instantiate(wallObstacleToPool);
			tmp.SetActive(false);
			pooledWallObstacles.Add(tmp);
		}
	}

	public GameObject GetPooledWallObstacle()
	{
		for (int i = 0; i < wallObstacleAmount; i++) {
			if (!pooledWallObstacles[i].activeInHierarchy) {
				return pooledWallObstacles[i];
			}
		}

		return null;
	}
}
