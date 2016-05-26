using UnityEngine;
using System.Collections;
using SocketIOClient;

public class MoveSocketManager : MonoBehaviour {

    public string url = "http://52.79.122.145:8888/";
    public static Client MoveSocket { get; private set; }

    void Awake() {
        MoveSocket = new Client(url);
        MoveSocket.Opened += SocketOpened;
        MoveSocket.Connect();
    }

    public void SocketOpened(object sender, System.EventArgs e)
    {
        Debug.Log("Socket Opened");
    }

    public void SocketError(object sender, System.EventArgs e)
    {
        Debug.Log(e);

    }

    void OnDisable()
    {
        MoveSocket.Close();
    }

}
