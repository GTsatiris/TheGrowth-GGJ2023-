using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int level = 2;
    public float timePassed;
    public float startTime;
    public float timeBudget;
    public float bonusBin;
    public float maxTime;
    public float food;

    public int pointsPerSecond;

    public float levelOneMult = 0.5f;
    public float levelTwoMult = 1f;
    public float levelThreeMult = 2f;

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;

    public GameObject Camera;
    public GameObject TreeUI;
    public Image health;
    public TMP_Text score;
    public GameObject Canvas;
    private float startOfTimer;

    private bool timeStarted;
    private float levelMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        timeStarted = false;
        timeBudget = startTime;
        bonusBin = 0;
        levelMultiplyer = levelTwoMult;
        StartCoroutine("StartCameraFollow");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("IntroScene");
        }
        
        if (timeStarted)
        {
            timePassed = Time.time - startOfTimer;
            //timePassed = (Time.time - startTime) * -1;

            timeBudget = startTime - timePassed + bonusBin;

            Level();
            Score();
            health.fillAmount = timeBudget / maxTime;
            score.text = Mathf.RoundToInt(food).ToString();
        }
    }

    public void Level()
    {
        if (timeBudget <= 60)
        {
            level = 1;
            levelMultiplyer = levelOneMult;
            tree1.SetActive(true);
            tree2.SetActive(false);
            tree3.SetActive(false);
        }
        else if ((timeBudget > 60) && (timeBudget <= 120))
        {
            level = 2;
            levelMultiplyer = levelTwoMult;
            tree1.SetActive(false);
            tree2.SetActive(true);
            tree3.SetActive(false);
        }
        else
        {
            level = 3;
            levelMultiplyer = levelThreeMult;
            tree1.SetActive(false);
            tree2.SetActive(false);
            tree3.SetActive(true);
        }
        if (timeBudget <= 0)
        {
            SceneManager.LoadScene("IntroScene");
        }
        if (timeBudget >= maxTime)
        {
            timeBudget = maxTime;
        }
    }

    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            food += pointsPerSecond * levelMultiplyer;
        }
    }

    IEnumerator StartCameraFollow()
    {
        yield return new WaitForSeconds(2.0f);

        CameraController cc = Camera.GetComponent<CameraController>();
        cc.enabled = true;
        TreeUI.SetActive(true);
        Canvas.SetActive(true);
        startOfTimer = Time.time;
        timeStarted = true;
        StartCoroutine("Score");
    }
}
