using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject GoodCollectible;
    [SerializeField]
    GameObject BadCollectible;

    [SerializeField]
    GameManager GM;

    [SerializeField]
    RootSpawner[] RootSpawners;

    [SerializeField]
    float sidePadding;

    [SerializeField]
    float distFromLowerRoot;
    [SerializeField]
    float boxWidth;

    //Internal state representation
    public int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnCollectibles");
    }

    // Update is called once per frame
    void Update()
    {
        state = GM.level;
    }

    IEnumerator SpawnCollectibles()
    {
        while(true)
        {
            yield return new WaitForSeconds(5.0f);
            
            float LBound_X = getMinX() - sidePadding;
            float RBound_X = getMaxX() + sidePadding;
            float UBound_Y = getMinY() - distFromLowerRoot;
            float LBound_Y = UBound_Y - boxWidth;

            float randomX = Random.Range(LBound_X, RBound_X);
            float randomY = Random.Range(LBound_Y, UBound_Y);

            Vector3 spawnPosition = new Vector3(randomX, randomY, RootSpawners[1].NextSpawningPoint.position.z);

            switch (state)
            {
                case 1:
                    if (Random.value < 0.3)
                        Instantiate(BadCollectible, spawnPosition, Quaternion.identity);
                    else
                        Instantiate(GoodCollectible, spawnPosition + new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
                    break;
                case 2:
                    if (Random.value < 0.5)
                        Instantiate(BadCollectible, spawnPosition, Quaternion.identity);
                    else
                        Instantiate(GoodCollectible, spawnPosition + new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
                    break;
                case 3:
                    if (Random.value < 0.7)
                        Instantiate(BadCollectible, spawnPosition, Quaternion.identity);
                    else
                        Instantiate(GoodCollectible, spawnPosition + new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
                    break;
            }

        }
    }

    private float getMinX()
    {
        float minX = float.MaxValue;
        foreach(RootSpawner spawner in RootSpawners)
        {
            if(spawner.NextSpawningPoint.position.x < minX)
            {
                minX = spawner.NextSpawningPoint.position.x;
            }
        }
        return minX;
    }

    private float getMaxX()
    {
        float maxX = float.MinValue;
        foreach (RootSpawner spawner in RootSpawners)
        {
            if (spawner.NextSpawningPoint.position.x > maxX)
            {
                maxX = spawner.NextSpawningPoint.position.x;
            }
        }
        return maxX;
    }

    private float getMinY()
    {
        float minY = float.MaxValue;
        foreach (RootSpawner spawner in RootSpawners)
        {
            if (spawner.NextSpawningPoint.position.y < minY)
            {
                minY = spawner.NextSpawningPoint.position.y;
            }
        }
        return minY;
    }
}
