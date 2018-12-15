using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : Photon.MonoBehaviour {
    PlayerStat playerStat;

    void Start() {
        playerStat = GetComponent<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerStat.AddHp(-playerStat.DamageBetweenPlayer);
            Instantiate(playerStat.DamageCollisionEffectPrefab, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Bullet")
        {
            playerStat.AddHp(-playerStat.DamageBetweenBullet);
            Instantiate(playerStat.DamageCollisionEffectPrefab, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Item")
        {
            //파워 업
            Instantiate(playerStat.ItemEffectPrefab, transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //체력 감소 후 살짝 튕겨나감
            Vector3 diff = (transform.position - collision.transform.position).normalized;

            transform.position += diff * playerStat.PlayerKnockbackPower * Time.deltaTime;
            collision.transform.position -= diff * playerStat.PlayerKnockbackPower * Time.deltaTime;
        }

        if (collision.tag == "Bullet")
        {
            //체력 감소 후 많이 튕겨나감
            Vector3 diff = (transform.position - collision.transform.position).normalized;

            transform.position += diff * playerStat.BulletKnockbackPower * Time.deltaTime;
            collision.transform.position -= diff * playerStat.BulletKnockbackPower * Time.deltaTime;

        }



    }

}
