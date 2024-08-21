using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //http 통신을 위한 네임스페이스
using System.Text;          //json, csv같은 인코딩(UTF-8)을 위한 네임스페이스
using UnityEditor.UI;
using UnityEngine.UI;
using System;
using TMPro;

public class HttpManager : MonoBehaviour
{
    //데이터를 받을 URL
    //public string url; //그냥 바로 처넣었음

    //AI 챗봇의 말풍선에 결과 도출시키기
    public Text talkabout;

    [Header("AI안전이 데이터")]
    public List<string> aiSafy = new List<string>();


    [Header("안전이 대화 로그 누적을 위한 프리펩")]
    public GameObject logPart; //프리펩
    public GameObject scrollview; //스크롤

    public void SafyStartTalk()
    {
        StartCoroutine(GetRequest());
    }

    //Get 통신 코루틴 함수
    IEnumerator GetRequest()
    {
        AISafyData aiData = new AISafyData();
        aiData.userNo = int.Parse(aiSafy[0]); //이건 로그인할때 아이디 번호 상수로 기억해두고 적기
        aiData.trigger = aiSafy[1]; //여기에 각 트리거별 트리거 스트링 받아다가 내가 알아서 해야할것같은디
        aiData.chattingContents = aiSafy[2]; //이것도

        string aIJsonData = JsonUtility.ToJson(aiData, true);

        //http Get 통신 준비
        using (UnityWebRequest request = UnityWebRequest.Post("http://172.16.17.24:8080/api/chattings", aIJsonData, "application/json"))
        {
            request.SetRequestHeader("Authorization", LogNManager.authKey); //Header에 키 추가

            //서버에 요청 전송. 응답이 올 때까지 대기.
            yield return request.SendWebRequest();

            //응답 성공(서버코드 200)시?

            //응답받은 데이터를 출력한다
            if (request.result == UnityWebRequest.Result.Success)
            {
                //응답받은 데이터 출력
                string response = request.downloadHandler.text;
                AISafyData parseData =  JsonUtility.FromJson<AISafyData>(response);


                talkabout.text = parseData.chattingContents;

                Debug.Log("챗봇이 다음과 같은 내용으로 응답합니다... : " + parseData.chattingContents);

                //응답할 때 채팅 로그에 누적시키기
                // 프리팹 인스턴스화 및 UI 텍스트 설정
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

            //응답 실패시.(400, 404, 415 어쩌구저쩌구)
            //에러 내용 출력
            else
            {
                talkabout.text = "서버 응답에 실패한 것 같아요!";
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