using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    PlayerStat stat;

	void Start () {
        stat = GetComponent<PlayerStat>();
        Instantiate(stat.SpawnParticlePrefab, transform.position, Quaternion.identity);
	}
	
}
