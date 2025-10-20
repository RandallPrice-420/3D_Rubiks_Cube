using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneManager : MonoBehaviour
{
    public void BackToMenu()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (SceneManager.sceneCount > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

    }   // BackToMenu()


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }   // QuitGame()


}   // class MainSceneManager
