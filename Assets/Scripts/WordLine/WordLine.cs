using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLine : MonoBehaviour 
{

	#region Membre
	private TMPro.TextMeshProUGUI m_Word = null;
	#endregion

	#region Initialisation
	// Use this for initialization
	void Start () 
	{
		if (!m_Word)
		{
			m_Word = FindObjectOfType<TMPro.TextMeshProUGUI>();
		}
	}
    #endregion

    #region Accessor

    #endregion

    #region Unity Action

	// Update is called once per frame
	void Update()
	{

	}

    #endregion
	
	#region WordLine
	public void SetWord(string _NewWord)
    {
		if (!m_Word)
		{
			m_Word = FindObjectOfType<TMPro.TextMeshProUGUI>();
		}
		m_Word.text = _NewWord;
    }

    #endregion
}
