using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class CreateStatList : MonoBehaviour
{
    public StatsManager GetStatsManager()
    {
        return GetComponent<StatsManager>();
    }
    public void UpdateStats(StatsManager statsManager)
    {
        var list = new List<Stat>();
        foreach (var typeName in System.Enum.GetNames(typeof(EStatsType)))
        {
            EStatsType type = (EStatsType)System.Enum.Parse(typeof(EStatsType), typeName);
            int value = statsManager.GetStatValue(type) == -1 ? 0 : statsManager.GetStatValue(type);
            list.Add(new Stat(typeName, value, type));
        }
        statsManager.CreateStatList(list);
    }

    public void UpdateAllMBStats()
    {
        foreach(var go in FindObjectsOfTypeAll(typeof(StatsManager)))
        {
            UpdateStats(go as StatsManager);
        }
        foreach (var go in Resources.FindObjectsOfTypeAll(typeof(StatsManager)))
        {
            UpdateStats(go as StatsManager);
        }
    }
}
[CustomEditor(typeof(CreateStatList))]
public class ECreateStatList : Editor
{
    public override void OnInspectorGUI()
    {
        var createStatList = target as CreateStatList;

        if(GUILayout.Button("RefreshStats"))
        {
            var statsManager = createStatList.GetStatsManager();
            createStatList.UpdateStats(statsManager);
        }

        if (GUILayout.Button("RefreshAll"))
        {
            createStatList.UpdateAllMBStats();
        }
    }
}