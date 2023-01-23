using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllCharacters : ScriptableObject
{
    public CharacterSelection[] characters;

    public int CharacterCount(){ 
        return characters.Length;
    }

    public CharacterSelection GetCharacter(int index){
        return characters[index];
    }



}
