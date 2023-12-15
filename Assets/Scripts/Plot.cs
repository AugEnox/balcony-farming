using UnityEngine;
using UnityEngine.InputSystem;

public class Plot : MonoBehaviour
{
    public GameObject plantObj;
    public BalconyMovement BalconyMovement;

    private Movement _playerMovement;
    private GameObject _playerGameObject;
    private InputAction _interactAction;
    private bool _isPlantPossible = false;
    private bool _isHarvestable = false;

    // MUST REFACTOR INTO TWO COMPONENTS
    // PlotTrigger component and Plot component
    // PlotTrigger will only handle triggers and report back to the Plot class
    // Plot will handle sowing and harvesting
    private void Awake()
    {
        plantObj.SetActive(false);
        _playerGameObject = GameObject.FindWithTag("Player");
        if (_playerGameObject)
        {
            _playerMovement = _playerGameObject.GetComponent<Movement>();            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlantPossible = true;
            _playerMovement.selectedGameObject = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlantPossible = false;
            _playerMovement.selectedGameObject = null;
        }
    }

    public void PlantASeed()
    {
        if(_isPlantPossible && !_isHarvestable)
        {
            plantObj.SetActive(true);
            _isHarvestable = true;
        }
    }
    
    public void HarvestPlant()
    {
        if(_isHarvestable)
        {
            plantObj.SetActive(false);
        }
    }
}