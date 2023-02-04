using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootInteraction : MonoBehaviour
{
    [SerializeField]
    private int food;

    [SerializeField]
    private int skata;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("food")) {
            StartCoroutine(SelfDestruct(collision.gameObject));
            food++;
            Debug.Log(food);
        }
        else if (collision.gameObject.CompareTag("skata")) {
            StartCoroutine(SelfDestruct(collision.gameObject));  
            skata++;
            Debug.Log(skata);
        }
    }
    IEnumerator SelfDestruct(GameObject gameobject) {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameobject);
    }
}
