using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField, Tooltip("アニメーター")]
    private Animator anim;

    public bool IsAttack;
    public float speed;

    private float moveAudioTimer = 1f;

    [SerializeField, Tooltip("移動音")]
    private CriAtomSource moveAudio;
    [SerializeField, Tooltip("攻撃音")]
    private CriAtomSource attackSource;

    private Vector3 latestPos;

    // Start is called before the first frame update
    void Start()
    {
        SetMotion();
    }
    // Update is called once per frame
    void Update()
    {
        speed = ((transform.position - latestPos) / Time.deltaTime).magnitude;
        latestPos = transform.position;
        SetMotion();
    }
    void SetMotion()
    {
        anim.SetFloat("MoveSpeed", speed);
        if (speed > 0.5f)
        {
            moveAudioTimer -= Time.deltaTime;
            if (moveAudio.status != CriAtomSource.Status.Playing)
            {
                if (moveAudioTimer < 0)
                {
                    moveAudio.Play();
                    moveAudioTimer = 1.208f;
                }
            }
        }
    }
    public void Attack()
    {
        anim.SetTrigger("AttackTrigger");
        if (attackSource != null)
        {
            attackSource.Play();
        }
    }
}
