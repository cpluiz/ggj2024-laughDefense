using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private Canvas _selectorCanvas;

    private bool _spawningTower = false;

    private void OnMouseDown()
    {
        if(_spawningTower)
        {
            return;
        }
        _selectorCanvas.gameObject.SetActive(!_selectorCanvas.gameObject.activeSelf);
    }

    public void SpawnTower(TowerDescriptor towerDescription)
    {
        _spawningTower = true;
        _selectorCanvas.gameObject.SetActive(false);
        TowerSpawner towerSpawner = Instantiate<TowerSpawner>(towerDescription.prefab, transform.position, transform.rotation);
        towerSpawner.SetTowerDescriptor(towerDescription);
        //Only for tests
        towerSpawner.StartSpawning();
        Destroy(gameObject);
    }
}
