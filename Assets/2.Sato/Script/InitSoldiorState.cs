using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 兵士の初期ステータス
public class InitSoldiorState : MonoBehaviour
{
    [SerializeField, Tooltip("兵種")]
    public Soldiortype type;
}
