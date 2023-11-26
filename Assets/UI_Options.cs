using UnityEngine;
using TMPro;

public class UI_Options : MonoBehaviour
{
    [SerializeField]
    private UI_Alert _alertPlaceholder = null;
    
    [SerializeField]
    private TextMeshProUGUI _textAnswer = null;

    [SerializeField]
    private bool _isCorrect;

    public void AnswerChoice()
    {
        //Debug.Log($"{_textAnswer.text} Adalah {_isCorrect}");
        _alertPlaceholder.alertText = $"{_textAnswer.text} Adalah {_isCorrect}";
    }

    public void SetAnswerChoices(string choicetext, bool iscorrect)
    {
        _textAnswer.text = choicetext;
        _isCorrect = iscorrect;
    }
}
