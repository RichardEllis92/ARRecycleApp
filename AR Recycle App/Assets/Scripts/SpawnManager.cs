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
    public float spawnTimer = 2;
    private float randz;
    private int randRecycleObject;


    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        
        
        if (spawnTimer <= 0f)
        {
            randz = Random.Range(0, 1) == 0 ? 1.5f : -1.5f;
            randRecycleObject = Random.Range(0, 1);
            Vector3 randomSpawnPosition = new Vector3((Random.Range(-5, 5)), (Random.Range(-5, 5)), randz);
            Instantiate(recycleObjectsPrefab[randRecycleObject], randomSpawnPosition, Quaternion.identity);
            spawnTimer = 2f;
        }
        
        //add here if object goes out of range, destroy

    }

    public void SpawnSliced(string tag, Vector3 position)
    {
        if (tag == "Watermelon")
        {     
            if (MeshDestroy.instance.spawned == true)
            {
                Instantiate(slicedrecycleObjectsPrefab[0], position, Quaternion.identity); 
            }
            
        }

        //Instantiate(slicedrecycleObjectsPrefab[0], position, Quaternion.identity);
    }
    IEnumerator WaitForSeconds()
    {

        yield return new WaitForSeconds(1);

    }
}
