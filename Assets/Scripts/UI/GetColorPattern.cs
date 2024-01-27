using UnityEngine;

public class GetColorPattern : MonoBehaviour
{
    [SerializeField] private ColorPalette colorPalette;

    private TMPro.TextMeshProUGUI _textComponent;
    private UnityEngine.UI.Image _imageComponent;
    private SpriteRenderer _spriteComponent;

    [ExecuteAlways]
    private void Awake()
    {
        UpdateColor();
    }

    [ExecuteAlways]
    public void UpdateColor()
    {
        _textComponent = GetComponent<TMPro.TextMeshProUGUI>();
        _imageComponent = GetComponent<UnityEngine.UI.Image>();
        _spriteComponent = GetComponent<SpriteRenderer>();

        if (_textComponent != null)
        {
            _textComponent.color = ColorPaletteManager.GetColor(colorPalette);
        }
        if(_imageComponent != null)
        {
            _imageComponent.color = ColorPaletteManager.GetColor(colorPalette);
        }
        if(_spriteComponent != null)
        {
            _spriteComponent.color = ColorPaletteManager.GetColor(colorPalette);
        }
    }
}
