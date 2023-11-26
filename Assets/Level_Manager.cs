using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    
    [System.Serializable]
    public struct ItemData
    {
        public string questionText;
        public Sprite questionImage;
        public string[] answerChoice;
        public bool[] isCorrect;
    }

    [SerializeField]
    private ItemData[] _listOfItem = new ItemData[0];

    [SerializeField]
    private UI_Pertanyaan _question = null;

    [SerializeField]
    private UI_Options[] _choices = new UI_Options[0];

    private int _questionIndex = -1;

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        //Next item index
        _questionIndex++;

        //Restart if index exceed last question
        if (_questionIndex >= _listOfItem.Length)
        {
            _questionIndex = 0;
        }

        //Input item question
        ItemData item = _listOfItem[_questionIndex];

        //Set item information
        _question.SetItem($"Soal{_questionIndex + 1}", item.questionText, item.questionImage);

        for (int i = 0; i < _choices.Length; i++)
        {
            UI_Options key = _choices[i];
            key.SetAnswerChoices(item.answerChoice[i], item.isCorrect[i]);
        }
    }
}
