using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReinforcedPointNumText : MonoBehaviour
{
    private GameController Controller;
    private Text text;
    [SerializeField]
    private GameObject[] gagechild;
    private bool is_Change = false;
    private int repoint;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponent<Text>();
        SetText();
        repoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (repoint != Controller.ReinforcedPoint)
        {
            SetText();
        }
        repoint = Controller.ReinforcedPoint;
    }
    private void SetText()
    {
        text.text = Controller.ReinforcedPoint.ToString();
        for (int i = 0; i < gagechild.Length; i++)
        {
            if (i < Controller.ReinforcedPoint)
            {
                if (gagechild[i].activeSelf == false)
                {
                    gagechild[i].SetActive(true);
                }
            }
            else {
                if (gagechild[i].activeSelf == true)
                {
                    gagechild[i].SetActive(false);
                }
            }
        }
    }
}
