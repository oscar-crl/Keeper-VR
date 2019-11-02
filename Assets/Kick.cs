using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {

    // Use this for initialization
    public float WaitTime;
    private GameObject GoalScoredObj;
	void Start () {
        StartCoroutine(Wait());
        GoalScoredObj = GameObject.Find("/Goal Scored");
    }
	
    IEnumerator Wait()
    {
        Vector3 position = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(-15.0f, -10.0f));
        this.GetComponent<Transform>().position = position;
        yield return new WaitForSeconds(WaitTime);
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000.0f);
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200.0f);
    }

	// Update is called once per frame
	void Update () {
        if (GoalScoredObj.activeSelf == false)
            Destroy(this.gameObject);
	}
}
