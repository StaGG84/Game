using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotHealthBarController : MonoBehaviour
{
    public Image Healthbar;

    public void UpdateHealthBar (float curValue, float maxValue) {
        Healthbar.fillAmount = curValue / maxValue;
    }

    public void SetTeamColor(Color clr) {
        Healthbar.color = clr;
    }
}
