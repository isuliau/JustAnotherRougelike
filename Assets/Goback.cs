using UnityEngine;
using UnityEngine.SceneManagement; 

public class Goback : MonoBehaviour
{
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("MainMenu");
    }

}