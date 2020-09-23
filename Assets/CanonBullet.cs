using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour
{
    private Transform targetTrans;
    private float speed;
    public delegate void CallBack();
    private CallBack hitmethod;


    public void CanonBulletConstract(float speed, Transform TargetTrans, CallBack hitmethod)
    {
        this.speed = speed;
        this.targetTrans = TargetTrans;
        this.hitmethod = hitmethod;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ターゲットが存在したら
        if (targetTrans != null)
        {
            Vector3 dir = Vector3.Normalize(targetTrans.position - transform.position);
            transform.position = transform.position + (dir * speed * Time.deltaTime);
            // 十分近づいたら
            if (Vector3.Distance(transform.position, targetTrans.position) < 0.1f)
            {
                DestroyBullet();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void DestroyBullet()
    {
        hitmethod.Invoke();
        Destroy(gameObject);
    }
}
