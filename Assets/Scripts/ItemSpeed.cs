using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : MonoBehaviour, IItem {
    public void Apply(PlayerStat stat)
    {
        stat.AddSpeed(0.25f);
    }

    public bool IsAddHpItem()
    {
        return false;
    }

}
