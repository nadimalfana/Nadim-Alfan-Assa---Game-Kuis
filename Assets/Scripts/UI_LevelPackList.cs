using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField]
    private InitialDataGameplay _initialData = null;

    [SerializeField]
    private UI_LevelList _levelList = null;
    
    [SerializeField]
    private UI_OpsiLevelPack _levelPackButton = null;

    [SerializeField]
    private RectTransform _content = null;

    [Space, SerializeField]
    private QuizLevelPack[] _levelPacks = new QuizLevelPack[0];
    
    void Start()
    {
        LoadLevelPackList();

        if(_initialData.whenLose)
        {
            UI_OpsiLevelPack_EventWhenClicked(_initialData.levelPack);
        }

        UI_OpsiLevelPack.EventWhenClicked += UI_OpsiLevelPack_EventWhenClicked;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventWhenClicked -= UI_OpsiLevelPack_EventWhenClicked;
    }

    private void UI_OpsiLevelPack_EventWhenClicked(QuizLevelPack levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);
        gameObject.SetActive(false);
        _initialData.levelPack = levelPack;
    }

    private void LoadLevelPackList()
    {
        foreach (var lp in _levelPacks)
        {
            var t = Instantiate(_levelPackButton);

            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}
