using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedController : MonoBehaviour
{

    public GameObject failedoption;
    public Animator failed;

    public GameObject doneoption;
    public Animator done;

    // Start is called before the first frame update
    void Start()
    {
        failedoption = GameObject.Find("Failed");
        failed = failedoption.GetComponent<Animator>();
        failed.speed = 0f;

        doneoption = GameObject.Find("Done");
        done = doneoption.GetComponent<Animator>();
        done.speed = 0f;
    }

    public void Failed()
    {
        failed.speed = 1f;
    }

    public void Done()
    {
        done.speed = 1f;
    }

    public void Finished()
    {
        failed.speed = 0f;
    }

    public void LevelDone()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

}
