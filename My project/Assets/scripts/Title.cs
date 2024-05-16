using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public string SceneToLoad1;
    public string SceneToLoad2;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            SceneManager.LoadScene(Random.Range(0,2)==0 ? SceneToLoad1 : SceneToLoad2);
        }

    }
}