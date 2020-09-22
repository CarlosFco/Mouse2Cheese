using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void ToChooseWay()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

    public void ToRecognition()
    {
        SceneManager.LoadScene("Reco", LoadSceneMode.Single);
    }

    public void ToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScreen", LoadSceneMode.Single);
    }

    public void Exit()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

    public void FirstLevelCompleted()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

}
