using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private Vector3 rotate;
    
    void Update()
    {
        transform.Rotate(rotate * rotSpeed * Time.deltaTime);
    }
}
