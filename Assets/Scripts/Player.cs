using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 100;
    public bool isOnGround = true;
    public bool gameOver = false;
    public Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    //Challenge
    [SerializeField] private GameObject UpperBoundary;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        //Challenge
        UpperBoundary = GameObject.Find("Upper Boundary");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Debug.Log("JUMP!");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
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
            dirtParticle.Play();
        }

        else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
            Debug.Log("game over!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }
    }


}
        

    
