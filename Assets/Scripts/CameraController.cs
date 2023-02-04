using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    RootSpawner spawner1;
    [SerializeField]
    RootSpawner spawner2;

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

        Vector3 newPosition = (spawner1.NextSpawningPoint.position + spawner2.NextSpawningPoint.position) / 2.0f;
        newPosition.y -= cameraHandicap;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPosition, speed * Time.deltaTime);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cameraZ);
    }
}
