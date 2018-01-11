using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FlipTrackingScript : MonoBehaviour
{
    private void Start()
    {
        VuforiaBehaviour.Instance.enabled = false;
    }

    public void changeTracking(bool track)
    {
        VuforiaBehaviour.Instance.enabled = track;
    }
}
