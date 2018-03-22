 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void PlayGame(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	// Update is called once per frame
	public void ExitGame ()
        {
            Debug.Log("QUIT!");
            Application.Quit();
		
	}
}


}
