using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitPoint))]
public class PlayerStatas : MonoBehaviour
{
    public float Speed = 10;
    public int MaxHitPoint = 50; 
    public int CurrentHitPoint = 50;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HitPoint>().maxHitPoint = MaxHitPoint;
        GetComponent<HitPoint>().currentHitPoint = CurrentHitPoint;
    }
    void Update()
    {
        MaxHitPoint = GetComponent<HitPoint>().maxHitPoint;
        CurrentHitPoint = GetComponent<HitPoint>().currentHitPoint;
    }
}
