using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    [SerializeField] PlayerStat stat;
    Slider hpSlider;

    private void Start()
    {
        hpSlider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update () {
        hpSlider.value = stat.Hp / 100f;
	}
}
