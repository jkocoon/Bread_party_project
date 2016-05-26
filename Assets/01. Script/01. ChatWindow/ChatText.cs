using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatText : MonoBehaviour {

    public UITextList textList;
    public bool fillWithDummyData = false;

    public UIInput mInput;

    public Queue<string> qMsg = new Queue<string>();

    // Use this for initialization
    void Awake() {
        mInput.label.maxLineCount = 1;
    }

	void Start () {

        SocketManager.Socket.On("chat message",
            (data) => {
                //Debug.Log(data.Json.args[0]);
                qMsg.Enqueue(data.Json.args[0].ToString());
                //textList.Add(data.Json.args[0].ToString());
            });
        mInput.value = "";
        mInput.isSelected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(qMsg.Count > 0)
        {
            textList.Add(qMsg.Dequeue());
        }
	}

    public void OnSubmit() {
        if (textList != null)
        {
            string text = NGUIText.StripSymbols(mInput.value);

            if (!string.IsNullOrEmpty(text))
            {
                SocketManager.Socket.Emit("chat message", text);
                //textList.Add(text); // 이거 떔에 그래 서버에 보내면 알아서 받아서 뿌리는데 또찍으니까 2번임.
                mInput.value = "";
                mInput.isSelected = false;
                text = null;
            }
        }
    }
}
