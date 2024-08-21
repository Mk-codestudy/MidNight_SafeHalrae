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

    //ȸ�����Խ� ����ϴ� List
    public List<TMP_InputField> userjoinInputs = new List<TMP_InputField>();
    public Toggle isStudent;
    public Button btn_Join;
    public Text text_response; //��� �ؽ�Ʈ

    //�α��ν� ����ϴ� List
    public List<TMP_InputField> userLoginInputs = new List<TMP_InputField>();


    void Start()
    {

    }

    // ȸ������ Json
    public void PostJoin()
    {
        btn_Join.interactable = false;
        StartCoroutine(PostJoinJSonRequest(url));
    }

    IEnumerator PostJoinJSonRequest(string url)
    {
        //��ǲâ �Է� ������ Json �����ͷ� ��ȯ
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

        //// Post�غ�
        //UnityWebRequest request = new UnityWebRequest(url+ "/signup", "POST"); //������ ���� ���
        //request.SetRequestHeader("Content-Type", "application/json"); //������ ���� ���
        //request.uploadHandler = new UploadHandlerRaw(jsonBins); //�̰� ������ ���ظ��ߴµ�
        //request.downloadHandler = new DownloadHandlerBuffer(); //�ϴ� �����س��߰���

        ////Post�ϰ� ������ �� ������ ��ٸ���.
        //yield return request.SendWebRequest();

        //if (request.result == UnityWebRequest.Result.Success)
        //{
        //    // �ٿ�ε� �ڵ鷯���� �ؽ�Ʈ ���� �޾Ƽ� UI�� ����Ѵ�. //�ٵ� �ٿ�ε� �ڵ鷯�� ������
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
    //    //�α��� ��ư ��Ȱ��ȭ�صα�

    //}
    //IEnumerator GetLoginRequest(string url)
    //{
    //    UserLoginData loginData = new UserLoginData();
    //    loginData.userId = userLoginInputs[0].text;
    //    loginData.userPass = userLoginInputs[1].text;
    //    string loginJsonData = JsonUtility.ToJson(loginData, true);
    //    byte[] jsonBins = Encoding.UTF8.GetBytes(loginJsonData);

    //    //GET �غ�
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
