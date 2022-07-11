using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float jumpForce;

    private float MoveX;
    private float MoveZ;
    private Rigidbody playerRb;
    private bool isJumping = true;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(MoveX, 0, MoveZ);

        playerRb.transform.Translate(move * speed * Time.deltaTime, Space.World);

        if(move!=Vector3.zero)
        {
            transform.forward = move;
        }
        if(Input.GetButtonDown("Jump")&&isJumping)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isJumping = true;
        }
    }
}
