using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScored : MonoBehaviour {

    private int Goals = 3;
    public Text TimeGame;
    public Text Life;
    public GameObject Spawn;
    public GameObject StartButton;
    public GameObject CountdownObj;
    public GameObject StartCanvas;
    public AudioSource Whistle;

    private float StartTime;
    private void Start()
    {
        StartTime = Time.time;
        Goals = 3;
        Spawn.SetActive(true);
    }

    private void Update()
    {
        float t = Time.time - StartTime;

        if (this.tag == "Reset")
        {
            StartTime = Time.time;
            Goals = 3;
            Life.text = "Goal left : 3";
            Spawn.SetActive(true);
            this.tag = "Untagged";
        }
        if (Goals > 0)
        {
            string min = ((int)t / 60).ToString();
            string sec = (t % 60).ToString("f0");
            TimeGame.text = "Time : " + min + "m " + sec + "s";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Goal")
        {
            other.tag = "Goal";
            Whistle.Play();
        } 
        else
            return;
        Debug.Log("Goal scored");
        Goals -= 1;
        if (Goals >= 0)
            Life.text = "Goal left : " + Goals.ToString();
        if (Goals == 0)
        {
            Debug.Log("You lose!");
            Spawn.SetActive(false);
            CountdownObj.GetComponent<Text>().text = "";
            CountdownObj.SetActive(true);
            StartButton.SetActive(true);
            StartCanvas.GetComponent<BoxCollider>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
