using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    [SerializeField] float bulletLength;
    public float BulletLength { get { return bulletLength; } }
    [SerializeField] float hp;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBulletLength(float value)
    {
        bulletLength += value;
    }
}
