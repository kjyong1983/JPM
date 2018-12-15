using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float length;
    public Vector2 direction;
    [SerializeField] float moveSpeed;

    void Start () {
        Vector3 locScale = transform.localScale;
        transform.localScale = new Vector3(locScale.x, length, locScale.z);
        transform.Rotate(Vector3.back, -Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
        Destroy(gameObject, 5f);
	}
	
	void Update () {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
	}
}
