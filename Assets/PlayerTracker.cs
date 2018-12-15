using UnityEngine;

public class PlayerTracker : MonoBehaviour {
    private Transform playerTransform;

    // Use this for initialization
    public void Initialize(Transform playerTransform) {
        this.playerTransform = playerTransform;
    }

    private void LateUpdate() {
        if (playerTransform != null) {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
