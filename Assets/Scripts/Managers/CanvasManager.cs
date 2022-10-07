using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CanvasManager : MonoBehaviour
{
    #region Members

    [SerializeField]
    private EGameState m_DefaultGameState = EGameState.MainMenu;

    private EGameState m_CurrentGameState = EGameState.None;

    [SerializeField]
    private List<CanvasState> m_CanvasList;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        HideAllCanvas();
        ChangeCurrentCanva(m_DefaultGameState);
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion


    #region Functions

    private void HideAllCanvas()
    {
        for(int canvaIndex = 0; canvaIndex < m_CanvasList.Count; canvaIndex++)
        {
            m_CanvasList[canvaIndex].m_CanvaState.gameObject.SetActive(false);
        }
    }

    public bool ChangeCurrentCanva(EGameState _NewGameState)
    {
        if(m_CurrentGameState != EGameState.None)
        {
            CanvasState canvasFound = FindCanvasByGameState(m_CurrentGameState);
            if (canvasFound.m_GameSate != EGameState.None)
            {
                canvasFound.m_CanvaState.gameObject.SetActive(false);
            }
        }

        if(_NewGameState != EGameState.None)
        {
            CanvasState canvasFound = FindCanvasByGameState(_NewGameState);
            if (canvasFound.m_GameSate != EGameState.None)
            {
                canvasFound.m_CanvaState.gameObject.SetActive(true);
                m_CurrentGameState = _NewGameState;
                return true;
            }
        }

        return false;
    }

    public CanvasState FindCanvasByGameState(EGameState _GameState)
    {
        CanvasState canva = new CanvasState();
        int canvaIndex = 0;

        while((canva.m_GameSate == EGameState.None) && (canvaIndex < m_CanvasList.Count))
        {
            CanvasState c = m_CanvasList[canvaIndex];
            if (c.m_GameSate == _GameState)
            {
                canva = c;                
            }
            else
            {
                canvaIndex++;
            }
        }

        return canva;
    }

    #endregion


    #region Accessors
    #endregion
}