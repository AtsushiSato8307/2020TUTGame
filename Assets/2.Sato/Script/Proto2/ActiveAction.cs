using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ActionType
{
    None,
    Move,
    SetCanon,
    SetCamp,
    SetSoldior
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
    // 現在移動に人員を割いているか
    private bool is_Move = false;

    [SerializeField, Tooltip("工兵")]
    private GameObject Carpenter;
    [SerializeField, Tooltip("大砲のプレファブ")]
    private GameObject Canon = null;
    [SerializeField, Tooltip("キャンプのプレファブ")]
    private GameObject Camp = null;
    [SerializeField, Tooltip("兵士のプレファブ")]
    public GameObject Soldior = null;

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
                // 既に移動中
                if (is_Move == true)
                {
                    playerMove.MovePlayer(SetPosition, () => {
                        controller.CurrentSoldiorNum += cost.DefaltMoveCost;
                        is_Move = false;
                    });
                }
                // 移動していない
                else
                {
                    if (controller.CurrentSoldiorNum > cost.DefaltMoveCost)
                    {
                        is_Move = true;
                        controller.CurrentSoldiorNum -= cost.DefaltMoveCost;
                        playerMove.MovePlayer(SetPosition, () => {
                            controller.CurrentSoldiorNum += cost.DefaltMoveCost;
                            is_Move = false;
                        });
                    }
                }
            }
            // 大砲
            if (currentType == ActionType.SetCanon)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltCanonCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltCanonCost;
                    var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                    var Car = Instantiate(Carpenter, PlayerPosition, Quaternion.identity);
                    var CarNav = Car.GetComponent<CarpenterNavMove>();
                    CarNav.AddPoints(SetPosition);
                    CarNav.SetBilding(() => Instantiate(Canon, Car.transform.position, Quaternion.identity));
                }
            }
            // キャンプ
            if (currentType == ActionType.SetCamp)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltCampCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltCampCost;
                    var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                    var Car = Instantiate(Carpenter, PlayerPosition, Quaternion.identity);
                    var CarNav = Car.GetComponent<CarpenterNavMove>();
                    CarNav.AddPoints(SetPosition);
                    CarNav.SetBilding(() => Instantiate(Camp, Car.transform.position, Quaternion.identity));
                }
            }
            // 兵士
            if (currentType == ActionType.SetSoldior)
            {
                if (controller.CurrentSoldiorNum > cost.DefaltCampCost)
                {
                    controller.CurrentSoldiorNum -= cost.DefaltSoldiorCost;
                    var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                    var sol = Instantiate(Soldior, PlayerPosition, Quaternion.identity);
                    sol.GetComponent<SoldiorNavMove>().AddPoints(SetPosition);
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
