using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    // Start is called before the first frame update
    void Start()
    {
        foreach (var i in Buttons)
        {
            i.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        var b = Buttons.Select((g, i) => new { i, g });
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
    private void ButtonActive(bool set)
    {
        foreach (var i in Buttons)
        {
            i.SetActive(set);
        }
    }
}
