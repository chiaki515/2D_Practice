using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // ゲームステート
    public enum GameState
    {
        Opening,
        Playing,
        Clear,
        Over
    }


    // 現在のゲーム進行状態
    public GameState currentState = GameState.Opening;
    private GameObject player;
    private GameObject goal;
    public GameObject start_btn;
    private GameObject title;
    private Text text;

    //ステージ画面からもらってくる
    private int stage = 1;


    void Start () {
        player = GameObject.Find("Player"); 
        goal = GameObject.Find("Goal");
        //start_btn = GameObject.Find("StartButton");
        title = GameObject.Find("Title");
        text = title.GetComponent<Text>();

        GameOpening();
    }
	

	void Update () {
		//クリアの判定
	}


    // 状態による振り分け処理
    public void dispatch(GameState state)
    {
        GameState oldState = currentState;

        currentState = state;

        switch (state)
        {
            case GameState.Opening:
                GameOpening();
                break;
            case GameState.Playing:
                GameStart();
                break;
            case GameState.Clear:
                GameClear();
                break;
            case GameState.Over:
                if (oldState == GameState.Playing)
                {
                    GameOver();
                }
                break;
        }
    }


    void GameOpening()
    {
        currentState = GameState.Opening;

        // 動作停止
        Time.timeScale = 0;

        // スタートボタンのセット
        start_btn.SetActive(true);

        // タイトル名のセット
        SetTitle("Game Start", Color.green);

        // 初期位置をセット
        player.transform.position = new Vector2(0.0f, 0.0f);
    }


    // ゲームスタート処理
    void GameStart()
    {
        // 動作開始
        Time.timeScale = 1.0f;

        // タイトル名のセット
        SetTitle("Playing", Color.green);

        start_btn.SetActive(false);
        //// ボールの初期化
        //FindObjectOfType<Ball>().Init();
    }


    // ゲームクリアー処理
    void GameClear()
    {
        stage++;

        // タイトル名のセット
        SetTitle("Game Clear", Color.yellow);

        //// 3秒後にオープニング処理を呼び出す
        //Invoke("GameOpening", 3f);

        //3秒後にメニュー画面
    }

    // ゲームオーバー処理
    void GameOver()
    {
        // タイトル名のセット
        SetTitle("Game Over", Color.red);

        //// ハイスコアの保存
        //FindObjectOfType<Score>().Save();

        //// 3秒後にオープニング処理を呼び出す
        //Invoke("GameOpening", 3f);
    }

    // オープニング処理
    void SetTitle(string message, Color color)
    {
        // タイトル名のセット
        text.text = message;
        text.color = color;
        //// パネル活性化
        //panel.SetActive(true);
    }

}
