using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Photon.MonoBehaviour {

    [SerializeField] float bulletLength;
    public float BulletLength { get { return bulletLength; } }
    [SerializeField] float hp;
    [SerializeField] float damageBetweenPlayer;
    public float DamageBetweenPlayer { get { return damageBetweenPlayer; } }
    [SerializeField] float damageBetweenBullet;
    public float DamageBetweenBullet { get { return damageBetweenBullet; } }
    [SerializeField] float playerKnockbackPower;
    public float PlayerKnockbackPower { get { return playerKnockbackPower; } }
    [SerializeField] float bulletKnockbackPower;
    public float BulletKnockbackPower { get { return bulletKnockbackPower; } }
    [SerializeField] GameObject damageCollisionEffectPrefab;
    public GameObject DamageCollisionEffectPrefab { get { return damageCollisionEffectPrefab; } }
    [SerializeField] GameObject itemEffectPrefab;
    public GameObject ItemEffectPrefab { get { return itemEffectPrefab; } }

    public void AddBulletLength(float value)
    {
        bulletLength += value;
    }

    public void AddHp(float deltaHp) {
        hp += deltaHp;
    }
}
