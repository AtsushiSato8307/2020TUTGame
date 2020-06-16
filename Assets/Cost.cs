using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Cost : ScriptableObject
{
    [SerializeField]
    public int DefaltMoveCost;
    public int[] DefaltCanonCosts;
    public int[] DefaltCampCosts;
    public int DefaltSoldiorCost;
    // 移動0,1,2 大砲 3,4,5 拠点 6,7,8 兵士 9,10,11
    public int[] ReinforcedCost;
}
