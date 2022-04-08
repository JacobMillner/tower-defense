using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Transform woodHarvester;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(woodHarvester, GetMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPostion =
            mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPostion.z = 0f;
        return mouseWorldPostion;
    }
}
