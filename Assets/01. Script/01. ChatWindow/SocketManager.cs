using UnityEngine;
using System.Collections;
using SocketIOClient;

public class SocketManager : MonoBehaviour {

    public string url = "http://52.79.122.145:8888/";
    public static Client Socket { get; private set; }
    public ChatText chatText;

    void Awake() {
        Socket = new Client(url);
        Socket.Opened += SocketOpened;
        Socket.Error += SocketError;
        Socket.Connect();
    }

    public void SocketOpened(object sender, System.EventArgs e) {
        //chatText.textList.Add("Socket Opened");
        chatText.qMsg.Enqueue("Socket Opend");
        Debug.Log("Socket Opened");

    }

    public void SocketError(object sender, System.EventArgs e)
    {
        Debug.Log(e);

    }

    void OnDisable() {
        Socket.Close();
    }
}
