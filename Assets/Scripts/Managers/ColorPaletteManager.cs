using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ColorPaletteManager : MonoBehaviour
{
    [SerializeField] private ColorVariable PrimaryColor;
    [SerializeField] private ColorVariable SecondaryColor;
    [SerializeField] private ColorVariable TertiaryColor;
    [SerializeField] private ColorVariable QuaternaryColor;
    [SerializeField] private ColorVariable QuinternaryColor;

    private static ColorPaletteManager _instance;
    public static ColorPaletteManager Instance
    {
        get {
            return _instance; 
        }
    }

    [ExecuteAlways]
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if( _instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    [ExecuteAlways]
    public static Color GetColor(ColorPalette patternColor)
    {
        switch (patternColor)
        {
            case ColorPalette.Primary:
                return Instance.PrimaryColor.Value;
            case ColorPalette.Secondary:
                return Instance.SecondaryColor.Value;
            case ColorPalette.Tertiary:
                return Instance.TertiaryColor.Value;
            case ColorPalette.Quaternary:
                return Instance.QuaternaryColor.Value;
            case ColorPalette.Quinternary:
                return Instance.QuinternaryColor.Value;
            default:
                return new Color(0,0,0,0);
        }
    }
}
public enum ColorPalette
{
    Primary = 1,
    Secondary = 2,
    Tertiary = 3,
    Quaternary = 4,
    Quinternary = 5,
}