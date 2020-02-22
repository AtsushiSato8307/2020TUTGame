using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ActionType
{
    None,
    Move,
    SetObj
}
public class ActiveAction : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayRange, LayerMask.GetMask("Field")))
            {
                clickPosition = hit.point;
            }
            // y軸修正
            SetPosition = new Vector3(clickPosition.x, 0.5f, clickPosition.z);

            // アクション処理
            if (currentType == ActionType.Move)
            {
                playerMove.MovePlayer(SetPosition);
            }
            if (currentType == ActionType.SetObj)
            {
                Instantiate(Canon, SetPosition, Quaternion.identity);
            }
            // アクションタイプを未選択に
            currentType = ActionType.None;
        }
    }
    public void SetType(int setType)
    {
        currentType = (ActionType)setType;
    }
}
