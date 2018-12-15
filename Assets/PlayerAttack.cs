using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
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

        attackX = Input.GetAxis("AttackX");
        attackY = Input.GetAxis("AttackY");

        direction = new Vector2(attackX, attackY).normalized;

        if (direction != Vector2.zero)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();

            bullet.direction = direction;
            bullet.length = stat.BulletLength;
        }
	}
}
