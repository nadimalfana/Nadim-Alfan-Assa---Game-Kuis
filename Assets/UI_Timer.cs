using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    private UI_Alert _alertPlaceholder = null;
    
    [SerializeField]
    private Slider _timeBar = null;

    [SerializeField]
    private float _itemTimeLimit = 30f;
    private float _itemTimeRemaining = 0f;
    private bool _timeIsRunning = true;

    public bool TimeIsRunning
    {
        get => _timeIsRunning;
        set => _timeIsRunning = value;
    }

    private void Start()
    {
        ResetTime();
    }

    private void Update()
    {
        if(!_timeIsRunning)
        return;

        _itemTimeRemaining -= Time.deltaTime;
        _timeBar.value = _itemTimeRemaining / _itemTimeLimit;
        if (_itemTimeRemaining <= 0f)
        {
            _alertPlaceholder.alertText = "Waktu Sudah Habis";
            _alertPlaceholder.gameObject.SetActive(true);
            //Debug.Log("Waktu Habis");
            _timeIsRunning = false;
            return;
        }
        // Debug.Log(_itemTimeRemaining);
    }

    public void ResetTime()
    {
        _itemTimeRemaining = _itemTimeLimit;
    }
}
