using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrag : MonoBehaviour
{
    [SerializeField, Tooltip("マウスポインタに着けるエフェクト")]
    private GameObject MousePointObj;

    private GameController Controller;
    private GameObject effect;
    private Vector3 TouchScreenPosition { get { return new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.8f); } }
    private Vector3 EffectPosition { get { return Camera.main.ScreenToWorldPoint(TouchScreenPosition); } }

    private bool is_Drag;
    // 処理遅延用
    private bool t;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(is_Drag);
    }
    private void LateUpdate()
    {
        is_Drag = t;
    }
    public void PointerDown()
    {
        effect = Instantiate(MousePointObj);
        effect.transform.position = EffectPosition;
        t = true;
    }
    public void Drag()
    {
        effect.transform.position = EffectPosition;
    }
    public void EndDrag()
    {
        Destroy(effect);
        t = false;
    }
    /// <summary>レベル開放
    /// </summary>
    /// <param name="cost">必要コスト</param>
    public void ReleseLevel(int cost)
    {
        if (is_Drag == true)
        {
            Controller.ReinforcedPoint -= cost;
        }
    }
}
