using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public float restartDelay = 5f;
    public GameObject player;
    public PlayerController dead;
    

    Animator anim; 
    float restartTimer;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        bool dead = gameObject.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(dead.isdead)
        {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if(restartTimer>=restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
