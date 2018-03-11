using UnityEngine;
using System.Collections;

public class ShellDestroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shell")
        {
            //オブジェクト削除
            Destroy(other.gameObject);
        }
    }
}
