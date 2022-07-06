using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private List<Stat> stats;

    [SerializeField] private Dictionary<EEffectType, bool> effects = new Dictionary<EEffectType, bool>();

    #region stats
    public void CreateStatList(List<Stat> stats)
    {
        this.stats = stats;
    }
    public int GetStatValue(EStatsType statType)
    {
        foreach(var stat in stats)
        {
            if(stat.type == statType)
                return stat.value;
        }
        return -1;
    }
    public void ChangeStatValue(Stat setStat)
    {
        foreach(var stat in stats)
        {
            if(stat.type == setStat.type)
            {
                stat.value = setStat.value;
                return;
            }
        }
    }
    #endregion

    #region effects
    private void Awake()
    {
        foreach(var value in System.Enum.GetNames(typeof(EEffectType)))
        {
            EEffectType type = (EEffectType)System.Enum.Parse(typeof(EEffectType), value);
            effects.Add(type, false);
        }
    }
    public bool IsUnderEffect(EEffectType effectType)
    {
        return effects[effectType];
    }
    public void ApplyEffect(EEffectType effectType, bool apply = true)
    {
        effects[effectType] = apply;
    }
    #endregion
}
[System.Serializable]
public class Stat
{
    public Stat(string name, int value, EStatsType type)
    {
        this.name = name;
        this.value = value;
        this.type = type;
    }

    public Stat(int value, EStatsType type)
    {
        this.value = value;
        this.type = type;
    }

    [HideInInspector] public string name;
    public int value;
    public EStatsType type;
}