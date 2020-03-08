using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGizmos : MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x / 2);
    }
}
