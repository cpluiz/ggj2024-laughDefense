using UnityEngine;
using UnityEngine.UI;

public class TowerDescriptorDrawer : MonoBehaviour
{
    [SerializeField]
    private Image _towerImage;
    [SerializeField]
    private TMPro.TextMeshProUGUI _towerName;
    [SerializeField]
    private TMPro.TextMeshProUGUI _towerCost;

    private TowerDescriptor _towerDescriptor;
    private TowerSelectionManager _selectionManager;

    public void SetTowerInfo(TowerDescriptor towerInfo, TowerSelectionManager selectionManager)
    {
        _towerDescriptor = towerInfo;
        _towerImage.sprite = towerInfo.Photo;
        _towerName.text = towerInfo.Neurotransmiter.name;
        _towerCost.text = $"Cost: {towerInfo.Cost}";
        _selectionManager = selectionManager;
    }

    public void RaiseTowerSelected()
    {
        _selectionManager.RaiseTowerSelected(_towerDescriptor);
    }
}
