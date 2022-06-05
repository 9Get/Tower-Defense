using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Transform towerPrefab;
    public Material canBuildMaterial, cantBuildMaterial, mainMaterial;
    public bool canBuild;

    private Renderer _renderer;
    private Resources _resources;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _resources = FindObjectOfType<Resources>();
    }

    private void OnMouseUp()
    {
        if (canBuild && _resources.gold >= _resources.towerCost)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            canBuild = false;
            _resources.WhenBuild();   
        }
    }
   
    private void OnMouseOver()
    {
        if(canBuild)
            _renderer.material = canBuildMaterial;
        else
            _renderer.material = cantBuildMaterial;
    }
    private void OnMouseExit()
    {
        _renderer.material = mainMaterial;
    }
}
