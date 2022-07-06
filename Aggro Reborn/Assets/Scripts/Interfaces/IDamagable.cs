using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public int Health { get; set; }
    public void ApplyDamage(int damage);
    public void ApplyEffect(EEffectType effectType, float time, int damage = 0, float repeatRate = -1);
    public void Die();
}
