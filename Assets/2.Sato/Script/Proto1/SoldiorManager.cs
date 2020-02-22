using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldiorManager : MonoBehaviour
{
    [SerializeField, Tooltip("軍団の人数")]
    public int SoldiorNumber;

    public int VanillaSolNum;

    public int CarpenterNum;

    public int MercenaryNum;

    [SerializeField, Tooltip("軍団の配列")]
    public GameObject[] SoldiorArray;

    [SerializeField, Tooltip("カウンター")]
    private Text counter;
    public Text Counter { get => counter; set => counter = value; }

    // Start is called before the first frame update
    void Awake()
    {
        SoldiorArray = new GameObject[SoldiorNumber];
    }

    // Update is called once per frame
    void Update()
    {
        Counter.text = SoldiorNumber.ToString() + "人";
    }

    /// <summary>兵士の内約をチェックする
    /// </summary>
    public void ExsistenceCheck()
    {
        // 初期化
        SoldiorNumber = 0;
        VanillaSolNum = 0;
        CarpenterNum = 0;
        MercenaryNum = 0;
        for (int i = 0; i < SoldiorArray.Length; i++)
        {
            ++SoldiorNumber;
            var type = SoldiorArray[i].GetComponent<Soldior>().type;
            if (type == Soldiortype.VanillaSol)
            {
                ++VanillaSolNum;
            }
            else if (type == Soldiortype.Carpenter)
            {
                ++CarpenterNum;
            }
            else if (type == Soldiortype.Mercenary)
            {
                ++MercenaryNum;
            }
            else
            {
            }
        }
    }
    public void TargetSoldior()
    {
        var buffer = GetComponent<SoldiorSelectBuffer>(); 

        for (int i = 0; i < SoldiorArray.Length; i++)
        {
            var type = SoldiorArray[i].GetComponent<Soldior>().type;
            if (type == buffer.selectSoldiorType)
            {
                SoldiorArray[i].GetComponent<SoldiorMove>().TargetPosition = buffer.selectTransform.position;
                SoldiorArray[i].GetComponent<Soldior>().moveState = SoldiorMoveState.Target;
            }
        }
    }
}
