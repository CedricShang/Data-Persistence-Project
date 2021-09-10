using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    
    public List<PlayerSessionData> m_playRecords;
    
    
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(SaveData a_SaveData);
    void LoadFromSaveData(SaveData a_SaveData);
}