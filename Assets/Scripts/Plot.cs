using System;
using UnityEngine;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    public GameObject PlantObj;
    public GameObject GroundObj;

    private void Awake()
    {
        PlantObj.SetActive(false);
    }

    public void PlantASeed()
    {
        PlantObj.SetActive(true);
    }
}