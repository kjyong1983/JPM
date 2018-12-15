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
            photonView.RPC("HitPlayer", PhotonTargets.AllViaServer);
            //playerStat.AddHp(-playerStat.DamageBetweenPlayer);
            Instantiate(playerStat.PlayerHitEffectPrefab, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Bullet")
        {
            if (collision.GetComponentInParent<Bullet>().AttackerPId == photonView.viewID)
                return;

            photonView.RPC("HitBullet", PhotonTargets.AllViaServer);
            //playerStat.AddHp(-playerStat.DamageBetweenBullet);
            Instantiate(playerStat.BulletHitEffectPrefab, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Item")
        {
            //파워 업
            var item = collision.GetComponent<IItem>();

            item.Apply(playerStat);

            //playerStat.AddBulletLength(item);
            Destroy(collision.gameObject);
            if (item.IsAddHpItem())
                Instantiate(playerStat.HpItemEffectPrefab, transform.position, Quaternion.identity);
            else
                Instantiate(playerStat.ItemEffectPrefab, transform.position, Quaternion.identity);
        }

    }

    [PunRPC]
    public void HitPlayer()
    {
        playerStat.AddHp(-playerStat.DamageBetweenPlayer);
    }

    [PunRPC]
    public void HitBullet()
    {
        playerStat.AddHp(-playerStat.DamageBetweenBullet);

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
            if (collision.GetComponentInParent<Bullet>().AttackerPId == photonView.viewID)
                return;

            //체력 감소 후 많이 튕겨나감
            Vector3 diff = (transform.position - collision.transform.position).normalized;

            transform.position += diff * playerStat.BulletKnockbackPower * Time.deltaTime;
            collision.transform.position -= diff * playerStat.BulletKnockbackPower * Time.deltaTime;

        }



    }

}
