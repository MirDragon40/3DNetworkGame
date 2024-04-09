using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeAbility : MonoBehaviour
{
    [Header("Male")]
    public GameObject Body05;
    public GameObject Cloak02;
    public GameObject Head01_Male;
    public GameObject Hair01;

    [Header("Female")]
    public GameObject Body10;
    public GameObject Cloak03;
    public GameObject Head02_Female;
    public GameObject Hair06;




    private void Awake()
    { 

    }

    private void Start()
    {
        if (UI_CharacterChoose.Instance._isFemaleCharacter)
        {
            Body05.SetActive(false);
            Cloak02.SetActive(false);
            Head01_Male.SetActive(false);
            Hair01.SetActive(false);

            Body10.SetActive(true);
            Cloak03.SetActive(true);
            Head02_Female.SetActive(true);
            Hair06.SetActive(true);

        }
        else
        {
            Body05.SetActive(true);
            Cloak02.SetActive(true);
            Head01_Male.SetActive(true);
            Hair01.SetActive(true);

            Body10.SetActive(false);
            Cloak03.SetActive(false);
            Head02_Female.SetActive(false);
            Hair06.SetActive(false);
        }
    }


}
