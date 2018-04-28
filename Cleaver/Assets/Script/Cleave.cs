using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleave : MonoBehaviour
{

    public GameObject bar;
    public GameObject FailFX;
    public Rigidbody2D ri;
    int timesChecker = 0;
    Vector3 mousePos1;
    Vector3 mousePos2;
    Transform hitTran1;
    Transform hitTran2;

    // Use this for initialization
    void Start()
    {
        ri.velocity = new Vector2(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //first click
        if (Input.GetMouseButtonDown(0) && timesChecker == 0)
        {
            timesChecker++;

            mousePos1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //second click
        else if (Input.GetMouseButtonDown(0) && timesChecker == 1)
        {
            timesChecker--;

            mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = new Vector2(mousePos2.x - mousePos1.x, mousePos2.y - mousePos1.y);
            Ray2D ray = new Ray2D(new Vector2(mousePos1.x, mousePos1.y), dir);      //Camera.main.ScreenPointToRay()
            RaycastHit2D[] rayHits = Physics2D.RaycastAll(ray.origin, ray.direction);

            Debug.Log(rayHits[0].point);
            Debug.Log(rayHits[1].point);

            //if (rayHits[0].collider.tag == "Player")
            //{
            //    FailGame(rayHits[0].collider.gameObject);
            //}

            if (rayHits[1].collider.tag == "Player")
            {
                FailGame(rayHits[1].collider.gameObject);

                //case player in the middle
                if (rayHits[0].collider.tag == "Bar" && rayHits[2].collider.tag == "Bar")
                {
                    TwoPointCleave(rayHits, 0, 2);
                }
            }

            //case no player intercepted
            else if (rayHits[0].collider.tag == "Bar" && rayHits[1].collider.tag == "Bar")
            {
                TwoPointCleave(rayHits, 0, 1);
            }
        }

    }


    public void FailGame(GameObject player)
    {
        Rigidbody2D rigi = player.GetComponent<Rigidbody2D>();
        rigi.Sleep();
        Collider2D co = player.GetComponent<Collider2D>();
        co.enabled = false;

        Instantiate(FailFX, player.transform.position, player.transform.rotation);
    }

    void TwoPointCleave(RaycastHit2D[] rayHits, int i1, int i2)
    {
        hitTran1 = rayHits[i1].transform;
        hitTran2 = rayHits[i2].transform;

        print((mousePos2.y - mousePos1.y) / (mousePos2.x - mousePos1.x));
        Quaternion crossAngel = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan((mousePos2.y - mousePos1.y) / (mousePos2.x - mousePos1.x)));
        print(crossAngel);
        Instantiate(bar, (rayHits[i1].point + rayHits[i2].point) / 2f, crossAngel);
    }
}
