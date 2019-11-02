using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public Text Countdown;
    public GameObject StartButton;
    public GameObject CountdownObj;
    public GameObject GoalScored;
    IEnumerator Wait()
    {
        Countdown.text = "3";
        yield return new WaitForSeconds(1);
        Countdown.text = "2";
        yield return new WaitForSeconds(1);
        Countdown.text = "1";
        yield return new WaitForSeconds(1);
        Countdown.text = "Let's go!";
        yield return new WaitForSeconds(1);
        CountdownObj.SetActive(false);
        GoalScored.SetActive(true);
        GoalScored.tag = "Reset";
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Start");
        StartButton.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Wait());
    }
}
