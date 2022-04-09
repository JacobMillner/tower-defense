using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;

    private BuildingTypeListSO buildingTypeList;

    private BuildingTypeSO buildingType;

    void Start()
    {
        mainCamera = Camera.main;
        buildingTypeList =
            Resources
                .Load<BuildingTypeListSO>(typeof (BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[0];
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(buildingType.prefab,
            GetMouseWorldPosition(),
            Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
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
