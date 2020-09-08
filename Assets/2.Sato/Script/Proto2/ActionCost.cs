using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActionCost : MonoBehaviour
{
    public int DefaltMoveCost;
    public int[] DefaltCanonCosts;
    public int[] DefaltCampCosts;
    public int[] DefaltSoldiorCost;
    static public Dictionary<string, int> ReinforcedCost;
    public int ReinforcedMoveCost;
    public int[] ReinforcedCanonCosts;
    public int[] ReinforcedCampCosts;
    public int ReinforcedSoldiorCost;
}
