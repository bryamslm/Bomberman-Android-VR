using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChracterManager : MonoBehaviour
{
    public AllCharacters allCharacters;
    public TMP_Text nameText;
    public SpriteRenderer spriteRenderer;
    private int selectedOption =0;

    
    void Start()
    {
        UpdateCharacter(selectedOption);
    }

    public void NextOption(){
        selectedOption++;
        if(selectedOption >= allCharacters.CharacterCount()){
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption){
        CharacterSelection character = allCharacters.GetCharacter(selectedOption);
        nameText.text = character.characterName;
        spriteRenderer.sprite = character.characterImage;
    }

    public void PreviousOption(){
        selectedOption--;
        if(selectedOption < 0){
            selectedOption = allCharacters.CharacterCount() - 1;
        }
        UpdateCharacter(selectedOption);
    }
    public void loadGame(){
        SceneManager.LoadScene("Level 1");
    }





}
