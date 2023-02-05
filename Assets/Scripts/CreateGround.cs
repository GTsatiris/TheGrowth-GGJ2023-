using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject tile;
    public int width = 100;
    public int height = 100;
    public float scale = 20f;
    public float threshold = 0.5f;
    private float[,] noiseMap;

    void Start() {
        noiseMap = new float[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;

                if (perlinValue < threshold) {
                    Vector3 spawnPosition = new Vector3(-x+21f , -y+1.55f, 0);
                    //Vector3 spawnPosition = spawn.transform.position;
                    GameObject instObj = Instantiate(tile, spawnPosition, Quaternion.identity);
                    instObj.transform.parent = gameObject.transform;
                }
            }
        }
    }
}
