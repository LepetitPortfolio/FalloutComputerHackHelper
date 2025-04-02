using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LettersStateUI : MonoBehaviour
{
    #region Members

    [SerializeField]
    private List<TMPro.TextMeshProUGUI> m_Characters = new List<TMPro.TextMeshProUGUI>();

    [SerializeField]
    private Color m_CharacterDefaultColor = Color.white;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        ResetStatOfCharacter();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion


    #region Functions
   
    public void ChangeCharacterColor(char _Character, Color _Color)
    {
        TMPro.TextMeshProUGUI character = FindCharacter(_Character);
        if (character != null)
        {
            character.color = _Color;
        }
    }

    private TMPro.TextMeshProUGUI FindCharacter(char _CharWanted)
    {
        TMPro.TextMeshProUGUI text = null;

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

    public void ResetStatOfCharacter()
    {
        Color defaultColor = m_CharacterDefaultColor;
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