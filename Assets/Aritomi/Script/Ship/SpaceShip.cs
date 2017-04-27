/// SpaceShip.cs
/// 2016/01/15 ver1.0
using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using ASYSTEM;

namespace ARITOMI
{
    public abstract class SpaceShip : MonoBehaviour
    {
        [SerializeField]
        private GameObject camera;

        // 機体タイプ
        protected enum ShipType
        {
            UNKNOWN,
            PLAYER_SHIP,
            ENEMY_SHIP
        }

        // デバックログを表示するか？
        [HideInInspector]
        public bool flag_display_debugLog = true;

        // UI
        [SerializeField]
        private GameObject ui_chage;

        // パーツ
        [SerializeField]
        protected Controller controller = null;    // コントローラー
        [SerializeField]
        protected MachineGun machineGun;    // 機銃
        [SerializeField]
        private GameObject shield;          // シールド
        [SerializeField]
        private GameObject chageEffect1;    // チャージエフェクト１
        [SerializeField]
        private GameObject chageEffect2;    // チャージエフェクト２
        protected int shipType = 0;

        // ステータス
        protected int hp;           // 体力
        protected int offensivePower;  // 攻撃力

        // 他のクラス
        protected BattleSceneManager BSManager;
        protected InputState ssInputState;

        // 各フラグ管理
        private GameObject obj_CountDown;   //カウントダウンオブジェクト
        protected bool bCanAct;               // 行動できるか？
        protected bool bCanChageShot;       // チャージ弾が打てるか？
        private bool bCanShield;            // シールドを展開できるか？
        private bool bCanAvoidance;         // 回避できるか？
        private float fChageTime;           // チャージタイム
        private float fCoolTime;            // クールタイム
        private float fShieldTime;          // シールドタイム

        // 初期化処理
        protected virtual void Initialize()
        {
            // クラスの登録
            obj_CountDown = AObject.Find(SSConstant.S_PASS_COUNT_DOWN);
            BSManager
                = AObject.Find(SSConstant.S_PASS_BATTLE_SCENE_MANAGER)
                .GetComponent<BattleSceneManager>();

            // チャージエフェクトを消しておく
            chageEffect1.SetActive(false);
            chageEffect2.SetActive(false);

            // 
            if (ui_chage != null)
                ui_chage.SetActive(false);

            // 入力情報を初期化
            ssInputState = InputState.TOUCH_FALSE;

            // フラグを初期化
            bCanAct = true;
            bCanChageShot = false;
            bCanShield = false;
            bCanAvoidance = true;
            if (camera != null)
                camera.GetComponent<MotionBlur>().enabled = false;

            // 時間を初期化
            fChageTime = 0f;
            fCoolTime = 0f;
            fShieldTime = 0f;
        }

        // 初期化処理
        void Start()
        {
            // 初期化
            Initialize();
        }

        // 初期化処理
        void Awake()
        {
            // 初期化
            Initialize();
        }

        // クールタイム処理
        private bool CoolTime()
        {
            // クールタイムをカウントアップする
            fCoolTime += Time.deltaTime;

            // 指定時間をこしたら行動できるようにフラグを変更
            if (fCoolTime > SSConstant.COOL_TIME)
            {
                fCoolTime = 0f;
                bCanAct = true;
                if (ui_chage != null)
                    ui_chage.SetActive(false);
            }

            return false;
        }

        // 行動できるか？
        private bool CanAct()
        {
            // 行動できるなら何もしない
            if (bCanAct) return true;

            // 行動できなかったら
            // クールタイムに入る
            return CoolTime();
        }

        // 行動した処理
        protected void Acted()
        {
            // 行動できるかのフラグをfalseに
            ssInputState = InputState.TOUCH_FALSE;
            if (ui_chage != null)
                ui_chage.SetActive(true);
            bCanAct = false;
        }

