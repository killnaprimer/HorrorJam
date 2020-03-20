using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerUi : MonoBehaviour
{
    public Text ammoText;
    public Text medText;
    public GameObject interactor;
    public Image healthScreen;
    public Image healthBar;
    public Text questText;
    
    public void SetAmmoText(int currAmmo, int maxAmmo)
    {
        ammoText.text = currAmmo.ToString() + "/" + maxAmmo.ToString();
    }

    public void SetMedText(int medkit)
    {
        medText.text = medkit.ToString();
    }

    public void ShowInteractor(bool show)
    {
        interactor.SetActive(show);
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        Color color = new Color(1,1,1,(1-health/maxHealth));
        healthScreen.color = color;
        healthBar.fillAmount = health / maxHealth;
    }

    public void UpdateQuest(int filter)
    {
        if (filter <= 0)
        {
            questText.text = "Найдите водный фильтр.";
        }
        else
        {
            questText.text = "Фильтр найден. Покиньте станцию.";
        }
    }
    
    
}
