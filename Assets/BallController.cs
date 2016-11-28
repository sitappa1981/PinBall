using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // ゲームオーバー時に音を出す初期設定
    public AudioClip downSE;

    // 一度だけ実行する初期設定
    bool end = true; 

    // Use this for initialization
    void Start() {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update() {
        // ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {
            // GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            // ゲームオーバー時に音を一度だけ鳴らす
            if (end)
            GetComponent<AudioSource>().PlayOneShot(downSE);
            end = false;
        }
    }
}