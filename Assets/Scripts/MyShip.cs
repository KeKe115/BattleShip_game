using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MyShip : MonoBehaviour {

    public float speed;
    Rigidbody2D rb2d;
    static int whichDirection = 0;              //-1:左方向 0:停止 1:右方向

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    public void Right()
    {
        whichDirection = 1;
    }

    public void Left ()
    {
        whichDirection = -1;
    }

    public void stopShip()
    {
        whichDirection = 0;
    }

	// Update is called once per frame
	void Update () {
		/*-------キーボードデバック用--------*/
		/*
			if (Input.GetKey ("right"))
				MoveToRight ();
			else if (Input.GetKey ("left"))
				MoveToLeft ();
			else
				Stop ();
		*/
		
        /*----ソフトウェアボタン用----*/
        
        if (whichDirection == 1)
            MoveToRight ();
        else if (whichDirection == -1)
            MoveToLeft ();
        else
            Stop ();
        

	}
	/*----「public」を書くことによって外部から自作の関数を参照できるようになる。*/	
    public void MoveToRight()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
        Vector2 pos = transform.position;
        if (pos.x <= max.x) {
            rb2d.velocity = new Vector2 (1 * speed, rb2d.velocity.y);   //右へ進んでよい。
            Debug.Log (pos);
        } else {
            Stop ();
        }
    }

    public void MoveToLeft()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
        Vector2 pos = transform.position;

        if (pos.x >= min.x) {
            rb2d.velocity = new Vector2 (-1 * speed, rb2d.velocity.y);   //左へ進むでござる
            Debug.Log(pos);
        } else {
            Debug.Log ("STOP!");
            Stop ();
        }
    }

    public void Stop()
    {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }
}
	