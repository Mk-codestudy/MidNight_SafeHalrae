using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LogNManagerServer : MonoBehaviour
{
    // 유니티 에디터에서 연결할 UI 요소들
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    public Text feedbackText;

    // 로그인 API URL
    private string loginUrl = "http://192.168.1.60:8080/test"; // 이렇게 넣는 게 맞나...

    private void Start()
    {
        // 로그인 버튼에 클릭 리스너 추가
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        string Username = emailInputField.text;
        string password = passwordInputField.text;

        // 로그인 요청을 시작
        StartCoroutine(Login(Username, password));
    }

    private IEnumerator Login(string name, string password)
    {
        // 로그인 요청을 위한 데이터 설정
        LoginRequestData requestData = new LoginRequestData
        {
            email = name,
            password = password
        };

        // 데이터 JSON 형식으로 변환
        string jsonBody = JsonUtility.ToJson(requestData);

        // UnityWebRequest 설정
        using (UnityWebRequest request = new UnityWebRequest(loginUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // 요청 보내기
            yield return request.SendWebRequest();

            // 요청 결과 처리
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                feedbackText.text = "Error: " + request.error;
            }
            else
            {
                string resultText = request.downloadHandler.text;
                Debug.Log(resultText);

                // 응답 JSON 파싱
                LoginResponse response = JsonUtility.FromJson<LoginResponse>(resultText);

                if (response.success)
                {
                    feedbackText.text = "Login successful!";
                    // 로그인 성공 후의 추가 행동을 여기에 추가
                }
                else
                {
                    feedbackText.text = response.message;
                }
            }
        }
    }

    // 로그인 요청 데이터 구조
    [System.Serializable]
    public class LoginRequestData
    {
        public string email;
        public string password;
    }

    // 로그인 응답 데이터 구조
    [System.Serializable]
    public class LoginResponse
    {
        public bool success;
        public string message;
    }
}
