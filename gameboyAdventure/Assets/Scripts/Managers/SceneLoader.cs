using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public void LoadScene(string scenename)
    {
        SceneManager.LoadSceneAsync(scenename);
    }
}
