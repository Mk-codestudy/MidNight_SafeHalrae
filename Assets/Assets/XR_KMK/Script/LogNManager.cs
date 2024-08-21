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
    [Header("�α��� URL")]
    public string url;

    [Header("ȸ������ ����")]
    //ȸ�����Խ� ����ϴ� List
    public List<TMP_InputField> userjoinInputs = new List<TMP_InputField>();
    public Toggle isStudent;
    public Button btn_Join;
    public Text text_response; //��� �ؽ�Ʈ

    [Header("�α��� ����")]
    //�α��ν� ����ϴ� List
    public List<TMP_InputField> userLoginInputs = new List<TMP_InputField>();
    public Button btn_Login;

    [Header("Ŭ���ϸ� �α��� â�� �ߵ��� �ϱ� ����")]
    //Ŭ���ϸ� �α��� â�� �߰� ����!
    //�α��� â�� �߰�...
    //�ؽ�Ʈ setactive�� false��
    public Text clickToLogin;
    public GameObject loginUI;
    public GameObject joinUI;

    [Header("�α��� ����, �α��� ����")]
    public GameObject successUI;
    public GameObject failedUI;
    public Text failedscript;

    [Header("ȸ������ ����")]
    public GameObject joinsuccessUI;


    void Start()
    {

        //�α��� UI�� ó���� ���̸� �ȵȴ�.
        loginUI.SetActive(false);
        joinUI.SetActive(false);

    }

    #region ȸ������ ���
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
                //ȸ������ �Ϸ� UI ����
                //�Ϸ� UI���� �α������� ���ư��� ��ư�� ������ ȸ������ â�� �����
                joinsuccessUI.SetActive(true);

            }
            else
            {
                print(request.error);
                //����ġ ���� ���� ���� UI�� �����ѱ�?
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

    #endregion

    #region �α��� ���
    public void PostLogin()
    {
        //�α��� ��ư ��Ȱ��ȭ�صα�
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
                    //�α��� ���� UI
                    LoginSuccess();
                }
            }
            else
            {
                print(request.error);
                //�α��� ����
                failedUI.SetActive(true);
                failedscript.text = request.error.ToString();
            }
        }
        btn_Login.interactable=true;
    }
    #endregion


    public void ClickToLogin() //Ŭ���ϸ� �α��� â�� �ߵ��� �Ѵ�.
    {
        loginUI.SetActive(true);
        clickToLogin.gameObject.SetActive(false);
    }

    public void LetsJoin() //ȸ������ ��ư�� ������ ȸ������ â�� �ߵ��� �Ѵ�.
    {
        joinUI.SetActive(true);
    }


    public void LoginSuccess() //�α��ο� �����ϸ� �α��� ���� â�� �߰� �Ѵ�.
    {
        successUI.SetActive(true);
    }
    
    public void ConfrimFaildButton() //�α��� ���� â�� Ȯ�� ��ư�� ������ â�� ������.
    {
        failedUI.SetActive(false);
    }

    public void JoinSuccessfulyEnd()
    {
        joinsuccessUI.SetActive(false);
    }

    public void LoginSuccessNextScene()
    {
        SceneManager.LoadScene(1); //1�� ������ �̵�
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
