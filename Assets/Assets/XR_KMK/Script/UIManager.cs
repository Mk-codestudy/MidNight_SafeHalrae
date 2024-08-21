using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject logUI;
    public GameObject currentSafyUI;
    public Text logtext;

    [Header("엔딩 측정용 변수")]
    public PlayerMove pm;
    public DangerDesk dd;
    public DangerCollider dc;

    [Header("엔딩 UI")]
    public GameObject endUI;

    private void Update()
    {
        if (pm.istalked && dd.istalked && dc.istalked)
        {
            endUI.SetActive(true);
        }
    }


    public void ViewLog()
    {
        logUI.SetActive(true);
        currentSafyUI.SetActive(false);
    }

    public void CloseBot()
    {
        currentSafyUI.SetActive(false);
        logtext.text = "안전이가 여러분을 위한 안전 상식을 준비하고 있어요!\n잠시만요...";
    }

    public void CloseLog()
    {
        logUI.SetActive(false);
        logtext.text = "안전이가 여러분을 위한 안전 상식을 준비하고 있어요!\n잠시만요...";
    }

    public void GotoMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#elif UNITY_STANDALONE
        //2. 어플리케이션일 경우
        Application.Quit();

#endif 
    }
}
