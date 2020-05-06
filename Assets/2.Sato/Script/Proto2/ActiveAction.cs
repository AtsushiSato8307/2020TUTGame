using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ActionType
{
    None,
    Move,
    SetCanon1,
    SetCamp1,
    SetSoldior1,
    SetCanon2,
    SetCamp2,
    SetSoldior2,
    SetCanon3,
    SetCamp3,
    SetSoldior3
}
public class ActiveAction : MonoBehaviour
{
    // ゲームコントローラー
    private GameController controller;
    // コスト
    private ActionCost cost;
    // 現在選択されている状態
    public ActionType currentType;
    // 現在選択されているレベル
    public int currentLevel;
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

    private Vector3 PlayerPosition { get { return GameObject.FindGameObjectWithTag("Player").transform.position; } }

    [SerializeField, Tooltip("工兵")]
    private GameObject Carpenter;
    [SerializeField, Tooltip("大砲のプレファブ")]
    private GameObject[] Canon = null;
    [SerializeField, Tooltip("キャンプのプレファブ")]
    private GameObject[] Camp = null;
    [SerializeField, Tooltip("兵士のプレファブ")]
    public GameObject[] Soldior = null;

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
        // マウスのフィールドの位置の取得
        MouseFieldPosition();

        // UIをクリックしていたらリターン
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // 左クリック
        if (Input.GetMouseButtonDown(0))
        {

            // クリックした位置がアクション可能位置であるか？

            // アクション処理
            // 移動
            // Playerと射線が通っているか
            Debug.Log(RayToPlayer());
            if (!RayToPlayer())
            {
                if (currentType == ActionType.Move)
                {
                    // 既に移動中
                    if (is_Move == true)
                    {
                        playerMove.MovePlayer(SetPosition, () =>
                        {
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
                            playerMove.MovePlayer(SetPosition, () =>
                            {
                                controller.CurrentSoldiorNum += cost.DefaltMoveCost;
                                is_Move = false;
                            });
                        }
                    }
                }
            }
            // 大砲
            if (currentType == ActionType.SetCanon1)
            {
                SetCanon(currentLevel);
            }
            // キャンプ
            if (currentType == ActionType.SetCamp1)
            {
                SetCamp(currentLevel);
            }
            // 兵士
            if (currentType == ActionType.SetSoldior1)
            {
                SetSoldior(currentLevel);
            }
            // アクションタイプを未選択に
            currentType = ActionType.None;
        }
    }
    private void SetCanon(int Level)
    {
        if (controller.CurrentSoldiorNum > cost.DefaltCanonCosts[Level - 1])
        {
            controller.CurrentSoldiorNum -= cost.DefaltCanonCosts[Level - 1];
            var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            var Car = Instantiate(Carpenter, PlayerPosition, Quaternion.identity);
            var CarNav = Car.GetComponent<CarpenterNavMove>();
            CarNav.AddPoints(SetPosition);
            CarNav.SetBilding(() => Instantiate(Canon[Level -1], Car.transform.position, Quaternion.identity));
        }
    }
    private void SetCamp(int Level)
    {
        if (controller.CurrentSoldiorNum > cost.DefaltCampCosts[Level - 1])
        {
            controller.CurrentSoldiorNum -= cost.DefaltCampCosts[Level - 1];
            var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            var Car = Instantiate(Carpenter, PlayerPosition, Quaternion.identity);
            var CarNav = Car.GetComponent<CarpenterNavMove>();
            CarNav.AddPoints(SetPosition);
            CarNav.SetBilding(() => Instantiate(Camp[Level -1], Car.transform.position, Quaternion.identity));
        }
    }
    private void SetSoldior(int Level)
    {
        if (controller.CurrentSoldiorNum > cost.DefaltSoldiorCost)
        {
            controller.CurrentSoldiorNum -= cost.DefaltSoldiorCost;
            var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            var sol = Instantiate(Soldior[0], PlayerPosition, Quaternion.identity);
            sol.GetComponent<SoldiorNavMove>().AddPoints(SetPosition);
        }
    }
    private void MouseFieldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field")))
        {
            clickPosition = hit.point;
        }
        // y軸修正
        SetPosition = new Vector3(clickPosition.x, 0.5f, clickPosition.z);

    }
    private bool RayToPlayer()
    {
        bool Ray = Physics.Raycast(PlayerPosition, Vector3.Normalize(SetPosition - PlayerPosition), Vector3.Distance(PlayerPosition, SetPosition), LayerMask.GetMask("Wall")) ;
        return Ray;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(PlayerPosition, SetPosition - PlayerPosition);
    }
    public void SetType(int setType)
    {
        currentType = (ActionType)setType;
    }
    public void SetLevel(int setLevel)
    {
        currentLevel = setLevel;
    }
}
