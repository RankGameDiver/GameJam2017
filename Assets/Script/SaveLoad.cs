using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public LopeKind lopeKind;

    void Start()
    {
        lopeKind.S_LopeList.Add(new Lope(0, "First"));
        lopeKind.S_LopeList.Add(new Lope(1, "Second"));
        Save();
        Load(lopeKind.randomLope);
    }

    public void Save()
    {
        JsonData charData = JsonMapper.ToJson(lopeKind.S_LopeList);
        File.WriteAllText(Application.dataPath + "/Resource/PlayerChar.json", charData.ToString());
        Debug.Log(lopeKind.S_LopeList);
    }

    private void Load(int temp)
    {
        string L_PlayerCharData = File.ReadAllText(Application.dataPath + "/Resource/PlayerChar.json");
        Debug.Log(L_PlayerCharData);
        JsonData charData = JsonMapper.ToObject(L_PlayerCharData);
        GetData(charData, temp);
        //GetDataTest(charData);
    }

    private void GetDataTest(JsonData name) // 테스트용
    {
        for (int i = 0; i < name.Count; i++)
        {
            Debug.Log(name[i]["ID"]);
            string tempID = name[i]["ID"].ToString();

            for (int j = 0; j < lopeKind.S_LopeList.Count; j++)
            {
                if (tempID == lopeKind.S_LopeList[j].ID.ToString())
                {
                    lopeKind.S_LopeList.Remove(lopeKind.S_LopeList[j]);
                    lopeKind.S_LopeList.Add(lopeKind.S_LopeList[j]);

                }
            }
        }
        for (int i = 0; i < lopeKind.S_LopeList.Count; i++)
        {
            Debug.Log("불러온 데이터 = " + lopeKind.S_LopeList[i].Name);
        }
    }

    private void GetData(JsonData name, int temp)
    {
        string tempID = name[temp]["ID"].ToString();
        Debug.Log("불러온 데이터 = " + lopeKind.S_LopeList[temp].Name);
    }
}
