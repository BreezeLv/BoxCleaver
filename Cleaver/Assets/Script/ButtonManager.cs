using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Button>().onClick.AddListener(btnOnClick);
	}

    void btnOnClick()
    {
        if (name == "btn_Start")
        {
            EditorSceneManager.LoadScene("Main");
        }
        if (name == "btn_home")
        {
            EditorSceneManager.LoadScene("UIMenu");
        }
    }
}
