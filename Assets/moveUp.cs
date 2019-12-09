using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveUp : MonoBehaviour
{
    public static int superados;

    public float movementSpeed = 3.0f;
    public static int[] solution;
    public static int[] firstStep;
    public static int[] secondStep;
    public static int[] thirdStep;
    public static int[] fourthStep;
    public bool isSolution;

    public static GameObject character;

    public static GameObject waypoint1;
    public static GameObject waypoint0;
    public static GameObject waypoint2;
    public static GameObject waypoint3;

    public GameObject upBtn;
    //public GameObject downBtn;
    public GameObject leftBtn;
    public GameObject rightBtn;

    public static GameObject doneBtn;   //the green one
    public Button done;

    public static GameObject readyBtn; //the orange one
    public Button ready;    
    public Button upInter;             //to make the butons not interactables for tutorial
    public Button leftInter;
    //public Button downInter;
    public Button rightInter;

    private int cont;
    public static int[] nmovements;

    //testing in app
    public static Text texto;
    public static Text textoCont;

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
    //public static Sprite down;
    public static Sprite left;
    public static Sprite right;

    public static GameObject[] directions;
    public Animator anim;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        superados = 0;

        solution = new int[10] {0, 0, 1, 0, -1, -1, -1, -1, -1, -1 };
        isSolution = false;
        firstStep = new int[10] { 0, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        secondStep = new int[10] { 0, 0, -1, -1, -1, -1, -1, -1, -1, -1 };
        thirdStep = new int[10] { 0, 0, 1, -1, -1, -1, -1, -1, -1, -1 };
        fourthStep = new int[10] { 0, 0, 1, 0, -1, -1, -1, -1, -1, -1 };

        character = GameObject.Find("character");
        anim = character.GetComponent<Animator>();
        anim.speed = 0f;

        waypoint0 = GameObject.Find("Waypoint0");
        waypoint1 = GameObject.Find("Waypoint1");
        waypoint2 = GameObject.Find("Waypoint2");
        waypoint3 = GameObject.Find("Waypoint3");

        upBtn = GameObject.Find("Canvas/upBtn");
        upInter = upBtn.GetComponent<Button>();

        //downBtn = GameObject.Find("Canvas/downBtn");
        //downInter = downBtn.GetComponent<Button>();
        //downInter.interactable = false;

        leftBtn = GameObject.Find("Canvas/leftBtn");
        leftInter = leftBtn.GetComponent<Button>();
        leftInter.interactable = false;

        rightBtn = GameObject.Find("Canvas/rightBtn");
        rightInter = rightBtn.GetComponent<Button>();
        rightInter.interactable = false;

        doneBtn = GameObject.Find("Canvas/doneBtn");
        done = doneBtn.GetComponent<Button>();
        done.interactable = false;

        readyBtn = GameObject.Find("Canvas/readyBtn");
        ready = readyBtn.GetComponent<Button>();


        cont = 0;
        nmovements = new int[10];
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

        texto = GameObject.Find("Canvas/Text").GetComponent<Text>();
        texto.text = nmovements[0].ToString() +
            nmovements[1].ToString() +
            nmovements[2].ToString() +
            nmovements[3].ToString() +
            nmovements[4].ToString() +
            nmovements[5].ToString() +
            nmovements[6].ToString() +
            nmovements[7].ToString() +
            nmovements[8].ToString() +
            nmovements[9].ToString();
        textoCont = GameObject.Find("Canvas/TextCont").GetComponent<Text>();
        textoCont.text = (up == null).ToString();

        direction1 = GameObject.Find("direction1");
        direction2 = GameObject.Find("direction2");
        direction3 = GameObject.Find("direction3");
        direction4 = GameObject.Find("direction4");
        direction5 = GameObject.Find("direction5");
        direction6 = GameObject.Find("direction6");
        direction7 = GameObject.Find("direction7");
        direction8 = GameObject.Find("direction8");
        direction9 = GameObject.Find("direction9");

        up = Resources.Load<Sprite>("UpPNG");
        //down = Resources.Load<Sprite>("DownPNG");
        left = Resources.Load<Sprite>("rotatePNG");
        right = Resources.Load<Sprite>("rotateReversePNG");

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
    }

    void Update()
   {

        if (Compare(waypoint3, character))
        {
            done.interactable = true;
            ready.interactable = false;
        }
        texto.text = nmovements[0].ToString() +
            nmovements[1].ToString() +
            nmovements[2].ToString() +
            nmovements[3].ToString() +
            nmovements[4].ToString() +
            nmovements[5].ToString() +
            nmovements[6].ToString() +
            nmovements[7].ToString() +
            nmovements[8].ToString() +
            nmovements[9].ToString();
        textoCont.text = (solution == nmovements).ToString();

    }


    public void MoveUpFunc()
    {
        //if (character.transform.position.Equals(waypoint1.transform.position)) //from waypont1 to waypont2
        if (Compare(waypoint1, character))
        {
            float distance = waypoint2.transform.position.y - character.transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                waypoint2.transform.position, distance);
            character.transform.position.Set(waypoint2.transform.position.x,
                waypoint2.transform.position.y, waypoint2.transform.position.z);
        }
        //else if (character.transform.position.Equals(waypoint0.transform.position)) //from waypont0 to waypoint1
        else if (Compare(waypoint0, character))
        {
            float distance = waypoint1.transform.position.y - character.transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                waypoint1.transform.position, distance);
            character.transform.position.Set(waypoint1.transform.position.x,
                waypoint1.transform.position.y, waypoint1.transform.position.z);
        } //there's no more way up
    }

    /*public void MoveDownFunc()
    {
        //if(character.transform.position.Equals(waypoint1.transform.position)) //from waypoint1 to waypoint0
        //{
        if(Compare(waypoint1, character))
        { 
            float distance =character.transform.position.y - waypoint0.transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.position, waypoint0.transform.position,
                distance);
            character.transform.position.Set(waypoint0.transform.position.x,
                waypoint0.transform.position.y, waypoint0.transform.position.z);
        }
        //else if(character.transform.position.Equals(waypoint2.transform.position)) //from waypoint2 to waypoint1
        else if(Compare(waypoint2, character))
        {
            float distance = character.transform.position.y - waypoint1 .transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.transform.position,
                waypoint1.transform.position, distance);
            character.transform.position.Set(waypoint1.transform.position.x, waypoint1.transform.position.y,
                waypoint1.transform.position.z);
        } //there's no more way down
    }*/

    public void MoveLeftFunc()
    {
        //if (character.transform.position.Equals(waypoint2.transform.position)) //from waypoint2 to waypoint3
        //{
        if(Compare(waypoint2, character))
        {
            float distance = character.transform.position.x - waypoint3.transform.position.x;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                waypoint3.transform.position, distance);
            character.transform.position.Set(waypoint3.transform.position.x, waypoint3.transform.position.y,
                waypoint3.transform.position.z);
        }//only one way left
    }

    public void MoveRightFunc()
    {
        if (Compare(waypoint3, character))
        {
            float distance = waypoint2.transform.position.x - character.transform.position.x;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                waypoint2.transform.position, distance);
            character.transform.position.Set(waypoint2.transform.position.x, waypoint2.transform.position.y,
                waypoint2.transform.position.z);
        }//only one way right and nonsense
    }

    public bool Compare(GameObject way, GameObject charac)
    {
        if(((charac.transform.position.x <= way.transform.position.x + 1.0f) &&
            (charac.transform.position.x >= way.transform.position.x -1.0f)) &&
            (charac.transform.position.y <= way.transform.position.y +1.0f) &&
            (charac.transform.position.y >= way.transform.position.y -1.0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LevelDone()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

    public void MoveGeneral()
    {
        foreach(int v in nmovements)
        {
            switch (v)
            {
                case 0:
                    MoveUpFunc();
                    break;
                case 1:
                    MoveLeftFunc();
                    break;
                /*case 2:
                    MoveDownFunc();
                    break;*/
                case 3:
                    MoveRightFunc();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        int sol = 0;
        for (int i = 0; i < 10; i++)
        {
            if (nmovements[i] != solution[i])
                sol = 1;
        }
        if (sol == 0)
            isSolution = true;
        if (!isSolution)
        {
            float distance = character.transform.position.y - waypoint0.transform.position.y;
            character.transform.position = Vector3.MoveTowards(character.transform.position,
                waypoint0.transform.position, distance);
            character.transform.position.Set(waypoint0.transform.position.x,
                waypoint0.transform.position.y, waypoint0.transform.position.z);
        }
        else
        {
            anim.speed = 3f;
            superados = 1;
        }
        for (int i = 0; i < nmovements.Length; i++)
            nmovements[i] = -1;

        for (int i = 0; i < directions.Length; i++)
        {
            directions[i].GetComponent<SpriteRenderer>().sprite = null;
        }

        //if (!Compare(character, waypoint3))
        
    }

    public void UpBtnClick()
    {
        int i = 0;
        while (directions[i].GetComponent<SpriteRenderer>().sprite != null)
            i++;

        if(i <= directions.Length){
            var x = directions[i].GetComponent<SpriteRenderer>();
            x.sprite = up;
        }
        
        int j = 0;
        while (nmovements[j] != -1)
            j++;
        if(j <= nmovements.Length)
            nmovements[j] = 0;

        bool isSecond = true;
        bool isFourth = true;

        for(int k = 0; k < nmovements.Length; k++)
        {
            if (nmovements[k] != secondStep[k])
                isSecond = false;
        }
        for(int l = 0; l < nmovements.Length; l++)
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

    /*public void DownBtnClick()
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
    }*/

    public void RigthBtnClick()
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

    public void Exit()
    {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);

    }

}