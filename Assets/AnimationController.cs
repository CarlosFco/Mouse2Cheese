using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

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

    public static GameObject failedsolution;
    public static Animator failed;

    public Animator anim;
    public static GameObject character;

    public static bool lauchLevelFailed;


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

        failedsolution = GameObject.Find("FailedLevel");
        failed = failedsolution.GetComponent<Animator>();
        failed.speed = 0f;

        character = GameObject.Find("character");
        anim = character.GetComponent<Animator>();
        anim.speed = 0f;

        lauchLevelFailed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstLevelControls.launchFireworks || GeneralController.launchFireworks)
		{
            fire1.speed = 1f;
            fire2.speed = 1f;
            fire3.speed = 1f;
            fire4.speed = 1f;

            if (SceneManager.GetActiveScene().name != "Level1Scene")
            {
                anim.speed = 3f;
            }
        }

        if (lauchLevelFailed)
		{
            //failed.Play("FailedAnimationLevel", 0, 1f);
            FailedSolution();
            lauchLevelFailed = false;
        }
        FirstLevelControls.launchFireworks = false;
        GeneralController.launchFireworks = false;
    }

    public static void FailedSolution()
    {
        failed.speed = 1f;
    }

    public void ResetAnim()
    {
        failed.speed = 0f;
    }
}
