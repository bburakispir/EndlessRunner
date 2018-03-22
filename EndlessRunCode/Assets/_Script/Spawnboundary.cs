using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnboundary : MonoBehaviour {
    public GameObject[] hurdles;
    public float hurdleTime;
    private Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(spawnHurdle());
	}
    IEnumerator spawnHurdle()
    {
        yield return new WaitForSeconds(hurdleTime);
        spawn();
    }

    void spawn()
    {
        int randomHurdle = UnityEngine.Random.Range(0, hurdles.Length);
        float[] xpos = new float[3];

        xpos[0] = 0f;
        xpos[1] = 3f;
        xpos[2] = -3f;

        int RandomXposition = UnityEngine.Random.Range(0, xpos.Length);

        Vector3 hposition = new Vector3(player.position.x + 80, 4.27f, xpos[RandomXposition]);
        if(randomHurdle==3)
        {
            hposition = new Vector3(player.position.x + 80, 2.02f, xpos[RandomXposition]);
        }
        Instantiate(hurdles[randomHurdle], hposition, hurdles[randomHurdle].transform.rotation);

        StartCoroutine(spawnHurdle());
    }
	
}
