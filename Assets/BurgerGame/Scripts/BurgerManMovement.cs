using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerManMovement : MonoBehaviour
{
    [SerializeField] float speed = 20;
    public float horizontalInput;
    public float verticalInput;

    private Rigidbody rb; // Reference to the Rigidbody component


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(GetInput() * speed * Time.deltaTime);
    }

    private Vector3 GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        return new Vector3(horizontalInput, 0f, verticalInput);
    }


}
