using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private CanonSearch search = null;
    private CanonStatas statas;
    private float timer;

    [SerializeField, Tooltip("弾のプレファブ")]
    private GameObject bulletPrefab = null;

    private GameObject bullet;

    private delegate void DeadBullet();

    // Start is called before the first frame update
    void Start()
    {
        search = GetComponent<CanonSearch>();
        statas = GetComponent<CanonStatas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (search.Is_Hit && search.Target != null)
        {
            timer += Time.deltaTime;
            if (timer > statas.IntervalTime)
            {
                FireBullet();
                timer = 0;
            }
        }
    }

    private void FireBullet()
    {
        bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<CanonBullet>().CanonBulletConstract(statas.BulletSpead, search.Target.transform, () =>
        { search.Target.GetComponent<HitPoint>().currentHitPoint -= statas.Damage; });
    }
}
