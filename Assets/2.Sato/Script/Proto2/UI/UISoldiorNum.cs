using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoldiorNum : MonoBehaviour
{
    private GameController Controller;

    [SerializeField, Tooltip("兵士最大数UI")]
    private GameObject UIMaxSoldiorNum;

    private Text maxText;

    [SerializeField, Tooltip("現兵士数UI")]
    private GameObject UICurrentSoldiorNum = default;

    private Text currentText;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        maxText = UIMaxSoldiorNum.GetComponent<Text>();
        currentText = UICurrentSoldiorNum.GetComponent<Text>();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
    }
    private void SetText()
    { 
        maxText.text = Controller.MaxSoldiorNum.ToString();
        currentText.text = Controller.CurrentSoldiorNum.ToString();
    }
}
