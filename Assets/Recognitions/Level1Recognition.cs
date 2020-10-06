using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class Level1Recognition : MonoBehaviour, ITrackableEventHandler
{

    TrackableBehaviour mTrackableBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            print("DETECTA");
            SceneManager.LoadScene("Level1Scene", LoadSceneMode.Single);
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            print("PIERDE");
        }
    }

}
