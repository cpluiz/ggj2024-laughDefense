using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectionManager : MonoBehaviour
{
    [SerializeField]
    private TowerDescriptorDrawer _towerButtonPrefab;
    [SerializeField]
    private RectTransform _towerButtonsContainer;

    [SerializeField]
    private TowerDescriptor[] availableTowers;

    protected void Awake()
    {
        foreach(TowerDescriptor tower in availableTowers)
        {
            InitTowerButton(tower);
        }
    }

    private void InitTowerButton(TowerDescriptor towerInfo)
    {
        TowerDescriptorDrawer towerDescriptorDrawer = Instantiate<TowerDescriptorDrawer>(_towerButtonPrefab, _towerButtonsContainer);
        towerDescriptorDrawer.SetTowerInfo(towerInfo);
    }
}
