using UnityEngine;
using System.Collections;
 
//angleのスピードで、とあるオブジェクトの周りを回転するスクリプト
public class TargetRotation : MonoBehaviour
{	Rigidbody rbody;
	float speed;
	float radius;
	float yPosition;
	Vector3 TargetPos;

	//一秒当たりの回転角度
	public  float angle = 30f;
 	//回転の中心をとるために使う変数
	private Vector3 targetPos;
	//ロックオンしている敵
	GameObject Obj;
	//
	Transform targetTransform;

	//オブジェクトが生まれた瞬間に1度だけ呼ばれる
	void Start () {
		//targetを探す
		Obj = GameObject.Find("Enemy");
		//変数targetPosに位置情報を取得
		targetPos = Obj.transform.position;
		//自分の向きをターゲットの正面に向ける
		transform.LookAt(Obj.transform);
		//自分をZ軸を中心に0～360でランダムに回転させる
//		transform.Rotate(new Vector3(0, 0, Random.Range(0,360)),Space.World);

		rbody = GetComponent<Rigidbody>();

		speed = 2.0f;
		radius = 5.0f;
		yPosition = 0.0f;
	}

	//毎フレーム　60FPSなら1秒間に60回 
	void Update () {
		//	Sampleを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
//		Vector3 axis = transform.TransformDirection(Vector3.up);
//		transform.RotateAround(targetPos, axis ,angle * Time.deltaTime);

		//自分の向きをターゲットの正面に向ける
		transform.LookAt(Obj.transform);
		TargetPos = Obj.transform.position;

		//Unityのキー設定は　EDIT -> ProjectSettings -> Input　で設定されている
		//ここの"Horizontal"や"Vertical"もそこで設定されているキーを見ている
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

		rbody.MovePosition(new Vector3(
								TargetPos.x + radius * Mathf.Sin(Time.time*speed),
								TargetPos.y,
								TargetPos.z + radius * Mathf.Cos(Time.time*speed)
								));
	}
}
