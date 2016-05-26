using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    public TestJson player;
    public User user;

    public Transform pos1;
    public Transform pos2;

    

    int count = 0;

	// Use this for initialization
	void Start () {
        MoveSocketManager.MoveSocket.On("move",
            (GetData) => {
                Debug.Log(GetData.Json.args[0].ToString());
                 Data getData = JsonUtility.FromJson<Data>(GetData.Json.args[0].ToString());
                if (getData.id != player.myData.id) {
                    user.myData = getData;
                }
            });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
