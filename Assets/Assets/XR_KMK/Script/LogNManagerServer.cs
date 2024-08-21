using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LogNManagerServer : MonoBehaviour
{
    // ����Ƽ �����Ϳ��� ������ UI ��ҵ�
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    public Text feedbackText;

    // �α��� API URL
    private string loginUrl = "http://192.168.1.60:8080/test"; // �̷��� �ִ� �� �³�...

    private void Start()
    {
        // �α��� ��ư�� Ŭ�� ������ �߰�
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        string Username = emailInputField.text;
        string password = passwordInputField.text;

        // �α��� ��û�� ����
        StartCoroutine(Login(Username, password));
    }

    private IEnumerator Login(string name, string password)
    {
        // �α��� ��û�� ���� ������ ����
        LoginRequestData requestData = new LoginRequestData
        {
            email = name,
            password = password
        };

        // ������ JSON �������� ��ȯ
        string jsonBody = JsonUtility.ToJson(requestData);

        // UnityWebRequest ����
        using (UnityWebRequest request = new UnityWebRequest(loginUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // ��û ������
            yield return request.SendWebRequest();

            // ��û ��� ó��
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                feedbackText.text = "Error: " + request.error;
            }
            else
            {
                string resultText = request.downloadHandler.text;
                Debug.Log(resultText);

                // ���� JSON �Ľ�
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(resultText);

                if (response.success)
                {
                    feedbackText.text = "Login successful!";
                    // �α��� ���� ���� �߰� �ൿ�� ���⿡ �߰�
                }
                else
                {
                    feedbackText.text = response.message;
                }
            }
        }
    }

    // �α��� ��û ������ ����
    [System.Serializable]
    public class LoginRequestData
    {
        public string email;
        public string password;
    }

    // �α��� ���� ������ ����
    [System.Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
    }
}
