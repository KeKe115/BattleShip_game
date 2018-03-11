using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShellMaker : MonoBehaviour {

	//　砲弾取込用GameObject型変数
    public GameObject Shell;

	// ラジアン角
    float rad;

	// 角度(弧度法)
	float angle;

	// ShellMoveスクリプトに渡す値。(static型かつpublic)
    public static float Ang;

	//反復変数
    int k;

	// 砲弾の発射数
    public int BULLETS = 100;

	// Use this for initialization
	void Start () {
        // 起動時に1度だけ実行される
	}
	
	// Update is called once per frame
	void Update () {
		// タッチを検知したら
		if (Input.GetButtonDown ("Fire1"))
        {
			// 現在の位置を保存
			Vector3 myShip = transform.position;

			// タッチ位置を代入
			Vector3 screenPos = Input.mousePosition;

			// タッチ位置をワールド座標に変換
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);
			worldPos.z = 0;

			// y座標が-2.66より下だったら処理をしない
			if (worldPos.y < -2.66) {
				// 何もしない
				return;
			}

			// 逆三角関数で二点間の角度を求める(ラジアン)
            rad = Mathf.Atan2 (worldPos.y - myShip.y, worldPos.x - myShip.x);

			// ラジアン角を弧度法に変換
            Ang = rad * Mathf.Rad2Deg - 90;       

			// 砲台の位置にずらす。
            myShip.x += 0.3f;                                                   

			//Instantiate (Shell, transform.position, Quaternion.identity);

			// for文で砲弾の発射数分の処理をする
            for(k = 0; k < BULLETS; k++) {
				// 現在の位置に砲弾の生成
                Instantiate (Shell, myShip, Quaternion.identity);
            }
		}
    }
}
