using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void nextScene()
    {
        SceneManager.LoadScene("Reco", LoadSceneMode.Single);
    }

    public void GoChoose()
    {
        SceneManager.LoadScene("ChooseWay", LoadSceneMode.Single);
    }

    public void GoHowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScreen", LoadSceneMode.Single);
    }
}
