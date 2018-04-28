using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {


    List<Vector2> points;

    LineRenderer line;
    EdgeCollider2D edgeCol;

    public bool explosvie;
    
    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();
        edgeCol = GetComponent<EdgeCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points[points.Count - 1], mousePos) > .3f)
        {
            SetPoint(mousePos);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, point);

        if (points.Count == 1)
            return;

        edgeCol.points = points.ToArray();
    }
}
