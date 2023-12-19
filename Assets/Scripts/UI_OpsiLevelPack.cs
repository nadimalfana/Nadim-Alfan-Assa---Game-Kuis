using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<QuizLevelPack> EventWhenClicked;

    [SerializeField]
    private Button _button = null;

    [SerializeField]
    private TextMeshProUGUI _packName = null;

    [SerializeField]
    private QuizLevelPack _levelPack = null;

    private void Start()
    {
        if (_levelPack != null)
            SetLevelPack(_levelPack);
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void SetLevelPack(QuizLevelPack levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    private void OnClick()
    {
        // Debug.Log("KLIK");
        EventWhenClicked?.Invoke(_levelPack);
    }
}
