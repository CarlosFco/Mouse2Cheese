using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedController : MonoBehaviour
{

    public GameObject failedoption;
    public Animator failed;

    public float timer = 0;
    public float timerMax = 0;
    public bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        failedoption = GameObject.Find("Failed");
        failed = failedoption.GetComponent<Animator>();
        failed.speed = 0f;
    }

    private void Update()
    {
        
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

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        failed.speed = 1f;
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        failed.speed = 0f;
        StopAllCoroutines();
        //After we have waited 2 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            reset = true;
            return true; //max reached - waited x - seconds
        }

        return false;
    }
}
