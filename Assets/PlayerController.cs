using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    float maxSpeed = 15.0f;
    bool isOnGround = false;

    Rigidbody2D playerObject;

   
    Vector3 jumpForce = new Vector3(0.0f, 10.0f, 0.0f);

    bool isJumping = true;



    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();

        if (isJumping == true)
        {
            playerObject.AddForce(jumpForce);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        float movementValueX = Input.GetAxis("Horizontal");

        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 500.0f));
        }

    }
}