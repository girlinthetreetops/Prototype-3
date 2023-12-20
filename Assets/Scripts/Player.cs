using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 100;
    public bool isOnGround = true;
    public bool gameOver = false;
    public Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Debug.Log("JUMP!");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }

        else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            
            Debug.Log("game over!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }
    }


}
        

    
