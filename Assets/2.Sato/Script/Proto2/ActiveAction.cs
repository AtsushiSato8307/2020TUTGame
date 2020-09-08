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
    // マウスドロワー
    private MouseDrawer drawer;
    // コスト
    private ActionCost cost;
    private GameObject player;

    // 現在選択されている状態
    public ActionType currentType;
    // 現在選択されているレベル
    public int currentLevel;
    // フィールド上のマウスの位置
    private Vector3 SetPosition;
    // プレイヤーの移動
    private PlayerMove playerMove;
    // レイの距離
    private float rayRange = 100f;
    // 現在移動に人員を割いているか
    private bool is_Move = false;
    // Playerと射線が通っているか
    private bool rayToPlayer;
    // Action可能位置であるか
    private bool canAction;
    // 池か
    private bool is_Lake;
    // 移動可能か
    private bool canMove;

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
        drawer = GetComponent<MouseDrawer>();
        cost = GetComponent<ActionCost>();
        controller = GetComponent<GameController>();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerMove = player.GetComponent<PlayerMove>();
        }
        currentType = ActionType.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        // アクション選択中に限りチェックする項目 /////////////////////
        if (currentType != ActionType.None)
        {
            // マウスのフィールドの位置の取得
            // マウスの位置がアクション可能位置であるか？
            canAction = MouseFieldPosition();

            // Playerと射線が通っているか
            rayToPlayer = RayToPlayer();

            // 移動可能か
            canMove = canAction && rayToPlayer && !is_Lake;

        }
        //////////////////////////////////////////////////////////////

        // マウス用UI処理
        drawer.SetDrawerStatas(currentType, SetPosition, canMove);

        // UIをクリックしていたらリターン
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // 左クリック
        if (Input.GetMouseButtonDown(0))
        {
            ClickAction();
        }
    }
    private void ClickAction()
    {
        // アクション処理
        // 移動
        if (canMove)
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
        if (canAction)
        {
            // 大砲
            if (currentType == ActionType.SetCanon)
            {
                SetCanon(currentLevel);
            }
            // キャンプ
            if (currentType == ActionType.SetCamp)
            {
                SetCamp(currentLevel);
            }
            // 兵士
            if (currentType == ActionType.SetSoldior)
            {
                SetSoldior(currentLevel);
            }
        }
        // アクションタイプを未選択に
        currentType = ActionType.None;
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
            CarNav.SetBilding(() => Instantiate(Canon[Level - 1], Car.transform.position, Quaternion.identity),
                () => controller.CurrentSoldiorNum += cost.DefaltCampCosts[Level - 1]);
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
            CarNav.SetBilding(() => Instantiate(Camp[Level - 1], Car.transform.position, Quaternion.identity),
                () => controller.CurrentSoldiorNum += cost.DefaltCampCosts[Level - 1]);
        }
    }
    private void SetSoldior(int Level)
    {
        if (controller.CurrentSoldiorNum > cost.DefaltSoldiorCost[Level -1])
        {
            controller.CurrentSoldiorNum -= cost.DefaltSoldiorCost[Level - 1];
            var PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            var sol = Instantiate(Soldior[Level - 1], PlayerPosition, Quaternion.identity);
            sol.GetComponent<SoldiorNavMove>().AddPoints(SetPosition);
        }
    }
    private bool MouseFieldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 clickPosition = new Vector3();
        bool m_canAction = false;
        if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field") | 11))
        {
            clickPosition = hit.point;
            is_Lake = hit.collider.CompareTag("Lake");
            m_canAction = hit.collider.CompareTag("Field") || hit.collider.CompareTag("Lake");
        }
        // y軸修正
        SetPosition = new Vector3(clickPosition.x, 0.5f, clickPosition.z);
        return m_canAction;
    }
    private bool RayToPlayer()
    {
        bool Ray = Physics.Raycast(PlayerPosition, Vector3.Normalize(SetPosition - PlayerPosition), Vector3.Distance(PlayerPosition, SetPosition), LayerMask.GetMask("Wall"));
        return !Ray;
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
