using UnityEngine;
using System.Collections;

public class ButtonLeft : MonoBehaviour {

    public void LeftMove(){
        SendMessage("MoveToLeft", SendMessageOptions.DontRequireReceiver);
    }

    public void StopMove(){
        SendMessage ("Stop", SendMessageOptions.DontRequireReceiver);
    }
}
