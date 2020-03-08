using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeUI : MonoBehaviour
{
    private GameObject CanvasObj;
    private Slider slider;

    [SerializeField, Tooltip("位置調整")]
    private Vector3 OffsetPosition = Vector3.zero;

    [SerializeField, Tooltip("サイズ調整")]
    private Vector3 Size = Vector3.zero;

    [SerializeField, Tooltip("キャンバスのプレファブ")]
    private GameObject canvas = null;

    private Transform CanvasTransform { get { return CanvasObj.transform; } }

    public float MaxTime { set; private get; }

    public float CurrentTime { set; private get; }

    // Start is called before the first frame update
    void Start()
    {
        // Canvasを子要素に生成
        CanvasObj = Instantiate(canvas, transform.position, Quaternion.identity);
        CanvasTransform.parent = transform;
        // sliderの取得
        slider = CanvasTransform.GetChild(0).GetComponent<Slider>();

        FixedUITransform();
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = MaxTime;
        slider.value = CurrentTime;
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

    /// <summary>Timeの設定
    /// </summary>
    /// <param name="max">最大値</param>
    /// <param name="current">現在値</param>
    public void SetCoolTime(float max, float current)
    {
        MaxTime = max;
        CurrentTime = current;
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
