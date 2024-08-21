using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField UsernameInputField;
    public TMP_InputField PasswordInputField;
    public Button LoginButton;
    public Text feedbackText;

    private void Start()
    {
        //LoginButton.onClick.AddLister(OnLoginButtonClicked);
        
    }

    private void OnLoginButtonClicked()
    {
        string Username = UsernameInputField.text;
        string Password = PasswordInputField.text;


        if (ValidateCredentials(Username, Password))
        {
            feedbackText.text = "Login 성공"; // 성공할시 뒤로 넘어가게 해야함
        }
        else
        {
            feedbackText.text = "Login 실패"; // 다시시도 와 같은 창 뜨게 하기
        }
    }

    private bool ValidateCredentials(string Username, string Password)
    {
        return Username == "MTSV3C4" && Password == "Fighting"; // 
    }
}

