using UnityEngine;
using System.Collections;
using SocketIOClient;

public class MoveSocketManager : MonoBehaviour {

    public string url = "http://52.79.122.145:8888/";
    public static Client MoveSocket { get; private set; }

    void Awake() {
        MoveSocket = new Client(url);
        MoveSocket.Opened += SocketOpened;
        MoveSocket.Message += SocketMessage;
        MoveSocket.SocketConnectionClosed += SocketConnectionClosed;
        MoveSocket.Connect();
    }

    public void SocketOpened(object sender, System.EventArgs e)
    {
        Debug.Log("Socket Opened");
    }

    private void SocketMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("Socket Message!");
    }

    private void SocketConnectionClosed(object sender, System.EventArgs e)
    {
        Debug.Log("Socket Connection Closed!");
    }

    private void SocketError(object sender, ErrorEventArgs e)
    {
        Debug.Log(e.Message);
    }

    void OnDisable()
    {
        MoveSocket.Close();
    }

}
