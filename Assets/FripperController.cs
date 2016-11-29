using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

    // HingiJointコンポーネントを入れる
    private HingeJoint myHingJoynt;

    // 初期の傾き
    private float defaultAngle = 20;

    // 弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        // HinjiJointコンポーネント取得
        this.myHingJoynt = GetComponent<HingeJoint>();

        // フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

	}

    // Update is called once per frame
    void Update(){

        // 左矢印キーを押した時、左フリッパーを動かす
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
            SetAngle(this.flickAngle);
        }

        // 右矢印キーを押した時、右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }

        // 矢印キーを離した時、フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ) {
            SetAngle(this.defaultAngle);
        }

        //スマートフォンでタップした時にフリッパーを動かす為の命令文
        foreach (Touch t in Input.touches) {
            var id = t.fingerId;                    // タッチ時のID
            switch (t.phase) {

                case TouchPhase.Began:
                    Vector2 pos = t.position;                                                                           // タッチした位置を取得
                    if (t.position.x <= Screen.width / 2 && tag == "LeftFripperTag") {                                  // 画面横幅全体を半分より左側を押した時
                        SetAngle(this.flickAngle);                                                                      // 左フリッパーを動かす
                    } 

                    if (t.position.x >= Screen.width / 2 && tag == "RightFripperTag") {                                 // 画面横幅全体を半分より右側を押した時
                        SetAngle(this.flickAngle);                                                                      // 右フリッパーを動かす
                    }
                    break;

                case TouchPhase.Ended:                                                                                  // タッチが離された時
                case TouchPhase.Canceled:                                                                               // タッチを解除された時
                        SetAngle(this.defaultAngle);                                                                    // フリッパーを元に戻す
                    break;
            }
        }
        /*
        for (int i = 0; i < Input.touchCount; i++) {
            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;
            Debug.LogFormat("{0} - x:{1}, y:{2}", id, pos.x, pos.y);
        }
        */

    }

    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingJoynt.spring = jointSpr;
    }
}
