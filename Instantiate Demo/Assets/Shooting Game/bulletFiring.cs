using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFiring : MonoBehaviour
{
    [SerializeField]
    private float speed;
   void Update()
    {
        Vector3 bulletDirection = new Vector3(0, 0, 1);
        transform.Translate(bulletDirection * speed * Time.deltaTime);

        if(bulletDirection!=Vector3.zero)
        {
            transform.forward = bulletDirection;
        }
    }
}
