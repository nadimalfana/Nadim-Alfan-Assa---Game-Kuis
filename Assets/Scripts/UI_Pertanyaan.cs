using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _titlePlaceholder = null;
    
    [SerializeField]
    private TextMeshProUGUI _textPlaceholder = null;
    
    [SerializeField]
    private Image _imagePlaceholder = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_textPlaceholder.text);
    }

    public void SetItem(string titletext, string questiontext, Sprite questionimage)
    {
        _titlePlaceholder.text = titletext;
        _textPlaceholder.text = questiontext;
        _imagePlaceholder.sprite = questionimage;
    }
}
