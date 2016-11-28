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

        // マウスの左クリックを押した時及びスマートフォンでタップした時、フリッパーを動かす
        if (Input.GetMouseButton(0)) {
            SetAngle(this.flickAngle);
        }

        // マウスの左クリックを話した時及びスマートフォンでタップを外した時に、フリッパーを元に戻す
        if (Input.GetMouseButtonUp(0)) {
            SetAngle(this.defaultAngle);
        }
    }


    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingJoynt.spring = jointSpr;
    }
}
