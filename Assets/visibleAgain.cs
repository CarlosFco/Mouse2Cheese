using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class visibleAgain : MonoBehaviour
{
    public static GameObject waypoint3;
    public static GameObject character;

    public GameObject doneBtn;

    // Start is called before the first frame update
    void Start()
    {
        doneBtn = GameObject.Find("doneBtn");
        character = GameObject.Find("character");
        waypoint3 = GameObject.Find("Waypoint3");
    }

    // Update is called once per frame
    void Update()
    {
        if(compare(waypoint3, character))
            doneBtn.SetActive(true);
    }

    public bool compare(GameObject way, GameObject charac)
    {
        if (((charac.transform.position.x <= way.transform.position.x + 0.5f) &&
            (charac.transform.position.x >= way.transform.position.x - 0.5f)) &&
            (charac.transform.position.y <= way.transform.position.y + 0.5f) &&
            (charac.transform.position.y >= way.transform.position.y - 0.5f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
