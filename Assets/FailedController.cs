using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedController : MonoBehaviour
{

    public GameObject failedoption;
    public Animator failed;

    // Start is called before the first frame update
    void Start()
    {
        failedoption = GameObject.Find("Failed");
        failed = failedoption.GetComponent<Animator>();
        failed.speed = 0f;
    }

    public void Failed()
    {

        //StartCoroutine(Coroutine());
        failed.speed = 1f;
    }

    public void Finished()
    {
        failed.speed = 0f;
    }

    public void Done()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

}
