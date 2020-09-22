using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntaractiveMusic : MonoBehaviour
{
    private CriAtomSource source;
    [SerializeField]
    private float AisacValue;
    [SerializeField, Tooltip("AisacName")]
    private string aisacName;

    [SerializeField, Tooltip("城")]
    private Transform Catsle;
    private Transform Player;
    private Vector3 startPos;

    private float StageDistance;
    private float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<CriAtomSource>();
        source.SetAisacControl(aisacName, AisacValue);
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = Player.position;
        StageDistance = Vector3.Distance(startPos, Catsle.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null && Catsle != null)
        {
            radius = Vector3.Distance(Player.position, Catsle.position) / StageDistance;
            AisacValue = 1 - radius;
            source.SetAisacControl(aisacName, AisacValue);
        }
    }
}
