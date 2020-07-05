using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Canon : MonoBehaviour
{
    private CanonSearch search = null;
    private CanonStatas statas;
    private float timer;

    [SerializeField, Tooltip("弾のプレファブ")]
    private GameObject bulletPrefab = null;

    [SerializeField, Tooltip("大砲のモデル")]
    private GameObject CanonModel;

    [SerializeField, Tooltip("マスクのフィールド")]
    private GameObject MaskField;

    private GameObject bullet;

    private delegate void DeadBullet();

    private bool IsDead { get { return GetComponent<HitPoint>().is_Dead; } }

    // Start is called before the first frame update
    void Start()
    {
        search = GetComponent<CanonSearch>();
        statas = GetComponent<CanonStatas>();
        Instantiate(MaskField, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (search.Is_Hit && search.Target != null)
        {
            // モデル回転
            CanonModel.transform.forward = search.Target.transform.position - transform.position;
            timer += Time.deltaTime;
            if (timer > statas.IntervalTime)
            {
                FireBullet();
                timer = 0;
            }
        }
        // 死亡処理
        if (IsDead == true)
        {
            Destroy(gameObject);
        }
    }

    private void FireBullet()
    {
        // 弾の処理
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // モデルの処理
        CanonModel.GetComponent<Animator>().SetTrigger("Fire");
        bullet.GetComponent<CanonBullet>().CanonBulletConstract(statas.BulletSpead, search.Target.transform, () =>
        { search.Target.GetComponent<HitPoint>().currentHitPoint -= statas.Damage; });

    }
}
