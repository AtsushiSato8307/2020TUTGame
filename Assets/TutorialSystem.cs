using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSystem : MonoBehaviour
{
    // いいね
    [SerializeField, Tooltip("良いね画像")]
    private Image okImage;
    [SerializeField,Tooltip("画像表示時間")]
    private float oktime = 3;
    [SerializeField, Tooltip("画像消滅時間")]
    private float okdistime = 2;

    private float oktimer = 0;

    // イベント管理
    private int EventNum;
    public int CurrentEventNum = 0;
    [SerializeField]
    private GameObject[] TutorialUiObjects;
    [SerializeField]
    private GameObject[] TutorialGameObjects;



    // Start is called before the first frame update
    void Start()
    {
        okImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentEventNum)
        {
            case 0:
                CurrentEventNum++;
                break;
            case 1: // 移動チュートリアル
                if(TutorialUiObjects[0].activeSelf == false)
                {
                    TutorialUiObjects[0].SetActive(true);
                }
                if (TutorialGameObjects[0].activeSelf == false)
                {
                    TutorialGameObjects[0].SetActive(true);
                }
                break;
            case 2: // キャンプチュートリアル
                // 1終了処理
                if (TutorialUiObjects[0].activeSelf == true)
                {
                    TutorialUiObjects[0].SetActive(false);
                }
                if (TutorialGameObjects[0].activeSelf == true)
                {
                    TutorialGameObjects[0].SetActive(false);
                }
                // 2開始処理
                if (TutorialUiObjects[1].activeSelf == false)
                {
                    TutorialUiObjects[1].SetActive(true);
                }
                // 2main処理
                if (GameObject.Find("Camp1(Clone)"))
                {
                    EnubledOk();
                    CurrentEventNum++;
                }
                break;
            case 3:
                // 2終了処理
                if (TutorialUiObjects[1].activeSelf == true)
                {
                    TutorialUiObjects[1].SetActive(false);
                }
                // 3開始処理
                if (TutorialUiObjects[2].activeSelf == false)
                {
                    TutorialUiObjects[2].SetActive(true);
                }
                // 3main処理
                if (GameObject.Find("Canon1(Clone)"))
                {
                    EnubledOk();
                    CurrentEventNum++;
                }
                break;
            case 4:
                // 3終了処理
                if (TutorialUiObjects[2].activeSelf == true)
                {
                    TutorialUiObjects[2].SetActive(false);
                }
                // 4開始処理
                if (TutorialUiObjects[3].activeSelf == false)
                {
                    TutorialUiObjects[3].SetActive(true);
                }
                // 4main処理
                if (GameObject.Find("Soldior(Clone)"))
                {
                    EnubledOk();
                    CurrentEventNum++;
                }
                break;
            case 5:
                // 4終了処理
                if (TutorialUiObjects[3].activeSelf == true)
                {
                    TutorialUiObjects[3].SetActive(false);
                }
                break;
        }



        // UI表示処理
        if (Input.GetKey(KeyCode.U))
        {
            EnubledOk();
        }
        if (okImage.enabled == true)
        {
            oktimer -= Time.deltaTime;
            okImage.color = new Color(1, 1, 1, oktimer / okdistime);
            if (oktimer <= 0)
            {
                okImage.enabled = false;
            }
        }
    }
    public void EnubledOk()
    {
        oktimer = okdistime + oktime;
        okImage.enabled = true;
        okImage.color = new Color(1, 1, 1, 1);
    }
}
