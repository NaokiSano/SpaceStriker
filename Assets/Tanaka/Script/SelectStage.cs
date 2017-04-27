using UnityEngine;
using System.Collections;

public class SelectStage : MonoBehaviour
{
    public GameObject _player;
    public GameObject _flagManager;
    public GameObject _enemyEffect;
    public int _lCase;//生存フラグ
    public int _sCase;//ステージフラグ

    private GameObject stage1;
    private GameObject stage2;
    private GameObject stage3;
    private GameObject stage4;
    private GameObject stage5;
    private GameObject stage6;
    private GameObject stage7;
    private GameObject stage8;

    void Start()
    {
        _lCase = 2;
        _sCase = 0;

        stage1 = _flagManager.transform.FindChild("stage1").gameObject;
        stage2 = _flagManager.transform.FindChild("stage2").gameObject;
        stage3 = _flagManager.transform.FindChild("stage3").gameObject;
        stage4 = _flagManager.transform.FindChild("stage4").gameObject;
        stage5 = _flagManager.transform.FindChild("stage5").gameObject;
        stage6 = _flagManager.transform.FindChild("stage6").gameObject;
        stage7 = _flagManager.transform.FindChild("stage7").gameObject;
        stage8 = _flagManager.transform.FindChild("stage8").gameObject;

        stage1.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_1) == 1);
        stage2.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_2) == 1);
        stage3.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_3) == 1);
        stage4.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_4) == 1);
        stage5.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_5) == 1);
        stage6.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_6) == 1);
        stage7.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_7) == 1);
        stage8.SetActive(PlayerPrefs.GetInt(DataKey.STAGE_8) == 1);
    }


    // Update is called once per frame
    void Update()
    {
        //生死の判定
        switch (_lCase)
        {
            case(0):
                break;
            case (1)://死亡
                break;
            case (2)://生存
                _Flag();
                break;
            default:
                break;
        }
    }

    //次のステージ出現
    //無効化してあるオブジェクトをアクティブにすることで次のステージを表示
    void _Flag()
    {
        switch (_sCase)
        {
            case(0):
                break;

            case (1)://ステージ１

                stage1.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_1, 1);

                stage2.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_2, 1);
                break;

            case (2)://ステージ２

                stage3.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_3, 1);
                stage4.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_4, 1);
                break;

            case (3)://ステージ３

                stage4.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_4, 1);
                stage5.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_5, 1);
                break;

            case (4)://ステージ４

                stage6.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_6, 1);
                break;

            case (5)://ステージ５

                stage6.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_6, 1);
                stage7.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_7, 1);
                break;

            case (6)://ステージ６

                //stage7.SetActive(true);
                break;

            case (7)://ステージ７

                stage8.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_8, 1);
                break;

            case (8)://ステージ８

                stage8.SetActive(true);
                //PlayerPrefs.SetInt(DataKey.STAGE_8, 1);
                break;
            default:
                break;
        }
    }
}