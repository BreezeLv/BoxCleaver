using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour {

    public GameObject FailFX;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Line")
        {
            if (other.gameObject.GetComponent<Line>().explosvie)
            {
                Fail();
            }
        }
    }

    void Fail()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;
        Instantiate(FailFX, transform.position, Quaternion.identity);
    }
}
