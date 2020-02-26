using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ActionType
{
    None,
    Move,
    SetCanon,
    SetCamp
}
public class ActiveAction : MonoBehaviour
{
    // ゲームコントローラー
    private GameController controller;
    // コスト
    private ActionCost cost;
    // 現在選択されている状態
    public ActionType currentType;
    // クリックした場所
    private Vector3 clickPosition;
    // 修正後の位置
    private Vector3 SetPosition;
    // プレイヤーの移動
    private PlayerMove playerMove;
    // レイの距離
    private float rayRange = 100f;

    [SerializeField, Tooltip("大砲のプレファブ")]
    private GameObject Canon;
    [SerializeField, Tooltip("キャンプのプレファブ")]
    private GameObject Camp;
    // Start is called before the first frame update
    void Start()
    {
        cost = GetComponent<ActionCost>();
        controller = GetComponent<GameController>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        currentType = ActionType.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // 左クリック
        if (Input.GetMouseButtonDown(0))
        {
            // クリックした位置の取得
            GetClickPosition();
            // アクション処理
            // 移動
            if (currentType == ActionType.Move)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltMoveCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltMoveCost;
                    playerMove.MovePlayer(SetPosition);
                }
            }
            // 大砲
            if (currentType == ActionType.SetCanon)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltCanonCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltCanonCost;
                    Instantiate(Canon, SetPosition, Quaternion.identity);
                }
            }
            // キャンプ
            if (currentType == ActionType.SetCamp)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltCampCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltCampCost;
                    Instantiate(Camp, SetPosition, Quaternion.identity);
                }
            }
            // アクションタイプを未選択に
            currentType = ActionType.None;
        }
    }
    private void GetClickPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field")))
        {
            clickPosition = hit.point;
        }
        // y軸修正
        SetPosition = new Vector3(clickPosition.x, 0.5f, clickPosition.z);

    }
    public void SetType(int setType)
    {
        currentType = (ActionType)setType;
    }
}
