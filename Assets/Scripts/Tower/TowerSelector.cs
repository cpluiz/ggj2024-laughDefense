using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private Canvas _selectorCanvas;

    private void OnMouseDown()
    {
        _selectorCanvas.gameObject.SetActive(!_selectorCanvas.gameObject.activeSelf);
    }
}
