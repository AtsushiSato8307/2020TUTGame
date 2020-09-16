using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutal : MonoBehaviour
{
    [SerializeField, Tooltip("敵用施設")]
    private GameObject enemy_building;
    [SerializeField, Tooltip("味方用施設")]
    private GameObject player_building;

    [SerializeField, Tooltip("見た目")]
    private GameObject[] visuals;

    // HP
    private HitPoint playerBuildingHp;
    private HitPoint EnemyBuildingHp;
    
    // CurrentHP
    private int enemyBuild_currentHp { set { EnemyBuildingHp.currentHitPoint = value; } get { return EnemyBuildingHp.currentHitPoint; } }
    private int playerBuild_currentHp { set { playerBuildingHp.currentHitPoint = value; } get { return playerBuildingHp.currentHitPoint; } }

    // Start is called before the first frame update
    void Start()
    {
        playerBuildingHp = player_building.GetComponent<HitPoint>();
        EnemyBuildingHp = enemy_building.GetComponent<HitPoint>();
        ChangeVisual(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBuild_currentHp <= 0)
        {
            Fall();
            var enemySide = enemy_building.GetComponent<NeutralOneSide>();
            enemySide.buildingIntaractive = false;
            enemySide.tag = "Untagged";
            var playerSide = player_building.GetComponent<NeutralOneSide>();
            playerSide.buildingIntaractive = true;
            playerSide.tag = "Building";
            ChangeVisual(1);
        }
        else if (playerBuild_currentHp <= 0)
        {
            Fall();
            var enemySide = enemy_building.GetComponent<NeutralOneSide>();
            enemySide.buildingIntaractive = true;
            enemySide.tag = "Enemy";
            var playerSide = player_building.GetComponent<NeutralOneSide>();
            playerSide.buildingIntaractive = false;
            playerSide.tag = "Untagged";
            ChangeVisual(2);
        }
    }
    // どちらか陥落時処理
    private void Fall()
    {
        enemyBuild_currentHp = EnemyBuildingHp.maxHitPoint;
        playerBuild_currentHp = playerBuildingHp.maxHitPoint;
    }
    private void ChangeVisual(int num)
    {
        for (int i = 0; i < visuals.Length; i++)
        {
            visuals[i].SetActive(false);
        }
        visuals[num].SetActive(true);
    }
}
