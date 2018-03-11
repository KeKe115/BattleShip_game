using UnityEngine;
using System.Collections;

public class Enemy1Script : MonoBehaviour {

	public AudioClip Hit0, Hit1, Hit2;           //被弾音用変数
    AudioSource audioSource;                     //サウンド用変数
    int num;                                     //どのサウンドを使うかを決めるのに使う変数

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();    //AudioSourceの取得
    }

    void OnTriggerEnter2D(Collider2D other)      //当たり判定処理(?)
    {
        if (other.gameObject.tag == "Shell")     //我が当たり判定に触れたオブジェクトのタグが「Shell」だったら、
        {
            Destroy(other.gameObject);           //Shellを消す
            num = Random.Range(0, 3);            //乱数発生。被弾音を選ぶ
			// Debug.Log (num);   /* デバック用 */
			switch (num) {
			case 0:
				audioSource.clip = Hit0;
				break;
			case 1:
				audioSource.clip = Hit1;
				break;
			case 2:
				audioSource.clip = Hit2;
				break;
			}
			audioSource.Play ();                  //音を再生
        }
    }
}
/*
public class Enemy1Script : MonoBehaviour {

	public AudioClip Hit1, Hit2, Hit3, Hit4;
	AudioSource audioSource;
	int num;

	void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Shell")
		{
			Destroy(other.gameObject);
			num = Random.Range(0, 4);
			Debug.Log(num);
			switch (num)
			{
			case 0: audioSource.clip = Hit1; audioSource.Play(); break;
			case 1: audioSource.clip = Hit2; audioSource.Play(); break;
			case 2: audioSource.clip = Hit3; audioSource.Play(); break;
			case 3: audioSource.clip = Hit4; audioSource.Play(); break;
			default: break;
			}
			//audioSource.Play();
		}
	}
}
*/
