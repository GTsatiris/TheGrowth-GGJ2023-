using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject RootPrefab;
    [SerializeField]
    string key;

    private int state;
    private float lowerBound;
    private float upperBound;

    [HideInInspector]
    public Transform NextSpawningPoint;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        NextSpawningPoint = gameObject.transform;
        GameObject newRoot = Instantiate(RootPrefab, NextSpawningPoint);
        NextSpawningPoint = newRoot.transform.GetChild(1);
        StartCoroutine("SpawningRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(key))
        {
            if (state == 2)
                state = 0;
            else
                state++;
        }
    }

    IEnumerator SpawningRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            GameObject newRoot = Instantiate(RootPrefab, NextSpawningPoint.position, Quaternion.identity);
            newRoot.transform.position += NextSpawningPoint.position - newRoot.transform.GetChild(0).position;
            float randomRotation = 0.0f;
            if(state==0)
            {
                randomRotation = Random.Range(-25.0f, 25.0f);
            }
            else if(state == 1)
            {
                randomRotation = Random.Range(-50.0f, 0.0f);
            }
            else if(state == 2)
            {
                randomRotation = Random.Range(0.0f, 50.0f);
            }

            newRoot.transform.rotation = Quaternion.AngleAxis(randomRotation, Vector3.forward);
            float randomScale = Random.Range(0.1f, 0.7f);
            float randomFlip;
            if (Random.value < 0.5)
                randomFlip = -1.0f;
            else
                randomFlip = 1.0f;
            newRoot.transform.localScale = new Vector3(randomFlip * randomScale, randomScale, 1.0f);
            //newRoot.transform.SetParent(NextSpawningPoint);
            int spawningPointIdx;
            if (Random.value < 0.5)
                spawningPointIdx = 1;
            else
                spawningPointIdx = 2;
            NextSpawningPoint = newRoot.transform.GetChild(spawningPointIdx);
        }
    }
}
