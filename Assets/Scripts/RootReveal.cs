using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootReveal : MonoBehaviour
{
    public float revealTime = 1.0f;
    public int verticalSteps = 10;

    private SpriteRenderer spriteRenderer;
    private Vector2 originalSize;
    private float elapsedTime;
    private Material material;
    private Color originalColor;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSize = spriteRenderer.size;
        spriteRenderer.size = new Vector2(originalSize.x, 0);
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }
    private void Start() {

        StartCoroutine(Reveal());
    }
    private void Update() {
        //Debug.Log(elapsedTime);
    }
    private IEnumerator Reveal() {
        elapsedTime = 0.0f;
        while (elapsedTime < revealTime) {
            material.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(0, originalColor.a, elapsedTime / revealTime));
            spriteRenderer.size = new Vector2(originalSize.x, Mathf.Lerp(0, originalSize.y, elapsedTime / revealTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.size = originalSize;
    }
}