        // 回避処理
        private void ActAvoidance()
        {
            // 右フリックも左フリックもしてないなら何もしない
            if (!(ssInputState == InputState.FLICK_RIGHT ||
                ssInputState == InputState.FLICK_LEFT)) return;

            // 右フリックなら右回避、左フリックなら左回避
            switch (ssInputState)
            {
                case InputState.FLICK_RIGHT: // 右回避
                    GetComponent<Animator>().SetTrigger(SSConstant.MOVE_RIGHT);
                    if (camera != null) 
                        camera.GetComponent<MotionBlur>().enabled = true;
                    bCanAvoidance = false;
                    break;
                case InputState.FLICK_LEFT: // 左回避
                    GetComponent<Animator>().SetTrigger(SSConstant.MOVE_LEFT);
                    if (camera != null)
                        camera.GetComponent<MotionBlur>().enabled = true;
                    bCanAvoidance = false;
                    break;
            }

            // 行動した
            //Acted();
        }

        //チャージ
        private void Chage()
        {
            //何も押していないなら設定を初期化
            if (ssInputState == InputState.TOUCH_FALSE)
            {
                fChageTime = 0f;
                bCanChageShot = false;
                chageEffect1.SetActive(false);
                chageEffect2.SetActive(false);
                return;
            }

            // チャージタイムをカウントアップ
            fChageTime += Time.deltaTime;

            // チャージ１段階
            if (fChageTime > SSConstant.EFFECT_TIME)
            {
                chageEffect1.SetActive(true);
            }

            // チャージ２段階
            if (fChageTime > SSConstant.CHAGE_SHOT_TIME)
            {
                chageEffect2.SetActive(true);
                bCanChageShot = true;
            }
        }

        // 弾を撃つ処理
        protected virtual void ActShot()
        {
            // フラグの定義
            bool flag_isPushShotButton = // ショット用ボタンが押されたか？
                ssInputState == InputState.TOUCH_TOP ||
                ssInputState == InputState.TOUCH_RIGHT ||
                ssInputState == InputState.TOUCH_LEFT;

            // ショット用ボタンが押されていなければ何もしない
            if (!(flag_isPushShotButton))
                return;

            // チャージショットが打てる状態なら
            if (bCanChageShot)
            {
                // チャージショット撃つ
                machineGun.ShotChageBullet();

                // 行動した
                Acted();
                return;
            }

            // 各ボタンに対応した弾を撃つ
            switch (ssInputState)
            {
                // 通常弾
                case InputState.TOUCH_TOP:
                    machineGun.ShotNormalBullet();
                    break;
                // 右側の弾
                case InputState.TOUCH_RIGHT:
                    machineGun.ShotRightBullet();
                    break;
                // 左側の弾
                case InputState.TOUCH_LEFT:
                    machineGun.ShotLeftBullet();
                    break;
            }

            // 行動した
            Acted();
        }

        // 特別な行動
        protected abstract void ActSpecial();

        // シールド展開処理
        private void ActShield()
        {
            // 下側のボタンが押されていなければ何もしない
            if (!(ssInputState == InputState.TOUCH_BOTTOM)) return;

            // シールドを展開
            shield.SetActive(true);
            bCanShield = true;

            // 行動した
            //Acted();
        }

        // シールド処理
        private void Shield()
        {
            // シールドを展開していなければ何もしない
            if (!(bCanShield)) return;

            // シールド展開いる時間を更新
            fShieldTime += Time.deltaTime;

            // 一定時間展開したらシールドオブジェクトを無効にする
            if (fShieldTime > SSConstant.SHIELD_DELETE_TIME)
            {
                bCanShield = false;
                shield.SetActive(false);
                fShieldTime = 0f;
            }
        }

        // 操作処理
        private void Operation()
        {
            // 時間処理
            Chage();
            Shield();

            // 行動できないまたは回避中ならこの下の処理を実行しない
            if (!(bCanAvoidance)) return;

            // 回避処理
            ActAvoidance();

            // シールド処理
            ActShield();

            if (!(CanAct())) return;
            // ショット処理
            ActShot();
        }

