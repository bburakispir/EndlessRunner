using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {


    // Update is called once per frame
    public void doquit () {
        Debug.Log("has quit game");

        Application.Quit();
    }
}
