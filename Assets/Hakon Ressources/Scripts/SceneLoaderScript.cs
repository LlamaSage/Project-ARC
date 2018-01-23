using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour {

    public int loadSceneIndex;
    private float startTime = 0;
    private Quaternion startRotation;

    public void Start()
    {
        startRotation = transform.rotation;
    }

    public void OnMouseDown()
    {
        startTime = Time.time;
    }

    public void OnMouseUp()
    {
        Debug.Log("UP at " + (Time.time - startTime));
        if(Time.time - startTime >= 1.0f)
        {
            SceneManager.LoadScene(loadSceneIndex);
        }
        else
        {
            transform.rotation = startRotation;
        }
    }

    public void LoadSceneDirectly()
    {
        SceneManager.LoadScene(loadSceneIndex);
    }

    public void OnMouseDrag()
    {
        if(Time.time - startTime < 1.0f)
        {
            
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
