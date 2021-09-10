using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerSessionData : MonoBehaviour,ISaveable
{
    private string sid;
    public string playerName;
    public int score;
    public void PopulateSaveData(SaveData a_SaveData){
        a_SaveData.m_playRecords.Add(this);
    }
    public void LoadFromSaveData(SaveData a_SaveData){
        a_SaveData.m_playRecords.Add(this);
    }
}
