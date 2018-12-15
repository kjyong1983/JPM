using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBulletLength : MonoBehaviour, IItem {

    public void Apply(PlayerStat stat)
    {
        stat.AddBulletLength(0.25f);
    }

    public bool IsAddHpItem()
    {
        return false;
    }
}
