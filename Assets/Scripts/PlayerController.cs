using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float yMin = -3.5f;
    private float yMax = 5.5f;
    private float verticalInput;
    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObstacleRegularWall.isHit) {
            verticalInput = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.up * verticalInput, ForceMode.Impulse);

            if (transform.position.y > yMax) {
                playerRb.AddForce(Vector3.down, ForceMode.Impulse);
            }

            if (transform.position.y < yMin) {
                playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            }
        }
	}
}
