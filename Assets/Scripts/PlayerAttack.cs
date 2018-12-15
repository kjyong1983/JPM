using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Photon.MonoBehaviour {
    private Vector2 direction;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float attackX;
    [SerializeField] float attackY;

    float attackTimer = 0;

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

        attackTimer += Time.deltaTime;

        if (direction != Vector2.zero && attackTimer > stat.AttackDelay) {
            attackTimer = 0;
            photonView.RPC("InstantiateBullet", PhotonTargets.AllViaServer, transform.position, direction, stat.BulletLength, photonView.viewID);
        }
    }

    [PunRPC]
    private void InstantiateBullet(Vector3 remotePosition, Vector2 remoteDirection, float remoteBulletLength, int pId) {
        var bullet = Instantiate(bulletPrefab, remotePosition, Quaternion.identity).GetComponent<Bullet>();

        bullet.direction = remoteDirection;
        bullet.length = remoteBulletLength;
        bullet.AttackerPId = pId;
    }
}
