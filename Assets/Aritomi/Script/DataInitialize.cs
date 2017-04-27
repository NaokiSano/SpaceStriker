using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataInitialize : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        PlayerPrefs.SetInt(DataKey.LIFE_CASE, 2);
        PlayerPrefs.SetInt(DataKey.STAGE_CASE, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_1, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_2, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_3, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_4, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_5, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_6, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_7, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_8, 0);
    }
}
