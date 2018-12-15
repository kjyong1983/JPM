using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHp : MonoBehaviour, IItem
{
    public void Apply(PlayerStat stat)
    {
        stat.AddHp(15f);
    }

    public bool IsAddHpItem()
    {
        return true;
    }
}
