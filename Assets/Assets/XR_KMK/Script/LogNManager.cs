using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor.UI;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class LogNManager : MonoBehaviour
{
    [Header("로그인 URL")]
    public string url;

    [Header("회원가입 변수")]
    //회원가입시 사용하는 List
    public List<TMP_InputField> userjoinInputs = new List<TMP_InputField>();
    public Toggle isStudent;
    public Button btn_Join;
    public Text text_response; //결과 텍스트

    [Header("로그인 변수")]
    //로그인시 사용하는 List
    public List<TMP_InputField> userLoginInputs = new List<TMP_InputField>();
    public Button btn_Login;

    [Header("클릭하면 로그인 창이 뜨도록 하기 변수")]
    //클릭하면 로그인 창이 뜨게 하자!
    //로그인 창이 뜨고...
    //텍스트 setactive는 false로
    public Text clickToLogin;
    public GameObject loginUI;
    public GameObject joinUI;

    [Header("로그인 성공, 로그인 실패")]
    public GameObject successUI;
    public GameObject failedUI;
    public Text failedscript;

    [Header("회원가입 성공")]
    public GameObject joinsuccessUI;


    void Start()
    {

        //로그인 UI는 처음에 보이면 안된당.
        loginUI.SetActive(false);
        joinUI.SetActive(false);

    }

    #region 회원가입 통신
    // 회원가입 Json
    public void PostJoin()
    {
        btn_Join.interactable = false;
        StartCoroutine(PostJoinJSonRequest(url));
    }

    IEnumerator PostJoinJSonRequest(string url)
    {
        //인풋창 입력 정보를 Json 데이터로 변환
        JoinUserData userData = new JoinUserData();
        userData.userId = userjoinInputs[0].text;
        userData.userPass = userjoinInputs[1].text;
        userData.userName = userjoinInputs[2].text;
        userData.userEmail = userjoinInputs[3].text;
        userData.role = "USER";

        string userJsonData = JsonUtility.ToJson(userData, true);
        //byte[] jsonBins = Encoding.UTF8.GetBytes(userJsonData);

        using(UnityWebRequest request = UnityWebRequest.Post(url + "/signup", userJsonData, "application/json"))
        {
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.Success)
            {
                print(request.downloadHandler.text);
                //회원가입 완료 UI 띄우기
                //완료 UI에서 로그인으로 돌아가기 버튼을 누르면 회원가입 창이 사라짐
                joinsuccessUI.SetActive(true);

            }
            else
            {
                print(request.error);
                //예기치 못한 서버 오류 UI도 만들어둘까?
            }
        }
        //// Post준비
        //UnityWebRequest request = new UnityWebRequest(url+ "/signup", "POST"); //명세서에 적힌 대로
        //request.SetRequestHeader("Content-Type", "application/json"); //명세서에 적힌 대로
        //request.uploadHandler = new UploadHandlerRaw(jsonBins); //이건 솔직히 이해못했는데
        //request.downloadHandler = new DownloadHandlerBuffer(); //일단 복붙해놔야겠음

        ////Post하고 응답이 올 때까지 기다린다.
        //yield return request.SendWebRequest();

        //if (request.result == UnityWebRequest.Result.Success)
        //{
        //    // 다운로드 핸들러에서 텍스트 값을 받아서 UI에 출력한다. //근데 다운로드 핸들러가 뭐예염
        //    string response = request.downloadHandler.text;
        //    text_response.text = response;
        //    Debug.LogWarning(response);
        //}
        //else
        //{
        //    text_response.text = request.error;
        //    Debug.LogError(request.error);
        //}
        btn_Join.interactable = true;
    }

    #endregion

    #region 로그인 통신
    public void PostLogin()
    {
        //로그인 버튼 비활성화해두기
        btn_Login.interactable = false;
        StartCoroutine(PostLoginRequest(url));
    }
    IEnumerator PostLoginRequest(string url)
    {
        UserLoginData loginData = new UserLoginData();
        loginData.id = userLoginInputs[0].text;
        loginData.pass = userLoginInputs[1].text;
        //loginData.role = "USER";

        string userJsonData = JsonUtility.ToJson(loginData, true);
        //byte[] jsonBins = Encoding.UTF8.GetBytes(userJsonData);

        using (UnityWebRequest request = UnityWebRequest.Post(url + "/login", userJsonData, "application/json"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                print(request.downloadHandler.text);
                if (request.downloadHandler.text.Contains("failType"))
                {
                    failedUI.SetActive(true);
                    failedscript.text = request.downloadHandler.text;
                }
                else
                {
                    //로그인 성공 UI
                    LoginSuccess();
                }
            }
            else
            {
                print(request.error);
                //로그인 실패
                failedUI.SetActive(true);
                failedscript.text = request.error.ToString();
            }
        }
        btn_Login.interactable=true;
    }
    #endregion


    public void ClickToLogin() //클릭하면 로그인 창이 뜨도록 한다.
    {
        loginUI.SetActive(true);
        clickToLogin.gameObject.SetActive(false);
    }

    public void LetsJoin() //회원가입 버튼을 누르면 회원가입 창이 뜨도록 한다.
    {
        joinUI.SetActive(true);
    }


    public void LoginSuccess() //로그인에 성공하면 로그인 성공 창이 뜨게 한다.
    {
        successUI.SetActive(true);
    }
    
    public void ConfrimFaildButton() //로그인 실패 창에 확인 버튼을 누르면 창이 꺼진다.
    {
        failedUI.SetActive(false);
    }

    public void JoinSuccessfulyEnd() //회원가입 완료창 종료하기
    {
        joinsuccessUI.SetActive(false);
    }


    public void LoginSuccessNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); //1번 씬으로 이동
    }
}

[System.Serializable]
public struct UserLoginData
{
    public string id;
    public string pass;
    //public string role;
}

[System.Serializable]
public struct JoinUserData
{
    public string userId;
    public string userPass;
    public string userName;
    public string userEmail;
    public string role;
}
