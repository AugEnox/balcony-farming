using UnityEngine;
using UnityEngine.InputSystem;

public class Plot : MonoBehaviour
{
    public GameObject plantObj;
    public Animator buttonPromptAnimator;
    public bool isPlantPossible = false;
    private bool _isHarvestable = false;

    // MUST REFACTOR INTO TWO COMPONENTS
    // PlotTrigger component and Plot component
    // PlotTrigger will only handle triggers and report back to the Plot class
    // Plot will handle sowing and harvesting
    private void Awake()
    {
        plantObj.SetActive(false);
    }

    public void PlantASeed()
    {
        if(isPlantPossible && !_isHarvestable)
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
            _isHarvestable = false;
        }
        Debug.Log(this.gameObject);
    }
}