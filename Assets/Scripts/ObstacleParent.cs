using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private Rigidbody obstacleRigidBody;
    // private float forceMultiplier = 3f;
    private float moveSpeed = 3f;
    private Vector3 moveAxis;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveAxis = new Vector3(-moveSpeed, obstacleRigidBody.position.y, obstacleRigidBody.position.z);
        obstacleRigidBody.MovePosition(obstacleRigidBody.position + (moveAxis * Time.deltaTime));
    }
}
