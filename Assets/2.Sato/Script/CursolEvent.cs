using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursolEvent : MonoBehaviour
{
    [SerializeField, Tooltip("タッチする位置")]
    private Transform touchPosition;
    [SerializeField, Tooltip("セレクトタブ")]
    private GameObject selectTab;

    public Transform SelectObjTransform;
    // Start is called before the first frame update
    void Start()
    {
        selectTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ヒット確認
        bool is_hit = HitCheck();

        // セレクト処理
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (is_hit)
            {
                Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeSelect();
        }
    }
    private bool HitCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30.0f))
        {
            if (hit.collider != null)
            {
                // ギミックなら
                if (hit.collider.CompareTag("Gimmick"))
                {
                    SelectObjTransform = hit.collider.GetComponent<Transform>();
                    GetComponent<Image>().color = Color.green;
                    return true;
                }
            }
        }
        // ヒットしていない時の処理
        GetComponent<Image>().color = Color.white;
        return false;
    }
    private void Select()
    {
        selectTab.SetActive(true);
        GetComponent<CursolMove>().Lock(true);
    }
    public void DeSelect() {
        selectTab.SetActive(false);
        GetComponent<CursolMove>().Lock(false);
    }
}
