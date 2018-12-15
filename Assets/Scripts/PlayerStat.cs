using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Photon.MonoBehaviour {

    [SerializeField] float bulletLength;
    public float BulletLength { get { return bulletLength; } }
    [SerializeField] float hp;
    public float Hp { get { return hp; } }
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField] float damageBetweenPlayer;
    public float DamageBetweenPlayer { get { return damageBetweenPlayer; } }
    [SerializeField] float damageBetweenBullet;
    public float DamageBetweenBullet { get { return damageBetweenBullet; } }
    [SerializeField] float playerKnockbackPower;
    public float PlayerKnockbackPower { get { return playerKnockbackPower; } }
    [SerializeField] float bulletKnockbackPower;
    public float BulletKnockbackPower { get { return bulletKnockbackPower; } }

    [SerializeField] GameObject bulletHitEffectPrefab;
    public GameObject BulletHitEffectPrefab { get { return bulletHitEffectPrefab; } }
    [SerializeField] GameObject playerHitEffectPrefab;
    public GameObject PlayerHitEffectPrefab { get { return playerHitEffectPrefab; } }


    [SerializeField] GameObject itemEffectPrefab;
    public GameObject ItemEffectPrefab { get { return itemEffectPrefab; } }
    [SerializeField] GameObject hpItemEffectPrefab;
    public GameObject HpItemEffectPrefab { get { return hpItemEffectPrefab; } }
    [SerializeField] GameObject deathEffectPrefab;
    public GameObject DeathEffectPrefab { get { return deathEffectPrefab; } }
    [SerializeField] GameObject spawnParticlePrefab;
    public GameObject SpawnParticlePrefab { get { return spawnParticlePrefab; } }

    [SerializeField] float attackSpeedLevel;
    public float AttackSpeedLevel { get { return attackSpeedLevel; } }
    public float AttackDelay { get { return 0.25f / (0.075f* AttackSpeedLevel + 0.25f); } }

    private void Start()
    {
        moveSpeed = 3f;
    }

    public void AddBulletLength(float value)
    {
        bulletLength += value;
    }

    [PunRPC]
    public void AddHp(float deltaHp) {

        hp += deltaHp;
        if (hp <= 0)
        {
            //if (PhotonNetwork.isMasterClient)
            if (photonView.isMine)
            {
                Instantiate(DeathEffectPrefab, transform.position, Quaternion.identity);
                ConnectionManager.instance.StartRespawnCoroutine();
                PhotonNetwork.Destroy(gameObject);
            }

        }

    }

    private void Respawn()
    {
        ConnectionManager.SpawnPlayer();
    }

    public void AddAttackSpeedLevel(float value)
    {
        attackSpeedLevel += value;
    }

    public void AddSpeed(float value)
    {
        moveSpeed += value;
    }

}
