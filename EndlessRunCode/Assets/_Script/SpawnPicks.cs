using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPicks : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float space;
    public float space2;
    private Transform playertransform;


    void Start()
    {
        StartCoroutine(SpawnWaves());
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            spawnValues.z = 0;
            spawnValues.z = Random.Range(spawnValues.z - 4, spawnValues.z + 4);
            spawnValues.x =playertransform.position.x+60;
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                spawnValues.x += space;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }




    }


}





