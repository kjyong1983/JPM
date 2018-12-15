using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBulletAttackDelay : MonoBehaviour, IItem {
    public void Apply(PlayerStat stat)
    {
        stat.AddAttackSpeedLevel(1f);
    }

    public bool IsAddHpItem()
    {
        return false;
    }
}
