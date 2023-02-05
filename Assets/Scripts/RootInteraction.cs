using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootInteraction : MonoBehaviour
{
    [SerializeField]
    private int good;

    [SerializeField]
    private int bad;

    private bool isDead;

    public GameManager gameManager;
    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        isDead = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("good")) {
            if(!isDead)
            { 
                gameManager.bonusBin += 50;
                isDead = true;
                StartCoroutine(SelfDestruct(collision.gameObject));
            }
        }
        else if (collision.gameObject.CompareTag("bad")) {
            if (!isDead)
            {
                gameManager.bonusBin -= 50;
                isDead = true;
                StartCoroutine(SelfDestruct(collision.gameObject));
            }
        }
    }
    IEnumerator SelfDestruct(GameObject gameobject) {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameobject);
    }
}
