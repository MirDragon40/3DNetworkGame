using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterChoose : MonoBehaviour
{

    public static UI_CharacterChoose Instance { get; private set; }

    public bool _isFemaleCharacter = true;

    public Image Image_Female;
    public Image Image_Male;

    public GameObject Character_Male;
    public GameObject Character_Female;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _isFemaleCharacter = true;

        Image_Female.enabled = true;
        Image_Male.enabled = false;

        Character_Female.SetActive(true);
        Character_Male.SetActive(false);

    }

    public void OnLeftButton()
    {
        if(_isFemaleCharacter)
        {
            _isFemaleCharacter = false;

            Image_Female.enabled = false;
            Image_Male.enabled = true;

            Character_Female.SetActive(false);
            Character_Male.SetActive(true);

        }
        else
        {
            _isFemaleCharacter = true;

            Image_Female.enabled = true;
            Image_Male.enabled = false;

            Character_Female.SetActive(true);
            Character_Male.SetActive(false);

        }
    }
    
    public void OnRightButton()
    {

        if (_isFemaleCharacter)
        {
            _isFemaleCharacter = false;

            Image_Female.enabled = false;
            Image_Male.enabled = true;

            Character_Female.SetActive(false);
            Character_Male.SetActive(true);

        }
        else
        {
            _isFemaleCharacter = true;

            Image_Female.enabled = true;
            Image_Male.enabled = false;

            Character_Female.SetActive(true);
            Character_Male.SetActive(false);

        }
    }


}
