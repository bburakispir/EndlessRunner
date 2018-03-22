using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecameVisible : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
