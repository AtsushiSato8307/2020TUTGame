using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiorMotion : MonoBehaviour
{
    public enum SoldiorMotionState
    {
        Wait,
        Walk,
        Attack
    }
    public SoldiorMotionState m_state;
    private SoldiorMotionState beforeState;

    [SerializeField, Tooltip("停止モデル")]
    private GameObject StopMotion;
    [SerializeField, Tooltip("移動モデル")]
    private GameObject WalkMotion;
    [SerializeField, Tooltip("攻撃モデル")]
    private GameObject AttackMotion;

    [SerializeField, Tooltip("移動音")]
    private CriAtomSource moveAudio;
    // Start is called before the first frame update
    void Start()
    {
        m_state = SoldiorMotionState.Wait;
        SetMotion();
    }

    // Update is called once per frame
    void Update()
    {
        // 前フレームと違ったら
        if (beforeState != m_state)
        {
            SetMotion();
        }
        if (m_state == SoldiorMotionState.Walk)
        {
            if (moveAudio.status != CriAtomSource.Status.Playing)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.Stop();
        }
        // 更新
        beforeState = m_state;
    }
    void SetMotion()
    {
        StopMotion.SetActive(false);
        AttackMotion.SetActive(false);
        WalkMotion.SetActive(false);

        switch (m_state)
        {
            case SoldiorMotionState.Wait:
                StopMotion.SetActive(true);
                break;

            case SoldiorMotionState.Attack:
                AttackMotion.SetActive(true);
                break;

            case SoldiorMotionState.Walk:
                WalkMotion.SetActive(true);
                break;
        }
    }
}
