using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    public GameObject kamera;
    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (transform.position.x < kamera.transform.position.x - 20)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < kamera.transform.position.z - 20)
        {
            Destroy(gameObject);
        }
    }




}
