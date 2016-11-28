using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    public Text pointText;   // Text用変数
    private int point = 0;   // 点数計算用変数
    public AudioClip coinSE; // 対象物と接触時に音を鳴らす初期設定

    // Use this for initialization
    void Start () {
        pointText.text = "Point: 0";        // 初期点を代入して画面に表示
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 接触時に点数を加える命令
    private void OnCollisionEnter(Collision collision) {
        string yourTag = collision.gameObject.tag;

        if ( yourTag == "SmallStarTag") {                                                 // 小さい円柱に接触すると1点加算、音を鳴らす
            point += 1;
            GetComponent<AudioSource>().PlayOneShot(coinSE);
        } else if( yourTag == "LargeStarTag" || yourTag == "SmallCloudTag") {             // 星と小さい雲に接触すると10点加算、音を鳴らす
            point += 10;
            GetComponent<AudioSource>().PlayOneShot(coinSE);
        } else if (yourTag == "LargeCloudTag") {                                          // 大きい雲に接触すると100点追加、音を鳴らす
            point += 100;
            GetComponent<AudioSource>().PlayOneShot(coinSE);

        }

        Setpoint();
    }

    // 点数結果を表示する命令
    void Setpoint() {
        pointText.text = string.Format("Point:{0}", point);     
    }


}
