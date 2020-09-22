using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject firework1;
    public GameObject firework2;
    public GameObject firework3;
    public GameObject firework4;

    public Animator fire1;
    public Animator fire2;
    public Animator fire3;
    public Animator fire4;


    // Start is called before the first frame update
    void Start()
    {
        firework1 = GameObject.Find("firework1");
        firework2 = GameObject.Find("firework2");
        firework3 = GameObject.Find("firework3");
        firework4 = GameObject.Find("firework4");

        fire1 = firework1.GetComponent<Animator>();
        fire2 = firework2.GetComponent<Animator>();
        fire3 = firework3.GetComponent<Animator>();
        fire4 = firework4.GetComponent<Animator>();

        fire1.speed = 0f;
        fire2.speed = 0f;
        fire3.speed = 0f;
        fire4.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstLevelControls.launchFireworks)
		{
            fire1.speed = 1f;
            fire2.speed = 1f;
            fire3.speed = 1f;
            fire4.speed = 1f;
        }
    }
}
