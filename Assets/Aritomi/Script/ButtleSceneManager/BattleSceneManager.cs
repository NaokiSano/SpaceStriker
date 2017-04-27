/// SpaceShip.cs
/// 2016/01/17 ver1.0
using UnityEngine;
using System.Collections;
using ASYSTEM;

namespace ARITOMI
{
    public class BattleSceneManager : MonoBehaviour
    {
        // 仮機体プレハブ
        public GameObject[] playerShip; // プレイヤー機体を格納するための配列
        public GameObject[] enemyShip;  // エネミー機体を格納するための配列

        // フェード
        ScreenFadeManager sfm;

        // エクスプロージョン
        [SerializeField]
        private GameObject explosion_1;
        [SerializeField]
        private GameObject explosion_2;

        // 生成位置
        public Transform playerTransform;   // プレイヤーのトランスフォーム
        public Transform enemyTransform;    // エネミーのトランスフォーム

        //UI
        private GameObject obj_timer;               // わからん
        private UI_PlayerHPImage ui_PlayerHPImage;  // 自機の体力表示処理クラス
        private UI_EnemyHP ui_EnemyHP;              // 敵機の体力表示処理クラス
        private UI_TimeDraw ui_TimeDraw;            // 制限時間表示処理クラス
        private UI_BattleEnd ui_BattleEnd;          // 終了文字表示処理クラス
        
        // 機体情報
        private SpaceShip ss_player;        // 自機クラス
        private SpaceShip ss_enemy;         // 敵機クラス
        private int i_PlayerHP;             // 自機の体力
        private int i_PlayerAttackPower;    // 自機の攻撃力
        private int i_EnemyHp;              // 敵機の体力
        private int i_EnemyAttackPower;     // 敵機の攻撃力
        
        // 制限時間
        private float fTimeLimit;
        
        // 終了フラグ
        private bool flag_isEnd;
        
        // ステージ
        private int i_stageNum;

        // 機体処理
        private void CreateShip(int playerNum, int stageNum)
        {
            // 自機の追加
            GameObject player =
                Instantiate(playerShip[playerNum],
                playerTransform.position,
                playerTransform.rotation) as GameObject;
            player.name = "PlayerShip";
            // 敵機の追加
            GameObject enemy =
                Instantiate(enemyShip[stageNum],
                enemyTransform.position,
                enemyTransform.rotation) as GameObject;
            enemy.name = "EnemyShip";
        }

        // 初期化処理
        private void Initialize()
        {
            // 
            sfm = ScreenFadeManager.Instance;

            // クラスの登録
            ss_player = AObject.Find(BSMConstant.S_PASS_PLAYER).GetComponent<SpaceShip>();
            ss_enemy = AObject.Find(BSMConstant.S_PASS_ENEMY).GetComponent<SpaceShip>();
            obj_timer = AObject.Find(BSMConstant.S_PASS_TIMER);
            Debug.Log(AObject.Find(BSMConstant.S_PASS_ENEMY_HP_BAR));
            ui_PlayerHPImage =
                AObject.Find(BSMConstant.S_PASS_PLAYER_HP_IMAGE).GetComponent<UI_PlayerHPImage>();
            ui_EnemyHP =
                AObject.Find(BSMConstant.S_PASS_ENEMY_HP_BAR).GetComponent<UI_EnemyHP>();
            ui_TimeDraw =
                AObject.Find(BSMConstant.S_PASS_TIME_UI).GetComponent<UI_TimeDraw>();
            ui_BattleEnd =
                AObject.Find(BSMConstant.S_PASS_END).GetComponent<UI_BattleEnd>();

            // 爆発
            explosion_1.transform.position = playerTransform.position;
            explosion_2.transform.position = enemyTransform.position;

            // 機体タイプの登録
            ss_player.SetShipType(1);
            ss_enemy.SetShipType(2);
            

            // HP・攻撃力の初期化
            i_PlayerHP = ss_player.GetHP();
            i_EnemyHp = ss_enemy.GetHP();
            i_PlayerAttackPower = ss_player.GetOffensivePower();
            i_EnemyAttackPower = ss_enemy.GetOffensivePower();

            // 制限時間を初期化
            fTimeLimit = BSMConstant.TIME_LIMIT;

            // 自機・敵機の体力を登録
            ui_PlayerHPImage.SetPlayerHP((float)i_PlayerHP);
            ui_PlayerHPImage.SetMaxPlayerHP((float)i_PlayerHP);
            ui_EnemyHP.SetEnemyHP((float)i_EnemyHp);
            ui_EnemyHP.SetMaxEnemyHP((float)i_EnemyHp);

            // タイマーを登録
            ui_TimeDraw.m_TimerObj = obj_timer;
            ui_BattleEnd.m_Timer = obj_timer;

            // 終了フラグの初期化
            flag_isEnd = false;
        }

