using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeMainScene()
    {
        //로드 씬 에서는 빌드레벨로 구성한다
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ChangeInGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
        Application.Quit();
    }
}
