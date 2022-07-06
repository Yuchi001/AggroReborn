using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(StatsManager)), RequireComponent(typeof(SpriteRenderer))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject barPreset;
    [SerializeField] private float offSetMod = 0;

    private StatsManager StatsManager => GetComponent<StatsManager>();
    private Sprite Sprite => GetComponent<SpriteRenderer>().sprite;
    private Slider HealthBarSlider => instantiatedSlider.transform.GetChild(0).GetComponent<Slider>();

    private GameObject instantiatedSlider;
    private IDamagable Damagable => GetComponent<IDamagable>();


    private int Hp 
    {
        get
        {
            return Damagable.Health;
        }
    }
    private int MaxHp
    {
        get
        {
            return StatsManager.GetStatValue(EStatsType.MaxHealth);
        }
    }


    private void Setup()
    {
        if (Damagable == null)
            Destroy(gameObject);

        instantiatedSlider = Instantiate(barPreset, transform);
        HealthBarSlider.maxValue = 1;
        float yPosOffset = Sprite.bounds.size.y / 2;
        instantiatedSlider.transform.position = transform.position + new Vector3(0, yPosOffset + offSetMod, 0);
    }
    private void Start()
    {
        Setup();
    }
    private void Update()
    {
        HealthBarSlider.value = (float)Hp / MaxHp;
    }
}
