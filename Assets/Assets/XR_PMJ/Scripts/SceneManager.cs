using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManager : MonoBehaviour // 성공했을때니까 서버에 연결해주기 
{
    public void LoadLoginSucc()
    {
        Debug.Log("로그인 성공");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void LoadLogin()
    {
        Debug.Log("로그인창이다얍");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
