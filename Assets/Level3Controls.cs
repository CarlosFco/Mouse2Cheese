﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Controls : MonoBehaviour
{
    public static GameObject[] directions;
    public static int[] nmovements;

    public static int[] solution2;
    public static int[] solution3;
    public static int[] solution4;
    public static int[] solution5;
    public static int[] solution6;

    public static Text texto;

    public static GameObject character;
    public static GameObject goal;
    public static Animator anim;

    public static GameObject direction1;
    public static GameObject direction2;
    public static GameObject direction3;
    public static GameObject direction4;
    public static GameObject direction5;
    public static GameObject direction6;
    public static GameObject direction7;
    public static GameObject direction8;
    public static GameObject direction9;
    public static GameObject direction10;
    public static GameObject direction11;
    public static GameObject direction12;


    public static Sprite up;
    public static Sprite down;
    public static Sprite left;
    public static Sprite right;

    public static GameObject doneBtn;   //the green one
    public Button done;

    public static GameObject readyBtn;
    public Button ready;

    public static GameObject upBtn;
    public Button upInter;

    public static GameObject downBtn;
    public Button downInter;

    public static GameObject leftBtn;
    public Button leftInter;

    public static GameObject rightBtn;
    public Button rightInter;

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
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        character = GameObject.Find("character");
        goal = GameObject.Find("goal");
        anim = character.GetComponent<Animator>();
        anim.speed = 0f;

        nmovements = new int[12];
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
        direction10 = GameObject.Find("direction10");
        direction11 = GameObject.Find("direction11");
        direction12 = GameObject.Find("direction12");

        directions = new GameObject[12];
        directions[0] = direction1;
        directions[1] = direction2;
        directions[2] = direction3;
        directions[3] = direction4;
        directions[4] = direction5;
        directions[5] = direction6;
        directions[6] = direction7;
        directions[7] = direction8;
        directions[8] = direction9;
        directions[9] = direction10;
        directions[10] = direction11;
        directions[11] = direction12;

        up = Resources.Load<Sprite>("UpPNG");
        down = Resources.Load<Sprite>("DownPNG");
        left = Resources.Load<Sprite>("rotatePNG");
        right = Resources.Load<Sprite>("rotateReversePNG");

        doneBtn = GameObject.Find("Canvas/doneBtn");
        done = doneBtn.GetComponent<Button>();
        done.interactable = false;

        readyBtn = GameObject.Find("Canvas/readyBtn");
        ready = readyBtn.GetComponent<Button>();

        texto = GameObject.Find("Canvas/Text").GetComponent<Text>();

        solution2 = new int[12] { 0, 1, 0, 3, 0, 0, 3, 0, -1, -1, -1, -1 };
        solution3 = new int[12] { 0, 3, 0, 1, 0, 3, 0, 1, 0, 3, 0, -1};
        solution4 = new int[12] { 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, -1, -1 };
        solution5 = new int[12] { 1, 0, 3, 0, 3, 0, -1, -1, -1, -1, -1, -1 };
        solution6 = new int[12] { 0, 0, 1, 0, 3, 0, 3, 0, -1, -1, -1, -1 };

        upBtn = GameObject.Find("Canvas/upBtn");
        upInter = upBtn.GetComponent<Button>();
        upInter.interactable = true;

        /*downBtn = GameObject.Find("Canvas/downBtn");
        downInter = downBtn.GetComponent<Button>();
        downInter.interactable = true;*/

        leftBtn = GameObject.Find("Canvas/leftBtn");
        leftInter = leftBtn.GetComponent<Button>();
        leftInter.interactable = true;

        rightBtn = GameObject.Find("Canvas/rightBtn");
        rightInter = rightBtn.GetComponent<Button>();
        rightInter.interactable = true;

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
        float distance = character.transform.position.x - goal.transform.position.x;
        Scene scene = SceneManager.GetActiveScene();

        //texto.text = (anim == null).ToString();
        /*texto.text = solution2[0].ToString() +
            solution2[1].ToString() +
            solution2[2].ToString() +
            solution2[3].ToString() +
            solution2[4].ToString() +
            solution2[5].ToString() +
            solution2[6].ToString() +
            solution2[7].ToString() +
            solution2[8].ToString() +
            solution2[9].ToString() +
            solution2[10].ToString() +
            solution2[11].ToString();*/
        if (Compare(goal, character))
        {
            done.interactable = true;
            ready.interactable = false;

            fire1.speed = 1f;
            fire2.speed = 1f;
            fire3.speed = 1f;
            fire4.speed = 1f; 
        }
        leftBtn = GameObject.Find("Canvas/leftBtn");
        leftInter = leftBtn.GetComponent<Button>();
        leftInter.interactable = true;

        rightBtn = GameObject.Find("Canvas/rightBtn");
        rightInter = rightBtn.GetComponent<Button>();
        rightInter.interactable = true;
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
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "level3Scene")
        {
            for (int i = 0; i < nmovements.Length; i++)
            {
                if (nmovements[i] != solution3[i])
                    x = false;
            }

            if (x)
            {
                float distanceY = goal.transform.position.y - character.transform.position.y;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distanceY);

                float distanceX = goal.transform.position.x - character.transform.position.x;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distanceX);

                //character.transform.position.Set(goal.transform.position.x,
                    //goal.transform.position.y, goal.transform.position.z);
                anim.speed = 3f;
                moveUp.superados = 3;
            }
            
        } else if(scene.name == "level4Scene")
        {
            for (int i = 0; i < nmovements.Length; i++)
            {
                if (nmovements[i] != solution4[i])
                    x = false;
            }
            if (x)
            {
                float distance = character.transform.position.y - goal.transform.position.y;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distance);
                anim.speed = 3f;
                moveUp.superados = 4;
            }
        } else if(scene.name == "Level2Scene")
        {
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
                //character.transform.position.Set(goal.transform.position.x,
                    //goal.transform.position.y, goal.transform.position.z);
                anim.speed = 3f;
                moveUp.superados = 2;
            }
        } else if(scene.name == "Level5Scene")
        {
            for(int i = 0; i < nmovements.Length; i++)
            {
                if(nmovements[i] != solution5[i])
                    x = false;
            }
            if (x)
            {
                float distanceX = goal.transform.position.x - character.transform.position.x;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distanceX);
                float distanceY = goal.transform.position.y - character.transform.position.y;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distanceY);
                anim.speed = 3f;
                moveUp.superados = 5;
            }
        } else if(scene.name == "Level6Scene")
        {
            for(int i = 0; i < nmovements.Length; i++)
            {
                if (nmovements[i] != solution6[i])
                    x = false;
            }
            if (x)
            {
                float distance = goal.transform.position.y - character.transform.position.y;
                character.transform.position = Vector3.MoveTowards(character.transform.position,
                    goal.transform.position, distance);
                anim.speed = 3f;
            }
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
