using UnityEngine;
using System.Collections;

public class ShellMove : MonoBehaviour {

    public float speed;                             //砲弾の発射速度
    public float max, min;
    public GameObject Shell;                        //ゲームオブジェクト型Shellの割当
    float angle;                                    //発射角度変数 float型
    float rad;
    float nowAngle;


	// Use this for initialization
	void Start () {

        angle = ShellMaker.Ang;                     //発射角度を「ShellMaker」スクリプトから参照する
        angle += Random.Range (-3.0f, 3.0f); //角度をずらしてあえて発射精度を悪くする(現在角+(-3.0~+3.0))

        transform.Rotate(0, 0, angle);              //砲弾の発射角度を決める
        
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;    //砲弾発射！！！

        // Debug.Log (angle);
	
	}
	
	// Update is called once per frame
    void Update () {
        /*
        Debug.Log (GetComponent<Rigidbody2D>().velocity.y + "y");
        Debug.Log (GetComponent<Rigidbody2D>().velocity.x + "x");
        */

        rad = Mathf.Atan2(GetComponent<Rigidbody2D> ().velocity.y, GetComponent<Rigidbody2D> ().velocity.x);    //砲弾の角度
        nowAngle = rad * Mathf.Rad2Deg + 270;                                                                   //ラジアン→度数法へ変換
        transform.rotation = Quaternion.Euler(0, 0, nowAngle);                                                  //砲弾の角度を変更
        //Debug.Log (transform.localEulerAngles.z);                                                               //砲弾の角度のデバックログ
        }
	
}
