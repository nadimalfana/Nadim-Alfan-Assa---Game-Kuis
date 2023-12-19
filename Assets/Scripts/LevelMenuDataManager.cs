using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerProgress _playerProgress = null;

    [SerializeField]
    private TextMeshProUGUI _coinPlaceholder = null;

    void Start()
    {
        _coinPlaceholder.text = $"{_playerProgress.progressData.coin}";
    }
}
