using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // エネルギーをドラッグしているか, 運んでいるエネルギーのポイント量
    public int is_dragEnergyPoint;

    [SerializeField,Tooltip("現兵士数")]
    public int CurrentSoldiorNum;

    [SerializeField, Tooltip("最大兵士数")]
    public int MaxSoldiorNum;

    [SerializeField, Tooltip("強化ポイント")]
    public int ReinforcedPoint;

    [SerializeField, Tooltip("強化収集位置オブジェト")]
    public Transform reinforcedPointObj;

    [SerializeField, Tooltip("コスト値")]
    public Cost costs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
