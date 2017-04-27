using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private RaycastHit hit;
    private GameObject[] enemySearchList;
    public bool nextStage;
    public int selectStageNo;

    void Start()
    {
        //有効化されている敵オブジェクトを探してあったら消す
        enemyObjectDestroy();
        //ナビメッシュ
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void enemyObjectDestroy()
    {
        Debug.Log("お掃除するよ～");
        enemySearchList = GameObject.FindGameObjectsWithTag("stage"); //StageEnemy
        foreach (GameObject obs in enemySearchList)
        {
            Destroy(obs);
            Debug.Log("削除かんりょ～");
        }
        Debug.Log("なかったね");
    }

    IEnumerator DelayMethod(float time)
    {
        //処理に遅延を入れるためのタイマー
        yield return new WaitForSeconds(time);
        nextStage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "stage")
                {
                    //スイッチ文にhitからとった名前を判断して1～8の数字にしてる
                    string stageNo = hit.collider.name;
                    switch (stageNo)
                    {
                        case "stage1":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 1);
                            selectStageNo = 1;
                            break;
                        case "stage2":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 2);
                            selectStageNo = 2;
                            break;
                        case "stage3":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 3);
                            selectStageNo = 3;
                            break;
                        case "stage4":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 4);
                            selectStageNo = 4;
                            break;
                        case "stage5":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 5);
                            selectStageNo = 5;
                            break;
                        case "stage6":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 6);
                            selectStageNo = 6;
                            break;
                        case "stage7":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 7);
                            selectStageNo = 7;
                            break;
                        case "stage8":
                            PlayerPrefs.SetInt(DataKey.STAGE_CASE, 8);
                            selectStageNo = 8;
                            break;
                        default:
                            break;
                    }
                    //クリックしたステージまでナビメッシュで移動
                    agent.SetDestination(hit.transform.position);
                    //遅延処理
                    StartCoroutine(DelayMethod(0.5f));
                }
            }
        }
        //目的地との距離が０になったら
        if (agent.remainingDistance == 0)
        {
            //プレイヤーの機体を正面に向ける
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (nextStage == true)
            {
                //ここに機体選択シーンへの移動処理を
                //ステージNoは「selectStageNo」でとってね
                Application.LoadLevel("Standby");
            }
        }
    }
}
