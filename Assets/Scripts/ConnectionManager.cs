using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour, IPunCallbacks {
    [SerializeField] Button joinRoomButton = null;

    public static ConnectionManager instance;

    public void OnConnectedToMaster() {
    }

    public void OnConnectedToPhoton() {
        Debug.Log("OnConnectedToPhoton");
    }

    public void OnConnectionFail(DisconnectCause cause) {
        Debug.LogFormat("OnConnectionFail: {0}", cause);
    }

    public void OnCreatedRoom() {
        Debug.Log("OnCreatedRoom");
    }

    public void OnCustomAuthenticationFailed(string debugMessage) {
    }

    public void OnCustomAuthenticationResponse(Dictionary<string, object> data) {
    }

    public void OnDisconnectedFromPhoton() {
    }

    public void OnFailedToConnectToPhoton(DisconnectCause cause) {
    }

    public void OnJoinedLobby() {
        Debug.Log("OnJoinedLobby");
        joinRoomButton.gameObject.SetActive(true);
        joinRoomButton.interactable = true;
    }

    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        SpawnPlayer();
        joinRoomButton.gameObject.SetActive(false);

    }

    public static void SpawnPlayer()
    {
        var x = Random.Range(-6.0f, 6.0f);
        var y = Random.Range(-4.0f, 4.0f);
        PhotonNetwork.Instantiate("Player", new Vector3(x, y, 0), Quaternion.identity, 0);
    }

    public void OnLeftLobby() {
    }

    public void OnLeftRoom() {
    }

    public void OnLobbyStatisticsUpdate() {
    }

    public void OnMasterClientSwitched(PhotonPlayer newMasterClient) {
    }

    public void OnOwnershipRequest(object[] viewAndPlayer) {
    }

    public void OnOwnershipTransfered(object[] viewAndPlayers) {
    }

    public void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
    }

    public void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable propertiesThatChanged) {
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info) {
    }

    public void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
    }

    public void OnPhotonMaxCccuReached() {
    }

    public void OnPhotonPlayerActivityChanged(PhotonPlayer otherPlayer) {
    }

    public void OnPhotonPlayerConnected(PhotonPlayer newPlayer) {
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
    }

    public void OnPhotonPlayerPropertiesChanged(object[] playerAndUpdatedProps) {
    }

    public void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
    }

    public void OnReceivedRoomListUpdate() {
    }

    public void OnUpdatedFriendList() {
    }

    public void OnWebRpcResponse(OperationResponse response) {
    }

    void Awake() {
        joinRoomButton.interactable = false;

        if (instance == null)
        {
            instance = this;
        }

        if (PhotonNetwork.connected == false) {
            if (PhotonNetwork.ConnectUsingSettings("1.0")) {
                Debug.Log("PhotonNetwork Connected.");
            } else {
                Debug.LogError("PhotonNetwork connection failed.");
            }
		}
	}

    public void JoinRoom() {
        PhotonNetwork.JoinOrCreateRoom("defaultRoomName", new RoomOptions { }, TypedLobby.Default);
    }

    public void StartRespawnCoroutine()
    {
        StartCoroutine(WaitForRespawn());
    }

    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(3f);
        SpawnPlayer();
    }

}
