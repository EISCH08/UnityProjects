using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float speed;
    public float newSpawnLoaction;
    public GameObject[] prefabList;
    public float startingZ = 53f;
    public float destroyZ = -30f;
    private GameObject prefab;
    private Queue<GameObject> prefabQueue = new Queue<GameObject>();
    private bool spawnCheck = true;
    // Start is called before the first frame update
    void Start()
    {
        prefab = SpawnObstacle();
        prefabQueue.Enqueue(prefab);
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject obj in prefabQueue.ToArray())
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, new Vector3(obj.transform.position.x, obj.transform.position.y, -40), speed * Time.deltaTime);

            if ((obj.transform.position.z < newSpawnLoaction) && spawnCheck == true) 
            {
                Debug.Log("SPAWNING OBs");
                prefab = SpawnObstacle();
                prefabQueue.Enqueue(prefab);
                spawnCheck = false;
            }
            if (obj.transform.position.z <= destroyZ)
            {

                
                prefabQueue.Dequeue();
                Destroy(obj);
                Debug.Log("DESTROYING OBs");
                spawnCheck = true;
            }
        }
    }

    public GameObject SpawnObstacle()
    {
        int prefabIndex = UnityEngine.Random.Range(0, prefabList.Length);
        float x = prefabList[prefabIndex].transform.position.x;
        float y = prefabList[prefabIndex].transform.position.y;


        return Instantiate(prefabList[prefabIndex], new Vector3(x, y, startingZ), prefabList[prefabIndex].transform.rotation);
    }
}
