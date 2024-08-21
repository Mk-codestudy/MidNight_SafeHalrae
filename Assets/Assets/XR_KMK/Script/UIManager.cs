using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject logUI;
    public GameObject currentSafyUI;
    public Text logtext;

    public void ViewLog()
    {
        logUI.SetActive(true);
        currentSafyUI.SetActive(false);
    }

    public void CloseBot()
    {
        currentSafyUI.SetActive(false);
        logtext.text = "안전이가 여러분을 위한 안전 상식을 준비하고 있어요!\n잠시만요...";
    }

    public void CloseLog()
    {
        logUI.SetActive(false);
        logtext.text = "안전이가 여러분을 위한 안전 상식을 준비하고 있어요!\n잠시만요...";
    }

}
