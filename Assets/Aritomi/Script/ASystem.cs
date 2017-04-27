
using UnityEngine;
using System.Collections;

namespace ASYSTEM
{
    public class AObject
    {
        // ============================================
        // パスを参照してオブジェクトを探す
        // ============================================
        public static GameObject Find(string _pass)
        {
            string[] strs = new string[32];
            GameObject[] objs = new GameObject[32];

            int maxPassCount    = _pass.Length;
            int objCount        = 0;
            int sIndex          = 0;
            int sCount          = 1;
            int passIndex       = 0;

            // _passの値を/ごとに分けてstrs配列に格納する
            while (true)
            {
                if (passIndex >= maxPassCount) break;

                // 「/」なら登録せずにsCountの値を増やす
                if (_pass[passIndex] == '/')
                {
                    sIndex++;
                    passIndex++;
                    sCount++;
                    continue;
                }

                strs[sIndex] = strs[sIndex] + _pass[passIndex];
                passIndex++;
            }

            // 取得したパスからオブジェクトを探し出す。
            for (int i = 0; i < sCount; i++)
            {
                // 最初のオブジェクトを入れる
                if (i == 0)
                {
                    objs[0] = GameObject.Find(strs[0]);
                    objCount++;
                    continue;
                }

                objs[i] = objs[i - 1].transform.FindChild(strs[i]).gameObject;
                objCount++;
            }

            return objs[objCount - 1];
        }
    } 
}
