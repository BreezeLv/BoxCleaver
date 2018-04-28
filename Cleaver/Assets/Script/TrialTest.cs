using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialTest : MonoBehaviour {

    public Transform tran;
	// Use this for initialization
	void Start () {
        tran = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            tran.position = mousePos;
        }
	}

}
