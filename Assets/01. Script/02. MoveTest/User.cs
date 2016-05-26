using UnityEngine;
using System.Collections;

public class User : MonoBehaviour {

    public EnemyManager enemyManager;
    public Data myData;

    // Use this for initialization

	void Start () {
        transform.position = enemyManager.pos2.transform.position;
        myData.x = transform.position.x;
        myData.y = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if(myData.id != null) {
            transform.position += (new Vector3(myData.x, transform.position.y, transform.position.z) - transform.position) * 0.1f;
        }
    }

    public void DataSet(Data _data)
    {
        myData = _data;
    }
}
