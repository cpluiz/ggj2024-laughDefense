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

    public void SetTowerInfo(TowerDescriptor towerInfo)
    {
        _towerImage.sprite = towerInfo.Photo;
        _towerName.text = towerInfo.Neurotransmiter.name;
        _towerCost.text = $"Cost: {towerInfo.Cost}";
    }
}
