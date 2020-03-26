using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitPointUI : MonoBehaviour
{
    private GameObject canvas;
    private GameObject CanvasObj;
    private Slider slider;

    [SerializeField, Tooltip("位置調整")]
    private Vector3 OffsetPosition = new Vector3(0,0,1);

    [SerializeField, Tooltip("サイズ調整")]
    private Vector3 Size = new Vector3(0.02f, 0.015f, 0);

    private Transform CanvasTransform { get { return CanvasObj.transform; } }

    public int MaxHitPoint { set; private get; }

    public int CurrentHitPoint { set; private get; }

    // Start is called before the first frame update
    void Start()
    {
        // CanvasをLoad
        canvas = (GameObject)Resources.Load("Prefab/HPUICanvas");
        // Canvasを子要素に生成
        CanvasObj = Instantiate(canvas, transform.position, Quaternion.identity);
        CanvasTransform.SetParent(this.transform);
        // sliderの取得
        slider = CanvasTransform.GetChild(0).GetComponent<Slider>();

        FixedUITransform();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = MaxHitPoint;
        slider.value = CurrentHitPoint;
        FixedUITransform();
    }
    #region UIのTransform修正
    private void FixedUITransform()
    {
        FixedDirection();
        FixedSize();
        FixedPosition();
    }

    // UIの向き修正
    private void FixedDirection()
    {
        CanvasTransform.LookAt(Camera.main.transform.position);
        CanvasTransform.eulerAngles = new Vector3(90, 0, transform.eulerAngles.z);
    }
    // UIのサイズ修正
    private void FixedSize()
    {
        CanvasTransform.localScale = Size;
    }
    // UIの位置修正
    private void FixedPosition()
    {
        CanvasTransform.position = transform.position + OffsetPosition;
    }
    #endregion

    /// <summary>HPの設定
    /// </summary>
    /// <param name="max">最大値</param>
    /// <param name="current">現在値</param>
    public void SetHitPoint(int max, int current)
    {
        MaxHitPoint = max;
        CurrentHitPoint = current;
    }
    private void OnEnable()
    {
        if (CanvasObj != null)
        {
            CanvasObj.SetActive(true);
        }
    }
    private void OnDisable()
    {
        if (CanvasObj != null)
        {
            CanvasObj.SetActive(false);
        }
    }

}
