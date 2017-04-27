using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ARITOMI;
using ASYSTEM;

public static class CustomizeField
{
    public const string WALL_SHUTTER = "shutter";
    public const string BALANCE = "balance";
    public const string ATTACK = "attack";
    public const string DEFENCE = "defence";

    public const string CASEIMAGE = "caseImage";
    public const string STARTBUTTON = "startButton";
    public const string GO_CUSTOMIZE = "goCustomize";
    public const string STATUS_SLIDER = "slider";
    public const string STATUS_SLIDER_OFF = "offSlider";

    public const string END_SHUTTER = "endShutter";

    public const string CUSTOMIZE_ON = "on";
    public const string CUSTOMIZE_OFF = "off";
}

public class CustomizeManager : MonoBehaviour {

    [HideInInspector] public GameObject CaseImage;    // ボタン背景
    [HideInInspector] public GameObject GoCustomize;  // カスタマイズの壁を有効化するボタン
    [HideInInspector] public CustomizeGameStart gameStartButton; // カスタマイズ完了、ゲームスタート
    [HideInInspector] public CustomizeShutter shutter;  // 機体選択の壁
    [HideInInspector] public BalanceType balanceType;   // バランス
    [HideInInspector] public AttackType attackType;     // 攻撃タイプ
    [HideInInspector] public DefenceType defenceType;   // 防御タイプ
    [HideInInspector] public EndShutter endShutter;     // 終了シャッター
    [HideInInspector] public bool IsWall = false;       // 壁の有効, 無効フラグ

    [HideInInspector] public Image SliderBG;
    [HideInInspector] public Image HpImage;
    [HideInInspector] public Image AttackImage;

    int modelType;

	// Use this for initialization
	private void Initialize () {
        AudioManager.Instance.PlayBGM(AudioName.BGMName[1]);

        // スクリプトの取得
        CaseImage = AObject.Find("Sprite/case");
        GoCustomize = AObject.Find("Canvas/GoCustomize");
        gameStartButton = AObject.Find("Canvas/Start").GetComponent<CustomizeGameStart>();
        SliderBG = AObject.Find("Canvas/StatusSlider/BG").GetComponent<Image>();
        HpImage = AObject.Find("Canvas/StatusSlider/HP").GetComponent<Image>();
        AttackImage = AObject.Find("Canvas/StatusSlider/Attack").GetComponent<Image>();
        shutter = AObject.Find("Wall/Shutter").GetComponent<CustomizeShutter>();
        balanceType = AObject.Find("Wall/Shutter/BalanceType").GetComponent<BalanceType>();
        attackType = AObject.Find("Wall/Shutter/AttackType").GetComponent<AttackType>();
        defenceType = AObject.Find("Wall/Shutter/DefenceType").GetComponent<DefenceType>();
        endShutter = AObject.Find("Wall/EndShutter").GetComponent<EndShutter>();

        if (PlayerPrefs.HasKey(DataKey.MODEL_TYPE))
        {
            PlayerPrefs.DeleteKey(DataKey.MODEL_TYPE);
        }
        PlayerPrefs.SetInt(DataKey.MODEL_TYPE, 1);
    }
    
    void Awake()
    {
        Initialize();
    }
    void Start()
    {
        Initialize();
    }

	// Update is called once per frame
	void Update () {
        GetMouseRay();
	}

    /// <summary>
    ///  壁、装備、ボタンの有効無効
    /// </summary>
    /// <param name="setActiveType">CustomizeField</param>
    public void SetActive(string setActiveType)
    {
        string name = setActiveType;

        switch (name)
        {
            case CustomizeField.CASEIMAGE:
                    CaseImage.SetActive(!IsWall);
                break;

            case CustomizeField.GO_CUSTOMIZE:
                    GoCustomize.SetActive(!IsWall);
                break;
            case CustomizeField.STARTBUTTON:
                    gameStartButton.gameObject.SetActive(!IsWall);
                break;

            case CustomizeField.STATUS_SLIDER:
                    SliderBG.enabled = true;
                    HpImage.enabled = true;
                    AttackImage.enabled = true;
                break;

            case CustomizeField.STATUS_SLIDER_OFF:
                    SliderBG.enabled = false;
                    HpImage.enabled = false;
                    AttackImage.enabled = false;
                break;

            case CustomizeField.CUSTOMIZE_ON: // IsWallは有効化、!IsWallは無効化
                    IsWall = true;
                    AudioManager.Instance.PlaySE(AudioName.SEName[1], 0);
                    shutter.SetActiveShutter(IsWall);               // シャッター
                    balanceType.SetActive(!IsWall);
                    attackType.SetActive(!IsWall);
                    defenceType.SetActive(!IsWall);
                    CaseImage.gameObject.SetActive(!IsWall);        // ボタン背景
                    gameStartButton.gameObject.SetActive(!IsWall);  // スタートボタン
                    SliderBG.enabled = false;
                    HpImage.enabled = false;
                    AttackImage.enabled = false;
                    GoCustomize.SetActive(!IsWall);                 // カスタマイズボタン
                break;

            case CustomizeField.CUSTOMIZE_OFF: // IsWallは無効化、!IsWallは有効化
                    IsWall = false;
                    shutter.SetActiveShutter(IsWall);

                break;

            case CustomizeField.END_SHUTTER:
                    IsWall = true;
                    AudioManager.Instance.PlaySE(AudioName.SEName[0],0);
                    this.SetActive(CustomizeField.STATUS_SLIDER_OFF);
                    CaseImage.gameObject.SetActive(!IsWall);        // ボタン背景
                    gameStartButton.gameObject.SetActive(!IsWall);  // スタートボタン
                    GoCustomize.SetActive(!IsWall); 
                    endShutter.SetActive(true);
                break;
        }
    }

    void GetMouseRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.name == "BalanceType")
                {
                    GetModelType = 1;
                    balanceType.SetActive(IsWall);
                    HpImage.fillAmount = 0.5f;
                    AttackImage.fillAmount = 0.5f;
                    SetActive(CustomizeField.CUSTOMIZE_OFF);
                }

                if (obj.name == "AttackType")
                {
                    GetModelType = 2;
                    attackType.SetActive(IsWall);
                    HpImage.fillAmount = 0.3f;
                    AttackImage.fillAmount = 0.8f;
                    SetActive(CustomizeField.CUSTOMIZE_OFF);
                }

                if (obj.name == "DefenceType")
                {
                    GetModelType = 3;
                    defenceType.SetActive(IsWall);
                    HpImage.fillAmount = 0.8f;
                    AttackImage.fillAmount = 0.3f;
                    SetActive(CustomizeField.CUSTOMIZE_OFF);
                }
                PlayerPrefs.SetInt(DataKey.MODEL_TYPE, GetModelType);
            }
        }
    }

    /// <summary>
    ///  両壁の有効無効変更フラグ
    /// </summary>
    public bool GetSetIsWall
    {
        get { return IsWall; }
        set { IsWall = value; }
    }
    
    /// <summary>
    ///  機体タイプ
    ///  １→通常　２→アタック　３→ディフェンス
    /// </summary>
    public int GetModelType
    {
        get { return modelType; }
        set { modelType = value; }
    }
}
