using UnityEngine;
using System.Collections;

[System.Serializable]
public class Data
{
    public string name = null;
    public string id = null;
    public int value  = 0;
    public float x = 0;
    public float y = 0;
}

public class TestJson : MonoBehaviour {

    public EnemyManager enemyManager;
    public Data myData = new Data();
    Vector3 offset;
    Vector3 scrSpace;
    Vector3 beforePos;
    private float yVelocity = 0;

    Vector2 center = Vector3.zero;
    Vector2 dis = Vector3.zero;

    public GameObject shot;

    // Use this for initialization

    void Start () {
        myData.id = null;
        MoveSocketManager.MoveSocket.On("id",
            (GetData) => {
                if (myData.id == null)
                {
                    myData.id = GetData.Json.args[0].ToString();
                    Debug.Log("ID : " + myData.id);
                }
            });

        transform.position = enemyManager.pos1.position;           
       
        scrSpace = transform.position;
        offset = transform.position;
        beforePos = transform.position;

        myData.name = "Joohee";
        myData.value = 1;
        myData.x = transform.position.x;
        myData.y = transform.position.z;
        MoveSocketManager.MoveSocket.Emit("move", myData);
	}
	
	// Update is called once per frame
	void Update () {

        //핸드폰 조작 시 2
        //if (Input.touchCount > 0)
        //{
        //    scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        //    offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, scrSpace.y, scrSpace.z));

        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        //        offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, scrSpace.y, scrSpace.z));
        //    }
        //    else if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        transform.position += (new Vector3(offset.x, transform.position.y, transform.position.z) - transform.position) * 0.1f;
        //    }
        //    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //    {
        //        scrSpace = Vector3.zero;
        //        offset = Vector3.zero;
        //    }
        //    transform.position += (new Vector3(offset.x, transform.position.y, transform.position.z) - transform.position) * 0.1f;
        //    RenewalPosition();
        //}



        ////핸드폰 조작 시 1  ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //if (Input.touchCount > 0) {

        //    if (Input.GetTouch(0).phase == TouchPhase.Began) {
        //        center = Input.GetTouch(0).position;
        //    }
        //    else if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        dis = Input.GetTouch(0).position - center;
        //        dis = dis.normalized;
        //        RenewalPosition();
        //    }
        //    else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //    {
        //        dis = Vector3.zero;
        //    }
        //    transform.position += new Vector3(dis.x, 0, 0) * Time.deltaTime * 15f;
        //    RenewalPosition();
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //마우스로 조작 할 때////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            scrSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, scrSpace.y, scrSpace.z));
        }

        beforePos = transform.position;
        transform.position += (new Vector3(offset.x, transform.position.y, transform.position.z) - transform.position) * 0.1f;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (beforePos != transform.position)
        {
            RenewalPosition();
        }
    }

    void RenewalPosition() {
        myData.x = transform.position.x;
        myData.y = transform.position.z;
        MoveSocketManager.MoveSocket.Emit("move", myData);
    }
}
