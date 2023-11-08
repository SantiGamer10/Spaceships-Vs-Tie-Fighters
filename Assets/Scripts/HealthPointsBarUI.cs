using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointsBarUI : MonoBehaviour
{
    [SerializeField] private HealthPoints playerHP;
    [SerializeField] private Image healthPointsBar;

    private void OnEnable()
    {
        playerHP.onChange += UpdateBar;
    }
    private void OnDisable()
    {
        playerHP.onChange -= UpdateBar;
    }
    private void UpdateBar() 
    {
        healthPointsBar.fillAmount = playerHP.Ratio;
    }
}
