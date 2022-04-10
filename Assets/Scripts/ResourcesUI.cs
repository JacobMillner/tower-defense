using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    private ResourceTypeListSO resourceTypeList;

    private Dictionary<ResourceTypeSO, Transform>
        resourceTypeTransformDictionary;

    void Awake()
    {
        resourceTypeList =
            Resources
                .Load<ResourceTypeListSO>(typeof (ResourceTypeListSO).Name);

        resourceTypeTransformDictionary =
            new Dictionary<ResourceTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("ResourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform =
                Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(offsetAmount * index, 0);

            resourceTransform.Find("image").GetComponent<Image>().sprite =
                resourceType.sprite;

            resourceTypeTransformDictionary[resourceType] = resourceTransform;

            index++;
        }
    }

    private void Start()
    {
        ResourceManager.Instance.OnResourceAmountChanged +=
            ResourceManage_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManage_OnResourceAmountChanged(
        object sender,
        System.EventArgs e
    )
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform =
                resourceTypeTransformDictionary[resourceType];

            int resourceAmount =
                ResourceManager.Instance.GetResourceAmount(resourceType);
            resourceTransform
                .Find("text")
                .GetComponent<TextMeshProUGUI>()
                .SetText(resourceAmount.ToString());
        }
    }
}
