using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private QuizLevelPack _listOfItem = null;

    [SerializeField]
    private UI_Pertanyaan _question = null;

    [SerializeField]
    private UI_Options[] _choices = new UI_Options[0];

    private int _questionIndex = -1;

    private void Start()
    {
        if (!_playerProgress.LoadProgress())
        {
            _playerProgress.SaveProgress();
        }
        NextLevel();
    }

    public void NextLevel()
    {
        //Next item index
        _questionIndex++;

        //Restart if index exceed last question
        if (_questionIndex >= _listOfItem.LevelCount)
        {
            _questionIndex = 0;
        }

        //Input item question
        QuizQuestionLevel item = _listOfItem.GrabLevelIndex(_questionIndex);

        //Set item information
        _question.SetItem($"Soal{_questionIndex + 1}", item.questionText, item.questionImage);

        for (int i = 0; i < _choices.Length; i++)
        {
            UI_Options key = _choices[i];
            QuizQuestionLevel.Choice option = item.choice[i];
            key.SetAnswerChoices(option.answerChoice, option.isCorrect);
        }
    }
}
