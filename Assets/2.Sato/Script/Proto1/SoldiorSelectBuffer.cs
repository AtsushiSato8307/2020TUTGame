using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiorSelectBuffer : MonoBehaviour
{
    public Soldiortype selectSoldiorType;
    public void SetSolType(int type)
    {
        selectSoldiorType = (Soldiortype)type;
    }

    public int selectNum;
    public void SetNum(int num)
    {
        selectNum = num;
    }

    [SerializeField, Tooltip("カーソル")]
    private GameObject cursol = null;
    public Transform selectTransform { get { return cursol.GetComponent<CursolEvent>().SelectObjTransform; } }

}
