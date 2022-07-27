using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject[] recycleObjectsPrefab;
    public GameObject[] slicedrecycleObjectsPrefab;
    public float spawnTimer = 1.5f;
    private float randz;
    [SerializeField]
    private int randRecycleObject;


    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        randRecycleObject = Random.Range(0, 3);

        if (spawnTimer <= 0f)
        {
            randz = Random.Range(0, 1) == 0 ? 1f : -1f;
            
            Vector3 randomSpawnPosition = new Vector3((Random.Range(-2, 2)), -1, 2);
            Instantiate(recycleObjectsPrefab[randRecycleObject], randomSpawnPosition, Quaternion.identity);
            
            if(Timer.instance.timeValue < 10)
            {
                spawnTimer = 0.5f;
            }
            else
            {
                spawnTimer = 1.5f;
            }
            
        }
        
        //add here if object goes out of range, destroy

    }

    public void SpawnSliced(string tag, Vector3 position)
    {
        if (tag == "CokeCan")
        {
            Instantiate(slicedrecycleObjectsPrefab[0], position, Quaternion.identity);
        }
        else if (tag == "Box")
        {
            Instantiate(slicedrecycleObjectsPrefab[1], position, Quaternion.identity);
        }
        else if (tag == "Jar")
        {
            Instantiate(slicedrecycleObjectsPrefab[2], position, Quaternion.identity);
        }

        //Instantiate(slicedrecycleObjectsPrefab[0], position, Quaternion.identity);
    }
    IEnumerator WaitForSeconds()
    {

        yield return new WaitForSeconds(1);

    }
}
