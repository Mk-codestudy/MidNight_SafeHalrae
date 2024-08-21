using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor.UI;
using JetBrains.Annotations;

public class LogNManager : MonoBehaviour
{
    public string url;

    //회원가입시 사용하는 List
    public List<TMP_InputField> userjoinInputs = new List<TMP_InputField>();
    public Toggle isStudent;
    public Button btn_Join;
    public Text text_response; //결과 텍스트

    //로그인시 사용하는 List
    public List<TMP_InputField> userLoginInputs = new List<TMP_InputField>();


    void Start()
    {

    }

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

            }
            else
            {
                print(request.error);
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


    //public void GetLogin()
    //{
    //    //로그인 버튼 비활성화해두기

    //}
    //IEnumerator GetLoginRequest(string url)
    //{
    //    UserLoginData loginData = new UserLoginData();
    //    loginData.userId = userLoginInputs[0].text;
    //    loginData.userPass = userLoginInputs[1].text;
    //    string loginJsonData = JsonUtility.ToJson(loginData, true);
    //    byte[] jsonBins = Encoding.UTF8.GetBytes(loginJsonData);

    //    //GET 준비
    //}

}

[System.Serializable]
public struct UserLoginData
{
    public string userId;
    public string userPass;
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