        // 機体更新
        protected abstract void ShipUpdate();

        // 更新処理
        void Update()
        {
            // カウントダウン最中またわゲーム終了ならこの下の処理を実行しない
            if (obj_CountDown != null || BSManager.GetIsEnd() == true) return;

            // 操作
            Operation();
            // 継承先クラス用更新処理
            ShipUpdate();
        }

        // 回避した
        private void Avoidanced()
        {
            // 回避したフラグをtrueに
            bCanAvoidance = true;
            if (camera != null)
                camera.GetComponent<MotionBlur>().enabled = false;
            // 行動した
            //Acted();
        }

        // プレイヤーダメージ処理
        private void PlayerDamage()
        {
            BSManager.DamagePlayer();
        }

        // エネミーダメージ処理
        private void EnemyDamage()
        {
            BSManager.DamageEnemy();
        }

        // オブジェクトのタグ
        private bool CollisionTag(Collider _col, string _tag)
        {
            // _colのタグと_tagのタグか一致しているならtrue
            return _col.gameObject.tag == _tag;
        }

        //当たった時の処理
        void OnTriggerEnter(Collider col)
        {
            // フラグの定義
            bool flag_playerCollisionBullet =
                CollisionTag(col, TagConstant.TAG_NORMAL_BULLET)        ||  // タグが「NormalBullet」なら
                CollisionTag(col, TagConstant.TAG_RIGHT_BULLET)         ||  // タグが「RightBullet」なら
                CollisionTag(col, TagConstant.TAG_LEFT_BULLET);             // タグが「LeftBullet」なら
            bool flag_enemyCollisionBullet =
                CollisionTag(col, TagConstant.TAG_ENEMY_NORMAL_BULLET)  ||  // タグが「EnemyNormalBullet」なら
                CollisionTag(col, TagConstant.TAG_ENEMY_RIGHT_BULLET)   ||  // タグが「EnemyRightBullet」なら
                CollisionTag(col, TagConstant.TAG_ENEMY_LEFT_BULLET);       // タグが「EnemyLeftBullet」なら

            // 機体タイプを判定
            switch (shipType)
            {
                // プレイヤータイプの場合
                case (int)ShipType.PLAYER_SHIP:
                    // 当たった物体のタグが一致していたらダメージ処理を実行
                    if (flag_enemyCollisionBullet)
                    {
                        // ダメージ処理
                        PlayerDamage();
                    }
                    break;
                // エネミータイプの場合
                case (int)ShipType.ENEMY_SHIP:
                    // 当たった物体のタグが一致していたらダメージ処理を実行
                    if (flag_playerCollisionBullet)
                    {
                        // ダメージ処理
                        EnemyDamage();
                    }
                    break;
                // どちらでもない場合
                default:
                    Debug.Log("登録されていません");
                    break;
            }
        }

        /// <summary>
        /// 体力の数値を取得する
        /// </summary>
        /// <returns></returns>
        public int GetHP() { return hp; }
        /// <summary>
        /// 攻撃力の数値を取得する
        /// </summary>
        /// <returns></returns>
        public int GetOffensivePower() { return offensivePower; }
        /// <summary>
        /// シップの種類を設定
        /// </summary>
        /// <param name="shipType">0 = 未確認, 1 = プレイヤー, 2 = エネミー</param>
        public void SetShipType(int shipType) { this.shipType = shipType; }
        /// <summary>
        /// 行動したフラグを取得する
        /// </summary>
        /// <returns>行動できるならtrue、行動できないならfalse</returns>
        public bool GetCanAct() { return bCanAct; }
        
        /// <summary>
        /// デバックログを表示する
        /// </summary>
        /// <param name="str"></param>
        public void DebugLog(object _message)
        {
            if (flag_display_debugLog)
            {
                Debug.Log(_message);
            }
        }
    }
}
