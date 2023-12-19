using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;
    
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private QuizLevelPack _listOfItem = null;

    [SerializeField]
    private UI_Pertanyaan _question = null;

    [SerializeField]
    private UI_Options[] _choices = new UI_Options[0];

    [SerializeField]
    private GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _sceneNameMenuOption = string.Empty;

    private int _questionIndex = -1;

    private void Start()
    {
        if (!_playerProgress.LoadProgress())
        {
            _playerProgress.SaveProgress();
        }

        _listOfItem = _initialData.levelPack;
        _questionIndex = _initialData.levelIndex - 1;
        NextLevel();

        UI_Options.EventAnswerItem += UI_Options_EventAnswerItem;
    }

    private void OnDestroy()
    {
        UI_Options.EventAnswerItem -= UI_Options_EventAnswerItem;
    }

    private void OnApplicationQuit()
    {
        _initialData.whenLose = false;
    }

    private void UI_Options_EventAnswerItem(string answer, bool isCorrect)
    {
        if (isCorrect)
        {
            _playerProgress.progressData.coin += 20;
        }
    }

    public void NextLevel()
    {
        //Next item index
        _questionIndex++;

        //Restart if index exceed last question
        if (_questionIndex >= _listOfItem.LevelCount)
        {
            // _questionIndex = 0;
            _gameSceneManager.OpenScene(_sceneNameMenuOption);
            return;
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
