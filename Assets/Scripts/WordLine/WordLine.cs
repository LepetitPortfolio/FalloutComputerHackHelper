using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLine : MonoBehaviour 
{

	#region Membre

	private RectTransform m_RectTransform = null;


    private TMPro.TextMeshProUGUI m_Word = null;
	#endregion

	#region Initialisation
	// Use this for initialization
	void Start () 
	{
        if (!m_RectTransform)
        {
            m_RectTransform = FindObjectOfType<RectTransform>();
        }

        if (!m_Word)
		{
			m_Word = FindObjectOfType<TMPro.TextMeshProUGUI>();
		}
	}
    #endregion

    #region Accessor

    public RectTransform GetRectTransform()
    {
        if (!m_RectTransform)
        {
            m_RectTransform = FindObjectOfType<RectTransform>();
        }
        return m_RectTransform;
    }

    public TMPro.TextMeshProUGUI GetWord()
	{
        if (!m_Word)
        {
            m_Word = FindObjectOfType<TMPro.TextMeshProUGUI>();
        }
        return m_Word;
	}

    #endregion

    #region Unity Action

    // Update is called once per frame
    void Update()
	{

	}

    void OnDestroy()
    {
        
        //DestroyImmediate(m_Word);
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
