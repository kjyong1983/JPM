using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Photon.MonoBehaviour {
    private Vector2 direction;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float attackX;
    [SerializeField] float attackY;

    PlayerStat stat;

    // Use this for initialization
    void Start () {
        stat = GetComponent<PlayerStat>();
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine == false) {
            return;
        }

        attackX = Input.GetAxis("AttackX");
        attackY = Input.GetAxis("AttackY");

        direction = new Vector2(attackX, attackY).normalized;

        if (direction != Vector2.zero) {
            photonView.RPC("InstantiateBullet", PhotonTargets.AllViaServer, transform.position, direction, stat.BulletLength);
        }
    }

    [PunRPC]
    private void InstantiateBullet(Vector3 remotePosition, Vector2 remoteDirection, float remoteBulletLength) {
        var bullet = Instantiate(bulletPrefab, remotePosition, Quaternion.identity).GetComponent<Bullet>();

        bullet.direction = remoteDirection;
        bullet.length = remoteBulletLength;
    }
}
