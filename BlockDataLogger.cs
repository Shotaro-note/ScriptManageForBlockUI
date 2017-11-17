using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Blockの位置と、ブロックの接続、接続解除イベントのみ取得
/// すべてのアプリケーションで必要になることはなさそう
/// </summary>
public class BlockDataLogger : MonoBehaviour {
    DataLogger dataLogger;
    DataLogger.Logger blockTransform, blockEvent;
    public GameObject block;
	// Use this for initialization
	void Start () {
        dataLogger = GameObject.Find("DataLogger").GetComponent<DataLogger>();

        
            blockTransform = dataLogger.SetLogger(block.name+"transform");
            blockTransform.LogText(block.name + "'s transform log:");
            blockTransform.LogNames("Position.x", "Position.y", "Position.z", "EulerAngle");
            blockEvent = dataLogger.SetLogger(block.name+"event");
            blockEvent.LogText(block.gameObject.name + "'s event log");
            blockEvent.LogNames("GameObject1", "GameObject2", "EventTitle");
        
    }
	
	// Update is called once per frame
	void Update () {
       
            blockTransform.LogData(
               block.transform.position.x.ToString("00.0000"),
               block.transform.position.y.ToString("00.0000"),
               block.transform.position.z.ToString("00.0000"),
               block.transform.eulerAngles.ToString("00.0000")
           );
    
	}

    public void BlockEventLogger(GameObject block_a,GameObject block_b,string Event){
        
            blockEvent.LogData(
                block_a.name,
                block_b.name,
                Event
            );
 
    }
}
