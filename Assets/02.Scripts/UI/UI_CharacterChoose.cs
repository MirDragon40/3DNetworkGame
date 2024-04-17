using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterChoose : MonoBehaviour
{
    public static CharacterType SelectedCharacterType = CharacterType.Female;



    public Image Image_Female;
    public Image Image_Male;

    public GameObject Character_Male;
    public GameObject Character_Female;


  
    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        Image_Female.enabled = SelectedCharacterType == CharacterType.Female;
        Image_Male.enabled = SelectedCharacterType == CharacterType.Male;

        Character_Female.SetActive(SelectedCharacterType == CharacterType.Female);
        Character_Male.SetActive(SelectedCharacterType == CharacterType.Male);
    }

    public void OnLeftButton()
    {
        int order = (int)SelectedCharacterType;
        order -= 1;
        if(order < 0)
        {
            order = (int)CharacterType.Count - 1;
        }


        SelectedCharacterType = (CharacterType)order;

     
        Refresh();
    }

    public void OnRightButton()
    {
        int order = (int)SelectedCharacterType;
        order += 1;
        if (order >= (int)CharacterType.Count)
        {
            order = 0;
        }

        SelectedCharacterType = (CharacterType)order;


        Refresh();
    }


}
