using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour {
    private float spawnz = 20f;
    public GameObject[] prefabs;
    private float RoadLength = 10f;
    private int amountOfRoads = 20;
    int CountOfRoad = 6;

    private List<GameObject> roadsList;
    private Transform playertransform;
	// Use this for initialization
	void Start () {
        roadsList = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amountOfRoads; ++i)
        {
            Spawn(0);
        }
	}

    // Update is called once per frame
    void Spawn(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(prefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
           
        go.transform.position = Vector3.right * spawnz;
        spawnz += RoadLength;
        roadsList.Add(go);

    }

    void Update () {
        
        if (playertransform.position.x>(spawnz-amountOfRoads*RoadLength))
        {
          CountOfRoad++;
          Spawn(0);
            if (CountOfRoad > 7)
            {
                DeleteRoad();
            }
        }
       
	}
    void DeleteRoad()
    {
        Destroy(roadsList[0]);
        roadsList.RemoveAt(0);
    }

}
