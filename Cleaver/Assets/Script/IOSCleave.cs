using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOSCleave : MonoBehaviour
{
    public Rigidbody2D ri;

    public GameObject line;
    Line activeLine;

    Vector2 touchPos;

    // Use this for initialization
    void Start()
    {
        ri.velocity = new Vector2(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            if (activeLine == null)
            {
                GameObject lineGO = Instantiate(line, touchPos, Quaternion.identity);
                activeLine = lineGO.GetComponent<Line>();
            }

            else
            {
                activeLine.UpdateLine(touchPos);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                activeLine = null;
            }
        }


        #region MouseVersion
        if (Input.GetMouseButton(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (activeLine == null)
            {
                GameObject lineGO = Instantiate(line);
                activeLine = lineGO.GetComponent<Line>();
            }

            else
            {
                activeLine.UpdateLine(touchPos);
            }

            activeLine.explosvie = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine.explosvie = false;
            activeLine = null;
        }

        #endregion

    }
}
