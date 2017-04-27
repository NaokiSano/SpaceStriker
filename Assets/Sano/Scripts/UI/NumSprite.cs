using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumSprite : MonoBehaviour {

    [SerializeField]
    GameObject showSprite;

    [SerializeField]
    Sprite _1;
    [SerializeField]
    Sprite _2;
    [SerializeField]
    Sprite _3;

    [SerializeField]
    float width;    // 数字の表示間隔
    int showValue;  // 表示する値
    GameObject[] numSpriteGrid;         // 表示用スプライトオブジェクト配列
    Dictionary<char, Sprite> dicSprite; // スプライトディクショナリ

    void Awake()
    {
        dicSprite = new Dictionary<char, Sprite>() {
            { '1', _1 },
            { '2', _2 },
            { '3', _3 },
        };
    }

    void Start()
    {
        
    }

    public int Value
    {
        get { return showValue; }
        set
        {
            showValue = value;

            // 表示用文字列を取得
            string strValue = value.ToString();

            // 現在表示中のオブジェクトを削除
            if (numSpriteGrid != null)
            {
                foreach (var numSprite in numSpriteGrid)
                {
                    GameObject.Destroy(numSprite);
                }
            }

            // 表示桁数分だけオブジェクトを作成
            numSpriteGrid = new GameObject[strValue.Length];
            for(int i = 0; i<numSpriteGrid.Length; ++i)
            {   // オブジェクト作成
                numSpriteGrid[i] = Instantiate(showSprite, transform.position + new Vector3((float)i * width, 0), Quaternion.identity) as GameObject;

                // 表示する数値を設定
                numSpriteGrid[i].GetComponent<SpriteRenderer>().sprite = dicSprite[strValue[i]];

                // 自身の子階層に移動
                numSpriteGrid[i].transform.parent = transform;
            }
        }
    }
}
