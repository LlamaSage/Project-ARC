using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationsScript : MonoBehaviour {

    private Vector3 previousPos;
    private bool isTracking = false;
    private float previousX, previousY;
    private bool isRotating = false;
    public float rotationStrengthVertical, rotationStrengthHorizontal;
    public float upScale;
    private Quaternion previousRotation;
    public float distanceToCameraOnFocus;

    public void Start()          //original coordinates and rotation are saved when the object becomes active
    {
        previousPos = transform.position;
        previousRotation = transform.rotation;
        
    }

    public void OnMouseDown()               //intercepts a mousclick *on* the object
    {
        if(isTracking)                      //did we already move this into focus?
            isRotating = true;              //if so start rotating it
        previousX = Input.mousePosition.x;  //saving original mousePositions
        previousY = Input.mousePosition.y;  //important to calculate the later rotation without "jumps"
    }

    public void Update()
    {
        if(isTracking)                      //is an object supposed to be focused?
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane+distanceToCameraOnFocus));     //then keep moving it into the center (focus) of the camera + a small offset in front

        if (Input.GetMouseButtonDown(0) && isTracking)      //general mouseclick event while the object was already focused - need this her to terminate focus
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))              //casting a ray from camera to mouseclick, did we hit anything?
            {


                if (hit.collider.gameObject == this.gameObject)     //we hit our gameobject with this script
                {
                    // do something, maybe. currently not
                }
                else        //we hit *another* object, but not our gameobject, terminate focus
                {
                    isTracking = false;
                    transform.localScale /= upScale;
                    transform.position = previousPos;

                }
            }
            else            //we hit no object whatsoever, terminate focus
            {
                isTracking = false;
                transform.localScale /= upScale;
                transform.position = previousPos;
            }
        }

    }

    public void OnMouseUp()     //things that happen when you *remove* the touch
    {
        if (!isTracking)        //are we NOT focusing right now?
        {
            isTracking = true;  //then lets focus
            transform.localScale *= upScale;
        }
        if (isRotating)         //are we rotating right now?
        {
            transform.rotation = previousRotation;      //then reverse the rotation and let the object settle into original rotation
            isRotating = false;
        }
    }

   

    public void OnMouseDrag()   //when you touch on the object but dont let go and move the touch
    {
        if(isTracking)          //are we already focusing?
        {                       //then lets rotate!
            transform.Rotate(new Vector3(rotationStrengthVertical*(Input.mousePosition.y - previousY), 0, -1 * rotationStrengthHorizontal*(Input.mousePosition.x - previousX)));
        }
        previousX = Input.mousePosition.x;  //NEVER forget to reset your mouse position after applying it. otherwise it stacks up, fast.
        previousY = Input.mousePosition.y;
    }
    

}
