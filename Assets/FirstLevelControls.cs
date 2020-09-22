using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevelControls : MonoBehaviour
{

    public static GameObject[] directions;
    public static Sprite up;
    public static int[] nmovements;

    public static Sprite left;

    public static GameObject direction1;
    public static GameObject direction2;
    public static GameObject direction3;
    public static GameObject direction4;
    public static GameObject direction5;
    public static GameObject direction6;
    public static GameObject direction7;
    public static GameObject direction8;
    public static GameObject direction9;

    public Button upInter;             //to make the butons not interactables for tutorial
    public Button leftInter;
    public Button rightInter;

    public GameObject upBtn;
    public GameObject leftBtn;
    public GameObject rightBtn;

    public static int[] secondStep;
    public static int[] thirdStep;
    public static int[] fourthStep;
    public static int[] solution;

    public Animator anim;
    public static GameObject character;

    public static GameObject doneBtn;   //the green one
    public Button done;

    public static GameObject readyBtn; //the orange one
    public Button ready;

    public static bool launchFireworks;

    private void Start()
	{
        direction1 = GameObject.Find("direction1");
        direction2 = GameObject.Find("direction2");
        direction3 = GameObject.Find("direction3");
        direction4 = GameObject.Find("direction4");
        direction5 = GameObject.Find("direction5");
        direction6 = GameObject.Find("direction6");
        direction7 = GameObject.Find("direction7");
        direction8 = GameObject.Find("direction8");
        direction9 = GameObject.Find("direction9");

        directions = new GameObject[9];
        directions[0] = direction1;
        directions[1] = direction2;
        directions[2] = direction3;
        directions[3] = direction4;
        directions[4] = direction5;
        directions[5] = direction6;
        directions[6] = direction7;
        directions[7] = direction8;
        directions[8] = direction9;

        for (int i = 0; i < directions.Length; i++)
        {
            var x = directions[i].GetComponent<SpriteRenderer>();
            x = null;
        }

        up = Resources.Load<Sprite>("UpPNG");
        left = Resources.Load<Sprite>("rotatePNG");

        nmovements = new int[10];
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

        upBtn = GameObject.Find("Canvas/upBtn");
        upInter = upBtn.GetComponent<Button>();

        leftBtn = GameObject.Find("Canvas/leftBtn");
        leftInter = leftBtn.GetComponent<Button>();
        leftInter.interactable = false;

        rightBtn = GameObject.Find("Canvas/rightBtn");
        rightInter = rightBtn.GetComponent<Button>();
        rightInter.interactable = false;

        secondStep = new int[10] { 0, 0, -1, -1, -1, -1, -1, -1, -1, -1 };
        thirdStep = new int[10] { 0, 0, 1, -1, -1, -1, -1, -1, -1, -1 };
        fourthStep = new int[10] { 0, 0, 1, 0, -1, -1, -1, -1, -1, -1 };
        solution = new int[10] { 0, 0, 1, 0, -1, -1, -1, -1, -1, -1 };

        character = GameObject.Find("character");
        anim = character.GetComponent<Animator>();
        anim.speed = 0f;

        doneBtn = GameObject.Find("Canvas/doneBtn");
        done = doneBtn.GetComponent<Button>();
        done.interactable = false;

        readyBtn = GameObject.Find("Canvas/readyBtn");
        ready = readyBtn.GetComponent<Button>();

        launchFireworks = false;
    }

    public void UpBtnClick()
    {
        int i = 0;
        while (directions[i].GetComponent<SpriteRenderer>().sprite != null)
            i++;

        if (i <= directions.Length)
        {
            var x = directions[i].GetComponent<SpriteRenderer>();
            x.sprite = up;
        }

        int j = 0;
        while (nmovements[j] != -1)
            j++;
        if (j <= nmovements.Length)
            nmovements[j] = 0;

        bool isSecond = true;
        bool isFourth = true;

        for (int k = 0; k < nmovements.Length; k++)
        {
            if (nmovements[k] != secondStep[k])
                isSecond = false;
        }
        for (int l = 0; l < nmovements.Length; l++)
        {
            if (nmovements[l] != fourthStep[l])
                isFourth = false;
        }
        if (isSecond)
        {
            upInter.interactable = false;
            leftInter.interactable = true;
        }
        else if (isFourth)
            upInter.interactable = false;
    }

    public void LeftBtnClick()
    {
        int i = 0;
        while (directions[i].GetComponent<SpriteRenderer>().sprite != null)
            i++;

        if (i <= directions.Length)
        {
            var x = directions[i].GetComponent<SpriteRenderer>();
            x.sprite = left;
        }

        int j = 0;
        while (nmovements[j] != -1)
            j++;
        if (j <= nmovements.Length)
            nmovements[j] = 1;

        bool isThird = true;

        for (int k = 0; k < nmovements.Length; k++)
        {
            if (nmovements[k] != thirdStep[k])
                isThird = false;
        }
        if (isThird)
        {
            upInter.interactable = true;
            leftInter.interactable = false;
        }
    }

    public void CheckSolution()
	{
        bool sol = true;
        for (int i = 0; i < 10; i++)
        {
            if (nmovements[i] != solution[i])
                sol = false;
        }

        if (sol)
		{
            anim.speed = 3f;
            done.interactable = true;
            ready.interactable = false;
            launchFireworks = true;
        }

    }

}
