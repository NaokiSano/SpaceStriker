/// 定数クラス
/// Yuho Artiomi
/// Constant.cs v1.0
using UnityEngine;
using System.Collections;

public static class Status
{
    // ディフェンスタイプ
    public const int DEFENSE_SHIP_HP                = 250;  // HP
    public const int DEFENSE_SHIP_OFFENSIVE_POWER   = 10;    // 攻撃力

    // アタックタイプ
    public const int ATTACK_SHIP_HP                 = 125;   // HP
    public const int ATTACK_SHIP_OFFENSIVE_POWER    = 20;   // 攻撃力

    // バランスタイプ
    public const int BALANCE_SHIP_HP                = 175;  // HP
    public const int BALANCE_SHIP_OFFENSIVE_POWER   = 15;   // 攻撃力

    // エネミー１
    public const int ENEMY_SHIP_1_HP                = 100;  // HP
    public const int ENEMY_SHIP_1_OFFENSIVE_POWER   = 15;   // 攻撃力
    public const int ENEMY_SHIP_1_AI                = 3;   // AIレベル

    // エネミー２
    public const int ENEMY_SHIP_2_HP                = 130;  // HP
    public const int ENEMY_SHIP_2_OFFENSIVE_POWER   = 10;   // 攻撃力
    public const int ENEMY_SHIP_2_AI                = 3;   // AIレベル

    // エネミー３
    public const int ENEMY_SHIP_3_HP                = 200;  // HP
    public const int ENEMY_SHIP_3_OFFENSIVE_POWER   = 15;   // 攻撃力
    public const int ENEMY_SHIP_3_AI                = 3;   // AIレベル

    // エネミー４
    public const int ENEMY_SHIP_4_HP                = 180;  // HP
    public const int ENEMY_SHIP_4_OFFENSIVE_POWER   = 20;   // 攻撃力
    public const int ENEMY_SHIP_4_AI                = 3;   // AIレベル

    // エネミー５
    public const int ENEMY_SHIP_5_HP                = 150;  // HP
    public const int ENEMY_SHIP_5_OFFENSIVE_POWER   = 20;   // 攻撃力
    public const int ENEMY_SHIP_5_AI                = 3;   // AIレベル

    // エネミー６
    public const int ENEMY_SHIP_6_HP                = 190;  // HP
    public const int ENEMY_SHIP_6_OFFENSIVE_POWER   = 25;   // 攻撃力
    public const int ENEMY_SHIP_6_AI                = 3;    // AIレベル

    // エネミー７
    public const int ENEMY_SHIP_7_HP                = 250;  // HP
    public const int ENEMY_SHIP_7_OFFENSIVE_POWER   = 15;   // 攻撃力
    public const int ENEMY_SHIP_7_AI                = 3;    // AIレベル

    // エネミー８
    public const int ENEMY_SHIP_8_HP                = 280;  // HP
    public const int ENEMY_SHIP_8_OFFENSIVE_POWER   = 25;   // 攻撃力
    public const int ENEMY_SHIP_8_AI                = 3;    // AIレベル
}

/// <summary>
/// バトルシーンマネージャー用定数
/// </summary>
public static class BSMConstant
{
    public const float TIME_LIMIT = 20f;
    public const string S_PASS_PLAYERSHIP       = "PlayerShip";
    public const string S_PASS_ENEMYSHIP        = "EnemyShip";
    public const string S_PASS_PLAYER           = S_PASS_PLAYERSHIP + "/Player";
    public const string S_PASS_ENEMY            = S_PASS_ENEMYSHIP + "/Enemy";
    public const string S_PASS_CANVAS           = S_PASS_PLAYERSHIP + "/Canvas";
    public const string S_PASS_PLAYER_HP_IMAGE  = S_PASS_CANVAS + "/PlayerHPImage";
    public const string S_PASS_ENEMY_HP_BAR     = S_PASS_CANVAS + "/EnemyHPBar";
    public const string S_PASS_TIME_UI          = S_PASS_CANVAS + "/TimerUI";
    public const string S_PASS_END              = S_PASS_CANVAS + "/End";
    public const string S_PASS_TIMER            = "GamePause/Timer";
}

/// <summary>
///  宇宙船用定数
/// </summary>
public static class SSConstant
{
    public const float COOL_TIME          = 1f;
    public const float EFFECT_TIME        = 1f;
    public const float CHAGE_SHOT_TIME    = 2f;
    public const float SHIELD_DELETE_TIME = 0.5f;
    public const string MOVE_RIGHT        = "right_move";
    public const string MOVE_LEFT         = "left_move";
    public const string S_NORMAL_BULLET   = "NormlBullet";
    public const string S_RIGHT_BULLET    = "RightBullet";
    public const string S_LEFT_BULLET     = "LeftBullet";
    public const string S_PASS_COUNT_DOWN = "Canvas/CountDown";
    public const string S_PASS_BATTLE_SCENE_MANAGER = "System/BattleSceneManager";
}

/// <summary>
/// プレイヤーコントローラ用定数
/// </summary>
public static class PCConstant
{
    public const float FLICK_RANGE = 60f;
}

/// <summary>
/// タグを表示
/// </summary>
public static class TagConstant
{
    public const string TAG_NORMAL_BULLET       = "NormlBullet";
    public const string TAG_RIGHT_BULLET        = "RightBullet";
    public const string TAG_LEFT_BULLET         = "LeftBullet";
    public const string TAG_ENEMY_NORMAL_BULLET = "EnemyNormalBullet";
    public const string TAG_ENEMY_RIGHT_BULLET  = "EnemyRightBullet";
    public const string TAG_ENEMY_LEFT_BULLET   = "EnemyLeftBullet";
}

/// <summary>
/// 入力情報
/// </summary>
public enum InputState
{
    TOUCH_FALSE,    //タッチしていない
    TOUCH_TRUE,     //タッチしている
    TOUCH_RIGHT,    //右側をタッチしている
    TOUCH_LEFT,     //左側をタッチしている
    TOUCH_TOP,      //上側をタッチしている
    TOUCH_BOTTOM,   //下側をタッチしている
    FLICK_RIGHT,    //右側にフリックしている
    FLICK_LEFT,     //左側にフリックしている
    FLICK_UP,       //上側にフリックしている
    FLICK_DOWN,     //下側にフリックしている
}

