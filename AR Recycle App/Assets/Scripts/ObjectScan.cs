using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScan : MonoBehaviour
{
    public GameObject unlockedObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSeconds()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForSeconds()
    {

        yield return new WaitForSeconds(10f);
        unlockedObject.SetActive(true);
    }
}
