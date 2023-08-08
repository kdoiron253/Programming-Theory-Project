using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ObstacleParent : MonoBehaviour
{
    private Rigidbody obstacleRigidBody;
    private float moveSpeed = 3f;
    private Vector3 moveAxis;
    // ENCAPSULATION
	public static bool isHit { get; private set; }
    public static int value { get; private set; }
	public static string wallName = "Wall";



	// Start is called before the first frame update
	void Start()
    {
        isHit = false;
        obstacleRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHit) {
            moveAxis = new Vector3(-moveSpeed, obstacleRigidBody.position.y, obstacleRigidBody.position.z);
            obstacleRigidBody.MovePosition(obstacleRigidBody.position + (moveAxis * Time.deltaTime));
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
		isHit = true;
		// stop all movement
	}

    public static void RestartGame()
    {
        isHit = false;
	}

	private void PointValue()
	{
		value = 1;
	}

}
