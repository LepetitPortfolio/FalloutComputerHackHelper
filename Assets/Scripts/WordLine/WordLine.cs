using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLine : MonoBehaviour 
{

	#region Membre

	private RectTransform m_RectTransform = null;

    private AddWordPanel m_AddWordPanel = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI m_Word = null;

    [SerializeField]
    private string m_ModifyWordOverlayID = string.Empty;

    bool m_IsHackWord = false;
	#endregion

	#region Initialisation
	// Use this for initialization
	void Start () 
	{
        if (!m_RectTransform)
        {
            m_RectTransform = FindAnyObjectByType<RectTransform>();
        }

        if (!m_Word)
		{
			m_Word = FindAnyObjectByType<TMPro.TextMeshProUGUI>();
		}
	}
    #endregion

    #region Accessor

    public RectTransform GetRectTransform()
    {
        if (!m_RectTransform)
        {
            m_RectTransform = GetComponent<RectTransform>();
        }
        return m_RectTransform;
    }

    public TMPro.TextMeshProUGUI GetWord()
	{
        if (!m_Word)
        {
            m_Word = GetComponent<TMPro.TextMeshProUGUI>();
        }
        return m_Word;
	}

    public bool GetIsHackWord()
    {
        return m_IsHackWord;
    }

    #endregion

    #region Unity Action

    // Update is called once per frame
    void Update()
	{

	}

    #endregion

    #region WordLine
    public void InitializeLine(string _NewWord, AddWordPanel _AddWordPanel, bool _IsHackWord)
    {
		if (!m_Word)
		{
			m_Word = GetComponent<TMPro.TextMeshProUGUI>();
		}

        if (_AddWordPanel)
        {
            m_AddWordPanel = _AddWordPanel;
        }

		m_Word.text = _NewWord;
    }

    public void OnModifyWord()
    {
        UICanva canva = LibraryFunctions.GetCanvasManager().DisplayOverlay(m_ModifyWordOverlayID, true);

        if (canva != null)
        {
            ModifyWordUI modifyWordUI = canva as ModifyWordUI;
            if (modifyWordUI != null)
            {
                modifyWordUI.SetWordLine(this);
            }
        }
    }

    public void OnDeleteWord()
    {
        LibraryFunctions.GetCanvasManager().DisplayValidActionOverlay(ExecuteDeleteWordLine);
    }

    private void ExecuteDeleteWordLine()
    {
        if(m_AddWordPanel)
        {
            m_AddWordPanel.DeleteLine(this);
        }
    }

    #endregion
}
