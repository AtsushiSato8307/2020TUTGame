using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCostActive : MonoBehaviour
{
    // とりあえず移動限定で作っとく
    private GameController controller;
    private Cost cost;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        button = GetComponent<Button>();
        cost = controller.costs;
    }

    // Update is called once per frame
    void Update()
    {
        if (cost.DefaltMoveCost > controller.CurrentSoldiorNum && button.interactable)
        {
            button.interactable = false;
        }
        else if (cost.DefaltMoveCost <= controller.CurrentSoldiorNum && !button.interactable)
        {
            button.interactable = true;
        }
    }
}
