using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_CharacterStat : MonoBehaviour
{

    public static UI_CharacterStat Instance { get; private set; }

    public Character MyCharacter;
    public Slider HealthSliderUI;
    public Slider StaminaSliderUI;

    public Text UI_ScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(MyCharacter == null)
        {
            return;
        }

        HealthSliderUI.value = (float)MyCharacter.Stat.Health / MyCharacter.Stat.MaxHealth;
        StaminaSliderUI.value = MyCharacter.Stat.Stamina / MyCharacter.Stat.MaxStamina;
        UI_ScoreText.text = "Score:" + MyCharacter.Score.ToString();
        
    }
}
