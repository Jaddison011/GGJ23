using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {
    public Image chargeBarImage;

    public void updateBar(float charge, float maxCharge) {
        chargeBarImage.fillAmount = charge / maxCharge;
    }
}
