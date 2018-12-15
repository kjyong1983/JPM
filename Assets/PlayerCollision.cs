using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] float playerKnockbackPower;
    [SerializeField] float bulletKnockbackPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            //파워 업
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //체력 감소 후 살짝 튕겨나감
            Vector3 diff = (transform.position - collision.transform.position).normalized;

            transform.position += diff * playerKnockbackPower * Time.deltaTime;
            collision.transform.position -= diff * playerKnockbackPower * Time.deltaTime;
        }

        if (collision.tag == "Bullet")
        {
            //체력 감소 후 많이 튕겨나감
            Vector3 diff = (transform.position - collision.transform.position).normalized;

            transform.position += diff * bulletKnockbackPower * Time.deltaTime;
            collision.transform.position -= diff * bulletKnockbackPower * Time.deltaTime;

        }



    }

}
