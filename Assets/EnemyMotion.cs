using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField, Tooltip("アニメーター")]
    private Animator anim;

    public bool IsAttack;
    public float speed;

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
        anim.SetBool("IsAttack", IsAttack);
    }
}
