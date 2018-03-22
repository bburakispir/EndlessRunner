using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    // Use this for initialization

    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(1);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
