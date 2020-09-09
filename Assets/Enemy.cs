using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;
    private bool IsDead { get { return GetComponent<HitPoint>().is_Dead; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead == true)
        {
            var explo = Instantiate(explosion, transform.position, Quaternion.identity);
            explo.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Instantiate(GetComponent<EnemyStatas>().DropItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
