using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 10;
    //public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    [SerializeField] float speed = 20;
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private Vector3 GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector3(horizontalInput, 0f, verticalInput);
    }
    private void MovePlayer()
    {
        transform.Translate(GetInput() * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        } else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("game over!!!");
        }
       
    }


}
        

    
