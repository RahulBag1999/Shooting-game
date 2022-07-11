using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    public GameObject player;
    public Transform parentGO;

    void Start()
    {
       // GameObject g = new GameObject();
       // Instantiate(player);

        GameObject go = Instantiate(player, new Vector3(7f, 7f, 7f), new Quaternion(0, 0, 0, 0));
        go.transform.position = new Vector3(0, 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
