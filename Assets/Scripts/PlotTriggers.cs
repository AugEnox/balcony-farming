using UnityEngine;

public class PlotTriggers : MonoBehaviour
{
    private Plot _parentPlot;
    private Animator _promptAnimator;
    private PlayerMovement _playerPlayerMovement;
    void Awake()
    {
        _parentPlot = GetComponentInParent<Plot>();
        if (_parentPlot.buttonPromptAnimator)
        {
            _promptAnimator = _parentPlot.buttonPromptAnimator;
        }
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        if (playerGameObject)
        {
            _playerPlayerMovement = playerGameObject.GetComponent<PlayerMovement>();            
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parentPlot.isPlantPossible = true;
            _playerPlayerMovement.selectedPlot = _parentPlot;
            StartPromptAnimation();
            Debug.Log("Entered " + _parentPlot + " Trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _parentPlot.isPlantPossible = false;
            _playerPlayerMovement.selectedPlot = null;
            StopPromptAnimation();
            Debug.Log("Trigger Exit" + _parentPlot);
        }
    }

    private void StartPromptAnimation()
    {
        _promptAnimator.enabled = true;
    }

    private void StopPromptAnimation()
    {
        
    }
}