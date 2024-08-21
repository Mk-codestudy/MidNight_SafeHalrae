using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoginSucc : MonoBehaviour // 성공했을때니까 서버에 연결해주기 
{
    public void LoadLoginSucc()
    {
        Debug.Log("로그인 성공");
        SceneManager.LoadScene(2);
    }
}
