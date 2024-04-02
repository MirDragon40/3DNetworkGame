using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCanvasAbility : CharacterAbility
{
    public Canvas MyCanvas;
    public Text NicknameTextUI;

    public Slider StaminaSliderUI;
    public Slider HealthSliderUI;


    // Start is called before the first frame update
    void Start()
    {
        NicknameTextUI.text = _owner.PhotonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaSliderUI.value = (float)_owner.Stat.Stamina / _owner.Stat.MaxStamina;
        HealthSliderUI.value = (float)_owner.Stat.Health / _owner.Stat.MaxHealth;
    }

}
