using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string id) 
    {
        SceneManager.LoadScene(id);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
