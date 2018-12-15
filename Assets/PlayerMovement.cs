using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour {

    Vector2 direction;
    [SerializeField] float moveSpeed;
    Vector3 backgroundSize;
	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<PlayerTracker>().Initialize(transform);
        backgroundSize = GameObject.Find("Background").GetComponent<BoxCollider>().size;
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine == false) {
            return;
        }

        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        direction = new Vector2(h, v).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        var x = Mathf.Clamp(transform.position.x, -backgroundSize.x / 2, backgroundSize.x / 2);
        var y = Mathf.Clamp(transform.position.y, -backgroundSize.y / 2, backgroundSize.y / 2);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
