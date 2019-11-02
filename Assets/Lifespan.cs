using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour {

    public float LifespanTime;
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, LifespanTime);
    }
}
