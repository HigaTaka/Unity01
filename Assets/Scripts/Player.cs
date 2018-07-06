using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	GameObject Bullet;
	GameObject Target;
	// 弾丸の速度
	public float speed = 1000;

	// Use this for initialization
	void Start () {
		//Resourcesフォルダーから読み込みをする
		Bullet = Resources.Load("Prefub/P_BulletBIG") as GameObject;
		//targetを探す
		Target = GameObject.Find("Enemy");

	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown("Fire1") )
		{
			BulletSet();
		}
	}

	void BulletSet()
	{
		GameObject Obj = Instantiate(Bullet);
		Obj.transform.position = transform.position;
		//自分の向きをターゲットの正面に向ける
		transform.LookAt(Target.transform);

		Vector3 force;
		force = this.gameObject.transform.forward * speed;
		// Rigidbodyに力を加えて発射
		Obj.GetComponent<Rigidbody>().AddForce(force);
		//
		Destroy( Obj, 3.0f);
	}
}
