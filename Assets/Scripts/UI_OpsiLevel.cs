using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_OpsiLevel : MonoBehaviour
{
    public static event System.Action<int> EventWhenClicked;

    [SerializeField]
    private Button _levelButton = null;
    
    [SerializeField]
    private TextMeshProUGUI _levelName = null;

    [SerializeField]
    private QuizQuestionLevel _level = null;

    private void Start()
    {
        if (_level != null)
            SetLevel(_level, _level.levelPackIndex);
        _levelButton.onClick.AddListener(onClick);
    }

    private void OnDestroy()
    {
        _levelButton.onClick.RemoveListener(onClick);
    }

    public void SetLevel(QuizQuestionLevel level, int index)
    {
        _levelName.text = level.name;
        _level = level;

        _level.levelPackIndex = index;
    }

    private void onClick()
    {
        EventWhenClicked?.Invoke(_level.levelPackIndex);
    }
}
