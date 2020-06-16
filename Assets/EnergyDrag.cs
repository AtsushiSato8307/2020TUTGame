using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrag : MonoBehaviour
{
    [SerializeField, Tooltip("マウスポインタに着けるエフェクト")]
    private GameObject MousePointObj;
    private GameController Controller;
    private ActionCost cost;
    private GameObject effect;
    private Vector3 TouchScreenPosition { get { return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.8f); } }
    private Vector3 EffectPosition { get { return Camera.main.ScreenToWorldPoint(TouchScreenPosition); } }
    private int is_Drag { get { return Controller.is_dragEnergyPoint; } set { Controller.is_dragEnergyPoint = value; } }
    // 処理遅延用
    private int nextFrameIs_Drag;

    // Start is called before the first frame update
    void Start()
    {
        var gameController = GameObject.FindGameObjectWithTag("GameController");
        Controller = gameController.GetComponent<GameController>();
        cost = gameController.GetComponent<ActionCost>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        is_Drag = nextFrameIs_Drag;
    }
    public void PointerDown()
    {
        effect = Instantiate(MousePointObj);
        effect.transform.position = EffectPosition;
        nextFrameIs_Drag = Controller.ReinforcedPoint;
    }
    public void Drag()
    {
        effect.transform.position = EffectPosition;
    }
    public void EndDrag()
    {
        Destroy(effect);
        nextFrameIs_Drag = 0;
    }
    /// <summary>レベル開放
    /// </summary>
    /// <param name="costnum">コスト表番号</param>
    public void ReleseLevel(int costnum)
    {
        // 仮
        if (is_Drag >= Controller.costs.ReinforcedCost[costnum])
        {
            Controller.ReinforcedPoint -= Controller.costs.ReinforcedCost[costnum];
        }
    }
}
