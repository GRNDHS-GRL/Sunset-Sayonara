using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    public GameObject myCycle;

    // Start is called before the first frame update
    void Start()
    {
        myCycle = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();

        //this is for shutting the car down once the timer limit is reached. figure out how to disable the script but keep the car and camera
        if (currentTime == timerLimit)
        {
           // myCycle.enabled = false;
        }
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
}
