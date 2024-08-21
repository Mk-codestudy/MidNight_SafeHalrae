using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //http ����� ���� ���ӽ����̽�
using System.Text;          //json, csv���� ���ڵ�(UTF-8)�� ���� ���ӽ����̽�
//using UnityEditor.UI;
using UnityEngine.UI;
using System;
using TMPro;

public class HttpManager : MonoBehaviour
{
    //�����͸� ���� URL
    //public string url; //�׳� �ٷ� ó�־���

    //AI ê���� ��ǳ���� ��� �����Ű��
    public Text talkabout;

    [Header("AI������ ������")]
    public List<string> aiSafy = new List<string>();


    [Header("������ ��ȭ �α� ������ ���� ������")]
    public GameObject logPart; //������
    public GameObject scrollview; //��ũ��

    public void SafyStartTalk()
    {
        StartCoroutine(GetRequest());
    }

    //Get ��� �ڷ�ƾ �Լ�
    IEnumerator GetRequest()
    {
        if (string.IsNullOrEmpty(LogNManager.authKey))
        {
            Debug.LogWarning("LogNManager.authKey가 없음");
            yield break;
        }

        AISafyData aiData = new AISafyData();
        aiData.userNo = int.Parse(aiSafy[0]); //�̰� �α����Ҷ� ���̵� ��ȣ ����� ����صΰ� ����
        aiData.trigger = aiSafy[1]; //���⿡ �� Ʈ���ź� Ʈ���� ��Ʈ�� �޾ƴٰ� ���� �˾Ƽ� �ؾ��ҰͰ�����
        aiData.chattingContents = aiSafy[2]; //�̰͵�

        string aIJsonData = JsonUtility.ToJson(aiData, true);

        //http Get ��� �غ�
        using (UnityWebRequest request = UnityWebRequest.Post("http://172.16.17.24:8080/api/chattings", aIJsonData, "application/json"))
        {
            request.SetRequestHeader("Authorization", LogNManager.authKey); //Header�� Ű �߰�

            //������ ��û ����. ������ �� ������ ���.
            yield return request.SendWebRequest();

            //���� ����(�����ڵ� 200)��?

            //������� �����͸� ����Ѵ�
            if (request.result == UnityWebRequest.Result.Success)
            {
                //������� ������ ���
                string response = request.downloadHandler.text;
                AISafyData parseData =  JsonUtility.FromJson<AISafyData>(response);


                talkabout.text = parseData.chattingContents;

                Debug.Log("ê���� ������ ���� �������� �����մϴ�... : " + parseData.chattingContents);

                //������ �� ä�� �α׿� ������Ű��
                // ������ �ν��Ͻ�ȭ �� UI �ؽ�Ʈ ����
                GameObject newResponse = Instantiate(logPart, scrollview.transform);
                Text[] texts = newResponse.GetComponentsInChildren<Text>();
                foreach (Text text in texts)
                {
                    if (text.name == "LogName")
                        text.text = parseData.trigger;
                    else if (text.name == "Log")
                        text.text = parseData.chattingContents;
                }




            }

            //���� ���н�.(400, 404, 415 ��¼����¼��)
            //���� ���� ���
            else
            {
                talkabout.text = "���� ���信 ������ �� ���ƿ�!";
                print(request.error);
            }
        }
    }

}

[System.Serializable]
public struct AISafyData
{
    public int userNo;
    public string trigger;
    public string chattingContents;
}