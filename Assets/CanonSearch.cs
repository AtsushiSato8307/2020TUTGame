using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonSearch : MonoBehaviour
{
    [SerializeField,Tooltip("検出するレイヤー")]
    private LayerMask hitLayer = 0;
    private CanonStatas statas;
    public bool Is_Hit { private set; get; }

    public GameObject Target { private set; get; } = null;

    // Start is called before the first frame update
    void Start()
    {
        statas = GetComponent<CanonStatas>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Is_Hit = false;
        Collider[] col = Physics.OverlapSphere(transform.position, statas.Range, hitLayer);
        foreach (var i in col)
        {
            if (i.gameObject.CompareTag("Enemy"))
            {
                Debug.DrawRay(transform.position, i.gameObject.transform.position - transform.position, Color.red);
                if (Physics.Raycast(transform.position, i.gameObject.transform.position - transform.position))
                {
                    Is_Hit = true;
                    if (Target == null)
                    {
                        Target = i.gameObject;
                    }
                }
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GetComponent<CanonStatas>().Range);
    }
}
