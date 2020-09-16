using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDrawer : MonoBehaviour
{
    private LineRenderer line;

    private ActionType type;
    private Vector3 setPosition;
    private bool canmove;
    private Text text;
    private GameObject obj;
    private Image image;

    [SerializeField, Tooltip("マテリアル１")]
    private Material blue;
    [SerializeField, Tooltip("マテリアル2")]
    private Material red;
    [SerializeField, Tooltip("UI用オフセット")]
    private Vector3 offSet;
    [SerializeField, Tooltip("UIオブジェクト")]
    private GameObject uiObj;
    [SerializeField, Tooltip("施設用UIオブジェクト")]
    private GameObject buildUiObj;
    [SerializeField, Tooltip("大砲")]
    private Sprite canonimage;
    [SerializeField, Tooltip("拠点")]
    private Sprite kyoten;
    [SerializeField, Tooltip("兵士")]
    private Sprite heisi;
    [SerializeField, Tooltip("OK")]
    private Sprite okimage;
    [SerializeField, Tooltip("NoneSprite")]
    private Sprite Clear;

    private Vector3 PlayerPosition { get { if (GameObject.FindGameObjectWithTag("Player") != null) return GameObject.FindGameObjectWithTag("Player").transform.position; else return Vector3.zero; } }

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        uiObj.transform.position = Input.mousePosition + offSet;
        text = uiObj.transform.GetChild(0).GetComponent<Text>();
        image = buildUiObj.GetComponent<Image>();
        //線の幅を決める
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        //頂点の数を決める
        line.positionCount = 2;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        uiObj.transform.position = Input.mousePosition + offSet;
        buildUiObj.transform.position = Input.mousePosition + offSet;


        if (type == ActionType.Move)
        #region 移動時
        {
            //uiObj.SetActive(true);
            buildUiObj.SetActive(true);
            line.enabled = true;
            if (canmove)
            {
                //text.text = "移動可能";
                image.sprite = okimage;
                text.color = Color.blue;
                line.material = blue;
            }
            else
            {
                //text.text = "移動不可";
                image.sprite = Clear;
                text.color = Color.red;
                line.material = red;
            }
            DrawLine(PlayerPosition, setPosition);
        }
        else
        {
            //uiObj.SetActive(false);
            buildUiObj.SetActive(false);
            line.enabled = false;
        }
        #endregion
        if (!(type == ActionType.None || type == ActionType.Move))
        {
            //uiObj.SetActive(true);
            buildUiObj.SetActive(true);
            switch (type)
            {
                case ActionType.SetCamp:
                    //text.text = "拠点設置";
                    image.sprite = kyoten;
                    break;
                case ActionType.SetCanon:
                    //text.text = "大砲設置";
                    image.sprite = canonimage;
                    break;
                case ActionType.SetSoldior:
                    //text.text = "兵士派遣";
                    image.sprite = heisi;
                    break;
            }
        }

    }
    public void DrawLine(Vector3 p1, Vector3 p2)
    {
        line.SetPosition(0, p1);
        line.SetPosition(1, p2);
    }

    public void SetDrawerStatas(ActionType type, Vector3 setPosition, bool canmove)
    {
        this.type = type;
        this.setPosition = setPosition;
        this.canmove = canmove;
    }
}
