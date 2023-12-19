using UnityEngine;

public class UI_LevelList : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;
    
    [SerializeField]
    private UI_OpsiLevel _levelButton = null;

    [SerializeField]
    private RectTransform _content = null;

    [SerializeField]
    private QuizLevelPack _levelPacks = null;

    [SerializeField]
    GameSceneManager _gameSceneManager = null;

    [SerializeField]
    private string _gameplayScene = null;
    
    private void Start()
    {
        if (_levelPacks != null)
        {
            UnloadLevelPack(_levelPacks);
        }
        UI_OpsiLevel.EventWhenClicked += UI_OpsiLevel_EventWhenClicked;
    }

    private void OnDestroy()
    {
        UI_OpsiLevel.EventWhenClicked -= UI_OpsiLevel_EventWhenClicked;
    }

    private void UI_OpsiLevel_EventWhenClicked(int index)
    {
        _initialData.levelIndex = index;
        _gameSceneManager.OpenScene(_gameplayScene);
    }

    public void UnloadLevelPack(QuizLevelPack levelPack)
    {
        ClearContent();
        _levelPacks = levelPack;
        for (int i = 0; i < levelPack.LevelCount; i++)
        {
            var t = Instantiate(_levelButton);

            t.SetLevel(levelPack.GrabLevelIndex(i), i);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void ClearContent()
    {
        var cc = _content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
