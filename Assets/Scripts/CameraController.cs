using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    RootSpawner[] spawners;

    [SerializeField]
    float speed;
    [SerializeField]
    float cameraHandicap;

    private float cameraZ;

    // Start is called before the first frame update
    void Start()
    {
        cameraZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = averagePos();
        newPosition.y -= cameraHandicap;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPosition, speed * Time.deltaTime);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraZ);
    }

    private Vector3 averagePos()
    {
        Vector3 avgPos = new Vector3();
        foreach(RootSpawner spawner in spawners)
        {
            avgPos += spawner.NextSpawningPoint.position;
        }

        return avgPos / (float)spawners.Length;
    }    
}
