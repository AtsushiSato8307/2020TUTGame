using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashImage : MonoBehaviour
{
    private Image image;
    [SerializeField, Tooltip("点滅時間")]
    private float FlashTime = 3;
    private float defMaxAlpha;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        defMaxAlpha = image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, (defMaxAlpha / 1)
            * Mathf.Abs(Mathf.Sin(Time.time / FlashTime)));
    }
}
