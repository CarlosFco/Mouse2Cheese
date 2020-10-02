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

    public void BackToChooseWay()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

    public void ToLevel3Question()
	{
        SceneManager.LoadScene("Level3Question", LoadSceneMode.Single);
    }

    public void ToLevel4Question()
	{
        SceneManager.LoadScene("Level4Question", LoadSceneMode.Single);
    }

    public void ToLevel5Question()
    {
        SceneManager.LoadScene("Level5Question", LoadSceneMode.Single);
    }

    public void ToLevel6Question()
    {
        SceneManager.LoadScene("Level6Question", LoadSceneMode.Single);
    }

}
