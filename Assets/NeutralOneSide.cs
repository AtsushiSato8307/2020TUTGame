using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralOneSide : MonoBehaviour
{
    [SerializeField, Tooltip("施設のオブジェクト")]
    private GameObject building;

    public bool buildingIntaractive = false;

    private bool changeCheck;

    // Start is called before the first frame update
    void Start()
    {
        building.SetActive(buildingIntaractive);
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingIntaractive != changeCheck)
        {
            building.SetActive(buildingIntaractive);
        }
        changeCheck = buildingIntaractive;
    }
}
