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
    public float startTime = 100;
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

    // Start is called before the first frame update
    void Start()
    {
        timeStarted = false;
        timeBudget = startTime;
        bonusBin = 0;
        StartCoroutine("StartCameraFollow");
    }

    // Update is called once per frame
    void Update()
    {
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
        }
        else if ((timeBudget > 60) && (timeBudget <= 120))
        {
            level = 2;
        }
        else
        {
            level = 3;
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

    public void Score()
    {
        if (level == 1)
        {
            food = (Time.time - startOfTimer) * (pointsPerSecond * levelOneMult);
            tree1.SetActive(true);
            tree2.SetActive(false);
            tree3.SetActive(false);

        }
        else if (level == 2)
        {
            food = (Time.time - startOfTimer) * (pointsPerSecond * levelTwoMult);
            tree1.SetActive(false);
            tree2.SetActive(true);
            tree3.SetActive(false);
        }
        else if (level == 3)
        {
            food = (Time.time - startOfTimer) * (pointsPerSecond * levelThreeMult);
            tree1.SetActive(false);
            tree2.SetActive(false);
            tree3.SetActive(true);
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
    }
}
