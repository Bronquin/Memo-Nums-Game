using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public int timeLeft;
    public Text countdownText;
	void Start () {
        StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
        countdownText.text = ("Time Left = " + timeLeft);
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up";
            Time.timeScale = 0;
        }
	}

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
