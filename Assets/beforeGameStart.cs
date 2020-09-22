using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beforeGameStart : MonoBehaviour
{
    [Tooltip("開始前に説明資料を出すか")]
    public bool is_infomation;

    [SerializeField, Tooltip("説明資料")]
    private GameObject[] infos;

    [SerializeField, Tooltip("ぽち")]
    private Image[] potis;
    [SerializeField, Tooltip("ポチの光る色")]
    private Color poticolor;
    [SerializeField, Tooltip("ポチ光らない色")]
    private Color potinotcolor;

    private int currentInfoNum = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if (is_infomation)
        {
            StopGame();
            ActiveControll(currentInfoNum);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        StopGame();
    }
    void StopGame()
    {
        Time.timeScale = 0;
    }
    void StartGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
    public void End()
    {
        StartGame();
    }
    public void Next()
    {
        if (currentInfoNum < infos.Length -1)
        {
            currentInfoNum++;
            ActiveControll(currentInfoNum);
        }
        else
        {
            currentInfoNum = 0;
            ActiveControll(currentInfoNum);
            StartGame();
        }

    }
    public void Back()
    {
        if (currentInfoNum > 0)
        {
            currentInfoNum--;
            ActiveControll(currentInfoNum);
        }
    }
    private void ActiveControll(int num)
    {
        foreach (var i in infos)
        {
            i.SetActive(false);
        }
        infos[currentInfoNum].SetActive(true);
        PotiColorChange();
    }
    private void PotiColorChange()
    {
        foreach (var i in potis)
        {
            i.color = potinotcolor;
        }
        potis[currentInfoNum].color = poticolor;
    }

}
