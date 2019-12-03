﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    public static GameObject[] directions;
    public static int[] nmovements;

    public static int[] solution2;

    public static Text texto;

    public static GameObject character;
    public static GameObject goal;

    public static GameObject direction1;
    public static GameObject direction2;
    public static GameObject direction3;
    public static GameObject direction4;
    public static GameObject direction5;
    public static GameObject direction6;
    public static GameObject direction7;
    public static GameObject direction8;
    public static GameObject direction9;

    public static Sprite up;
    public static Sprite down;
    public static Sprite left;
    public static Sprite right;

    public static GameObject doneBtn;   //the green one
    public Button done;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        character = GameObject.Find("character");
        goal = GameObject.Find("goal");

        nmovements = new int[10];
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

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

        up = Resources.Load<Sprite>("UpPNG");
        down = Resources.Load<Sprite>("DownPNG");
        left = Resources.Load<Sprite>("rotatePNG");
        right = Resources.Load<Sprite>("rotateReversePNG");

        doneBtn = GameObject.Find("Canvas/doneBtn");
        done = doneBtn.GetComponent<Button>();
        done.interactable = false;

        texto = GameObject.Find("Canvas/Text").GetComponent<Text>();

        solution2 = new int[10] { 0, 1, 0, 3, 0, 0, 3, 0, -1, -1 };

    }

    // Update is called once per frame
    void Update()
    {
        texto.text = (right == null).ToString();
    }

    public void UpDir()
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
    }

    public void LeftDir()
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
    }

    public void DownDir()
    {
        int i = 0;
        while (directions[i].GetComponent<SpriteRenderer>().sprite != null)
            i++;
       
        if (i <= directions.Length)
        {
            var x = directions[i].GetComponent<SpriteRenderer>();
            x.sprite = down;
        }
        int j = 0;
        while (nmovements[j] != -1)
            j++;
        if (j <= nmovements.Length)
            nmovements[j] = 2;
    }

    public void RightDir()
    {
        int i = 0;
        while (directions[i].GetComponent<SpriteRenderer>().sprite != null)
            i++;

        if (i <= directions.Length)
        {
            var x = directions[i].GetComponent<SpriteRenderer>();
            x.sprite = right;
        }
        int j = 0;
        while (nmovements[j] != -1)
            j++;
        if (j <= nmovements.Length)
            nmovements[j] = 3;
    }

    public void Moving()
    {
        Boolean x = true;
        for(int i = 0; i < nmovements.Length; i++)
        {
            if (nmovements[i] != solution2[i])
                x = false;
        }

        if (x)
        {
            float distance = goal.transform.position.y - character.transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                goal.transform.position, distance);
            character.transform.position.Set(goal.transform.position.x,
                goal.transform.position.y, goal.transform.position.z);
        }
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

        for (int i = 0; i < directions.Length; i++)
        {
            directions[i].GetComponent<SpriteRenderer>().sprite = null;
        }

    }

    public bool Compare(GameObject way, GameObject charac)
    {
        if (((charac.transform.position.x <= way.transform.position.x + 1.0f) &&
            (charac.transform.position.x >= way.transform.position.x - 1.0f)) &&
            (charac.transform.position.y <= way.transform.position.y + 1.0f) &&
            (charac.transform.position.y >= way.transform.position.y - 1.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
