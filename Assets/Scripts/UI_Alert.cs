using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Alert : MonoBehaviour
{
    [SerializeField]
    private GameObject _winCondition = null;

    [SerializeField]
    private GameObject _loseCondition = null;
    
    [SerializeField]
    TextMeshProUGUI _alertPlaceholder = null;

    public string alertText
    {
        get => _alertPlaceholder.text;
        set => _alertPlaceholder.text = value;
    }

    private void Awake()
    {
        if(gameObject.activeSelf)
        gameObject.SetActive(false);
        UI_Timer.EventTimeUp += UI_Timer_EventTimeUp;
        UI_Options.EventAnswerItem += UI_Options_EventAnswerItem;
    }

    private void OnDestroy()
    {
        UI_Timer.EventTimeUp -= UI_Timer_EventTimeUp;
        UI_Options.EventAnswerItem -= UI_Options_EventAnswerItem;
    }

    private void UI_Options_EventAnswerItem(string textAnswer, bool isCorrect)
    {
        alertText = $"Jawaban Anda {isCorrect} (Jawaban: {textAnswer})";
        gameObject.SetActive(true);
        if (isCorrect)
        {
            _winCondition.SetActive(true);
            _loseCondition.SetActive(false);
        }
        else
        {
            _winCondition.SetActive(false);
            _loseCondition.SetActive(true);
        }
    }

    private void UI_Timer_EventTimeUp()
    {
        alertText = "Waktu Sudah Habis!!!";
        gameObject.SetActive(true);
        _winCondition.SetActive(false);
        _loseCondition.SetActive(true);
    }
}
