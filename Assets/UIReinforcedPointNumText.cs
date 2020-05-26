using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReinforcedPointNumText : MonoBehaviour
{
    private GameController Controller;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text = GetComponent<Text>();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }
    private void SetText()
    {
        text.text = Controller.ReinforcedPoint.ToString();
    }
}
