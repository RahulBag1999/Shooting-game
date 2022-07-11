using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float playerSpeed;
    [SerializeField] private float firingSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float jumpSpeed;

    private float MoveX;
    private float MoveZ;
    private Rigidbody playerRb;
   

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public bool isGround = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    /*void OnMove(InputValue v)
    {
        Vector2 value = v.Get<Vector2>();
        transform.position += new Vector3(value.x, 0, value.y) * playerSpeed;
        Vector3 pos = transform.position;

        transform.Translate(pos * playerSpeed * Time.deltaTime, Space.World);
        if(pos!=Vector3.zero)
        {
            transform.forward = pos;
        }
 }*/

    private void Update()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(MoveX, 0, MoveZ);
        playerRb.transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);

        if(moveDirection!=Vector3.zero)
        {
            transform.forward = moveDirection;        
        }
        if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        if(Input.GetButtonDown("Jump") && isGround)
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGround = false;
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * firingSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGround = true;
        }
        {

        }
    }
}