        // 初期化処理
        void Start()
        {
            // 前のシーンの情報を取得
            int modelType = PlayerPrefs.GetInt(DataKey.MODEL_TYPE) - 1;
            i_stageNum = PlayerPrefs.GetInt(DataKey.STAGE_CASE);

            // 取得した情報を元に機体を作成
            CreateShip(modelType, (i_stageNum - 1));

            // 初期化
            Initialize();
        }

        // 終了処理
        private void Finish()
        {
            // フラグの定義
            bool flag_playerHpZero  = i_PlayerHP <= 0;                                      // プレイヤーの体力が0か？
            bool flag_enemyHpZero   = i_EnemyHp <= 0;                                       // エネミーの体力が0か？
            bool flag_timeOver      = obj_timer.GetComponent<Timer>().GetIsEnd() == true;   // 時間切れか？
            bool flag_playerWin     = i_PlayerHP > i_EnemyHp;                               // 自機の体力が敵機の体力より多いか？

            // 「自機・敵機の体力が０」または「時間切れ」でないなら処理を開始
            if (!(flag_playerHpZero || flag_enemyHpZero || flag_timeOver)) return;

            // 終了フラグをtrueに
            flag_isEnd = true;

            // 「自機の体力が敵機の体力より上」または「敵機の体力が０」なら勝ちを表示。
            // それ以外なら負けを表示
            if (flag_playerWin || flag_enemyHpZero)
            {
                explosion_2.SetActive(true);
                PlayerPrefs.SetInt(DataKey.STAGE_CASE, i_stageNum);
                ui_BattleEnd.Count(true);
            }
            else
            {
                explosion_1.SetActive(true);
                PlayerPrefs.SetInt(DataKey.LIFE_CASE, 1);
                ui_BattleEnd.Count(false);
            }
        }

        // 更新処理
        void Update()
        {
            // 終了処理
            Finish();
        }

        /// <summary>
        /// プレイヤーダメージ処理
        /// </summary>
        public void DamagePlayer()
        {
            sfm.FadeIn(0.5f, new Color(1f, 0f, 0f, 0.5f), () => { });
            // 体力を減らす
            i_PlayerHP -= i_EnemyAttackPower;
            // メーターを更新する
            ui_PlayerHPImage.SetPlayerHP((float)i_PlayerHP);
        }

        /// <summary>
        /// エネミーダメージ処理
        /// </summary>
        public void DamageEnemy()
        {
            // 体力を減らす
            i_EnemyHp -= i_PlayerAttackPower;
            // メーターを更新する
            ui_EnemyHP.SetEnemyHP((float)i_EnemyHp);
        }

        /// <summary>
        /// プレイヤーHPの設定
        /// </summary>
        /// <param name="_hp">int</param>
        public void SetPlayerHP(int _hp) { i_PlayerHP = _hp; }
        /// <summary>
        /// エネミーHPの設定
        /// </summary>
        /// <param name="_hp"></param>
        public void SetEnemyHP(int _hp) { i_EnemyHp = _hp; }
        /// <summary>
        /// プレイヤー攻撃力設定
        /// </summary>
        /// <param name="_attackPower"></param>
        public void SetPlayerAttackPower(int _attackPower) { i_PlayerAttackPower = _attackPower; }
        /// <summary>
        /// エネミー攻撃力設定
        /// </summary>
        /// <param name="_attackPower"></param>
        public void SetEnemyAttackPower(int _attackPower) { i_EnemyAttackPower = _attackPower; }
        /// <summary>
        /// 終了フラグを取得する
        /// </summary>
        /// <returns></returns>
        public bool GetIsEnd() { return flag_isEnd; }
    }
}