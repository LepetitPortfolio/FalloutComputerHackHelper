using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LettersStateUI : MonoBehaviour
{
    #region Members

    [SerializeField]
    private List<CharactertStateColor> m_StateColor;

    [SerializeField]
    private List<TMPro.TextMeshProUGUI> m_Characters = new List<TMPro.TextMeshProUGUI>();

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        ResetStateOfCharacter();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion


    #region Functions
   
    public void ChangeStateCharacter(char _Character, ECharacterState _CharacterState)
    {
        TMPro.TextMeshProUGUI character = FindCharacter(_Character);
        character.color = FindStateColor(_CharacterState);
    }

    private TMPro.TextMeshProUGUI FindCharacter(char _CharWanted)
    {
        TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

        int characterIndex = 0;
        bool find = false;

        while ((!find) && (characterIndex < m_Characters.Count))
        {
            TMPro.TextMeshProUGUI character = m_Characters[characterIndex];

            if ((character) && (character.text.ToCharArray()[0] == _CharWanted))
            {
                text = character;
                find = true;
            }
            else
            {
                characterIndex++;
            }
        }

        return text;
    }

    private Color FindStateColor(ECharacterState _CharacterState)
    {
        Color stateColor = new Color();
        int stateIndex = 0;
        bool find = false;

        while((!find) && (stateIndex < m_StateColor.Count))
        {
            CharactertStateColor charactertStateColor = m_StateColor[stateIndex];

            if(charactertStateColor.m_LetterState == _CharacterState)
            {
                stateColor = charactertStateColor.m_Color;
                find = true;
            }
            else
            {
                stateIndex++;
            }
        }

        return stateColor;
    }

    public void ResetStateOfCharacter()
    {
        Color defaultColor = FindStateColor(ECharacterState.Unknown);
        for (int characterIndex = 0; characterIndex < m_Characters.Count; characterIndex++)
        {
            TMPro.TextMeshProUGUI character = m_Characters[characterIndex].GetComponent<TMPro.TextMeshProUGUI>();

            if (character)
            {
                character.color = defaultColor;
            }
        }
    }
    #endregion


    #region Accessors
    #endregion
}