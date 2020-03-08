using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Soldiortype
{
    VanillaSol = 0,    //雑兵
    Carpenter = 1,  //大工
    Mercenary = 2   //槍兵
}
public class SetSoldior : MonoBehaviour
{

    private SoldiorManager manager;

    [SerializeField, Tooltip("兵種")]
    private GameObject[] setSoldiorPrefs = null;

    [SerializeField, Tooltip("隊列配置")]
    private GameObject SetPoints = null;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<SoldiorManager>();
        SoldiorSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SoldiorSet()
    {
        for (int i = 0; i < manager.SoldiorArray.Length; i++)
        {
            // 雑兵をセット、生成
            GameObject node = SetPoints.GetComponent<SetSoldiorPoints>().node[i];
            manager.SoldiorArray[i] = Instantiate(setSoldiorPrefs[(int)node.GetComponent<InitSoldiorState>().type]);
            manager.SoldiorArray[i].GetComponent<Soldior>().OffsetPosition = node.GetComponent<Transform>().position;
        }
        manager.ExsistenceCheck();
    }
}
