using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SlideButton : MonoBehaviour
{
    enum SlideType {
        Open,
        Close,
    }
    private SlideType type = SlideType.Close;
    private bool OnSlide;

    [SerializeField, Tooltip("使用するボタン")]
    private GameObject[] Buttons;

    [SerializeField, Tooltip("配置間隔")]
    private Vector3 setInterval;

    [SerializeField, Tooltip("Speed")]
    private float speed;

    [SerializeField, Tooltip("使用可能か否か")]
    private bool[] is_Interactives;

    // Start is called before the first frame update
    void Start()
    {
        var b = Buttons.Select((g, i) => new { i, g });
        foreach (var n in b)
        {
            n.g.SetActive(false);
            n.g.GetComponent<Button>().interactable = is_Interactives[n.i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        var b = Buttons.Select((g, i) => new { i, g });
        #region スライド処理
        if (OnSlide)
        {
            ButtonActive(true);
            switch (type)
            {
                case SlideType.Open:
                    foreach (var n in b)
                    {
                        // 配置場所につくまで移動
                        if (Vector3.Distance(n.g.transform.localPosition, (n.i + 1) * setInterval) > 1f)
                        {
                            n.g.transform.localPosition = Vector3.Lerp(n.g.transform.localPosition, (n.i + 1) * setInterval, Time.deltaTime * speed);
                            //n.g.transform.position += Vector3.Normalize(setInterval) * speed * Time.deltaTime;
                        }
                        if (Vector3.Distance(Buttons[Buttons.Length -1].gameObject.transform.localPosition, (Buttons.Length) * setInterval) < 2f)
                        {
                            OnSlide = false;  
                        }
                    }
                    break;
                case SlideType.Close:
                    foreach (var n in b)
                    {
                        // 配置場所につくまで移動
                        if (Vector3.Distance(n.g.transform.localPosition, Vector3.zero) > 1f)
                        {
                            n.g.transform.localPosition = Vector3.Lerp(n.g.transform.localPosition, Vector3.zero, Time.deltaTime * speed);
                            //n.g.transform.position += Vector3.Normalize(setInterval) * -speed * Time.deltaTime;
                        }
                        if(Vector3.Distance(Buttons[Buttons.Length -1].gameObject.transform.localPosition, Vector3.zero) < 2f)
                        {
                            OnSlide = false;
                            ButtonActive(false);
                        }
                    }
                    break;
            }
        }
        #endregion 
    }
    public void Slide()
    {
        OnSlide = true;
        if (type == SlideType.Open)
        {
            type = SlideType.Close;
        }
        else if (type == SlideType.Close)
        {
            type = SlideType.Open;
        }
    }
    public void SlideOpen()
    {
        OnSlide = true;
        type = SlideType.Open;
    }
    public void SlideClose()
    {
        OnSlide = true;
        type = SlideType.Close;
    }

    public void SwitchInteractive(int num)
    {
            Buttons[num].SetActive(false);
    }
    private void ButtonActive(bool set)
    {
        foreach (var i in Buttons)
        {
            i.SetActive(set);
        }
    }
}
