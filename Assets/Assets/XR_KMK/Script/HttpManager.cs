using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //http ����� ���� ���ӽ����̽�
using System.Text;          //json, csv���� ���ڵ�(UTF-8)�� ���� ���ӽ����̽�
using UnityEditor.UI;
using UnityEngine.UI;

public class HttpManager : MonoBehaviour
{
    ////�����͸� ���� URL
    //public string url;

    ////AI ê���� ��ǳ���� ��� �����Ű��
    //public Text talkabout;



    //void Start()
    //{

    //}


    //#region AI������ ��� �ڷ�ƾ �Լ�


    //public void SafyStartTalk()
    //{
    //    StartCoroutine(GetRequest(url));
    //}

    //Get ��� �ڷ�ƾ �Լ�
    //IEnumerator GetRequest(string url)
    //{
        //http Get ��� �غ�
        //UnityWebRequest request = UnityWebRequest.Get(url);
        
        //������ ��û ����. ������ �� ������ ���.
        //yield return request.SendWebRequest();

        //���� ����(�����ڵ� 200)��?

        ////������� �����͸� ����Ѵ�
        //if (request.result == UnityWebRequest.Result.Success)
        //{
        //    //������� ������ ���
        //    string response = request.downloadHandler.ToString();
        //    talkabout.text = response;
        //    Debug.Log("ê���� ������ ���� �������� �����մϴ�... : " + request);

        //}

        ////���� ���н�.(400, 404, 415 ��¼����¼��)
        ////���� ���� ���
        //else
        //{
        //    talkabout.text = "���� ���信 ������ �� ���ƿ�!";
        //    print(request.error);
        //}
    

    //    using (UnityWebRequest request = UnityWebRequest.Get(url))
    //    {
    //        //������ ��û ����. ������ �� ������ ���.
    //        yield return request.SendWebRequest();

    //        //���� ����(�����ڵ� 200)��?

    //        //������� �����͸� ����Ѵ�
    //        if (request.result == UnityWebRequest.Result.Success)
    //        {
    //            //������� ������ ���
    //            string response = request.downloadHandler.ToString();
    //            talkabout.text = response;
    //            Debug.Log("ê���� ������ ���� �������� �����մϴ�... : " + request);

    //        }

    //        //���� ���н�.(400, 404, 415 ��¼����¼��)
    //        //���� ���� ���
    //        else
    //        {
    //            talkabout.text = "���� ���信 ������ �� ���ƿ�!";
    //            print(request.error);
    //        }
    //    }
    //}
    //#endregion

  }
