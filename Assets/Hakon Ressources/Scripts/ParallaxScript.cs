using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ParallaxScript : MonoBehaviour {

    public Camera cam;
    public GameObject[] objects;
    public float[] objectsEffect;
    private Vector3 previousCamPos;

    private void Start()
    {
        previousCamPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("Camera Position: " + cam.transform.position.x + " " + cam.transform.position.y + " " + cam.transform.position.z);
        Debug.Log("Object Position: "+ objects[0].transform.position.x + " " + objects[0].transform.position.y + " " + objects[0].transform.position.z);
        Vector3 transl = previousCamPos;
        transl.x = transl.x - cam.transform.position.x;
        transl.x = transl.x * objectsEffect[0];
        transl.y = 0;
        transl.z = 0;
        //transl.y = transl.y * 5;
        //transl.z = transl.z * 5;
        objects[0].transform.Translate(transl);
        previousCamPos = cam.transform.position;
	}
}
