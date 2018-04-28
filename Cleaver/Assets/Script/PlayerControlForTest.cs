using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlForTest : MonoBehaviour
{

    // Just for test!!!

    public Transform playerTran;
    public float speed;

    // Use this for initialization
    void Start()
    {
        playerTran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTran.Translate(new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0));
    }
}
