using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GeneralController : MonoBehaviour
{

    public static GameObject[] directions;
    public static int[] nmovements;
    public static int[] solution2;
    public static string sceneName;

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
    public static Sprite left;
    public static Sprite right;


    public static GameObject doneBtn;   //the green one
    public Button done;

    public static GameObject readyBtn; //the orange one
    public Button ready;

    public static GameObject upBtn;
    public static Button upInter;

    public static GameObject leftBtn;
    public static Button leftInter;

    public static GameObject rightBtn;
    public static Button rightInter;

    public static bool launchFireworks;

    // Start is called before the first frame update
    void Start()
    {

        nmovements = new int[12];
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

        solution2 = new int[12] { 0, 1, 0, 3, 0, 0, 3, 0, -1, -1, -1, -1 };

        sceneName = SceneManager.GetActiveScene().name;

        doneBtn = GameObject.Find("Canvas/doneBtn");
        done = doneBtn.GetComponent<Button>();
        done.interactable = false;

        readyBtn = GameObject.Find("Canvas/readyBtn");
        ready = readyBtn.GetComponent<Button>();

        upBtn = GameObject.Find("Canvas/upBtn");
        upInter = upBtn.GetComponent<Button>();

        leftBtn = GameObject.Find("Canvas/leftBtn");
        leftInter = leftBtn.GetComponent<Button>();

        rightBtn = GameObject.Find("Canvas/rightBtn");
        rightInter = rightBtn.GetComponent<Button>();

        up = Resources.Load<Sprite>("UpPNG");
        left = Resources.Load<Sprite>("rotatePNG");
        right = Resources.Load<Sprite>("rotateReversePNG");

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

        launchFireworks = false;
    }

    public void MoveUp()
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

    public void MoveLeft()
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

    public void MoveRight()
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

    public void CheckSolution()
    {
        bool sol = true;
		switch (sceneName)
		{
            case "Level2Scene":
                for (int i = 0; i < 12; i++)
                {
                    if (nmovements[i] != solution2[i])
                        sol = false;
                }

                if (sol)
                {
                    upInter.interactable = false;
                    leftInter.interactable = false;
                    rightInter.interactable = false;
                    done.interactable = true;
                    ready.interactable = false;
                    launchFireworks = true;
                    
                    Debug.Log(rightInter.interactable == true);
                }
			    else
				{
                    AnimationController.lauchLevelFailed = true;
                    for (int i = 0; i < directions.Length; i++)
                        directions[i].GetComponent<SpriteRenderer>().sprite = null;
                    for (int i = 0; i < nmovements.Length; i++)
                        nmovements[i] = -1;
                }
                break;
        }
        

    }
}
