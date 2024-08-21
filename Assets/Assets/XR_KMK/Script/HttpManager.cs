using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //http 통신을 위한 네임스페이스
using System.Text;          //json, csv같은 인코딩(UTF-8)을 위한 네임스페이스
using UnityEditor.UI;
using UnityEngine.UI;

public class HttpManager : MonoBehaviour
{
    ////데이터를 받을 URL
    //public string url;

    ////AI 챗봇의 말풍선에 결과 도출시키기
    //public Text talkabout;



    //void Start()
    //{

    //}


    //#region AI안전이 통신 코루틴 함수


    //public void SafyStartTalk()
    //{
    //    StartCoroutine(GetRequest(url));
    //}

    //Get 통신 코루틴 함수
    //IEnumerator GetRequest(string url)
    //{
        //http Get 통신 준비
        //UnityWebRequest request = UnityWebRequest.Get(url);
        
        //서버에 요청 전송. 응답이 올 때까지 대기.
        //yield return request.SendWebRequest();

        //응답 성공(서버코드 200)시?

        ////응답받은 데이터를 출력한다
        //if (request.result == UnityWebRequest.Result.Success)
        //{
        //    //응답받은 데이터 출력
        //    string response = request.downloadHandler.ToString();
        //    talkabout.text = response;
        //    Debug.Log("챗봇이 다음과 같은 내용으로 응답합니다... : " + request);

        //}

        ////응답 실패시.(400, 404, 415 어쩌구저쩌구)
        ////에러 내용 출력
        //else
        //{
        //    talkabout.text = "서버 응답에 실패한 것 같아요!";
        //    print(request.error);
        //}
    

    //    using (UnityWebRequest request = UnityWebRequest.Get(url))
    //    {
    //        //서버에 요청 전송. 응답이 올 때까지 대기.
    //        yield return request.SendWebRequest();

    //        //응답 성공(서버코드 200)시?

    //        //응답받은 데이터를 출력한다
    //        if (request.result == UnityWebRequest.Result.Success)
    //        {
    //            //응답받은 데이터 출력
    //            string response = request.downloadHandler.ToString();
    //            talkabout.text = response;
    //            Debug.Log("챗봇이 다음과 같은 내용으로 응답합니다... : " + request);

    //        }

    //        //응답 실패시.(400, 404, 415 어쩌구저쩌구)
    //        //에러 내용 출력
    //        else
    //        {
    //            talkabout.text = "서버 응답에 실패한 것 같아요!";
    //            print(request.error);
    //        }
    //    }
    //}
    //#endregion

  }
