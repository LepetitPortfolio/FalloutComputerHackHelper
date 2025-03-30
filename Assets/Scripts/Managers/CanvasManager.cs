using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CanvasManager : MonoBehaviour
{
    #region Members

    public static CanvasManager m_Instance { get; private set; }

    [SerializeField]
    private EGameState m_DefaultGameState = EGameState.MainMenu;

    private EGameState m_CurrentGameState = EGameState.None;

    [SerializeField]
    private List<CanvasState> m_CanvasListEditor;
    private Dictionary<EGameState, CanvasState> m_CanvasList;

    [SerializeField]
    private List<CanvasOverlay> m_OverlayCanvasListEditor;
    private Dictionary<string, CanvasOverlay> m_OverlayCanvasList;

    [SerializeField]
    private Canvas m_ValidActionOverlayCanva;

    private ValidUI m_ValidUI = null;

    #endregion


    #region Manipulators

    private void Awake()
    {
        if (m_Instance != null)
        {
            Debug.LogError("Found more than one Canvas Manager in this scene");
        }
        m_Instance = this;

    }

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        InitializeAllCanvas();
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

    private void InitializeAllCanvas()
    {
        m_CanvasList = new Dictionary<EGameState, CanvasState>();
        m_OverlayCanvasList = new Dictionary<string, CanvasOverlay>();

        for (int canvaIndex = 0; canvaIndex < m_CanvasListEditor.Count; canvaIndex++)
        {
            CanvasState canvasState = m_CanvasListEditor[canvaIndex];

            canvasState.GetCanvaState().gameObject.SetActive(false);

            m_CanvasList[canvasState.GetGameState()] = canvasState;
        }

        for (int canvaIndex = 0; canvaIndex < m_OverlayCanvasListEditor.Count; canvaIndex++)
        {
            CanvasOverlay canvasOverlay = m_OverlayCanvasListEditor[canvaIndex];

            canvasOverlay.GetOverlayCanva().gameObject.SetActive(false);

            canvasOverlay.m_UICanva = canvasOverlay.GetOverlayCanva().GetComponent<UICanva>();

            m_OverlayCanvasList[canvasOverlay.GetOverlayID()] = canvasOverlay;

        }

        m_ValidActionOverlayCanva.gameObject.SetActive(false);
        m_ValidUI = m_ValidActionOverlayCanva.GetComponent<ValidUI>();
    }

    public bool ChangeCurrentCanva(EGameState _NewGameState)
    {
        if(m_CurrentGameState != EGameState.None)
        {
            CanvasState canvasFound = m_CanvasList[m_CurrentGameState];
            if (canvasFound.GetGameState() != EGameState.None)
            {
                canvasFound.GetCanvaState().gameObject.SetActive(false);
            }
        }

        if(_NewGameState != EGameState.None)
        {
            CanvasState canvasFound = m_CanvasList[_NewGameState];
            if (canvasFound.GetGameState() != EGameState.None)
            {
                canvasFound.GetCanvaState().gameObject.SetActive(true);
                m_CurrentGameState = _NewGameState;
                return true;
            }
        }

        return false;
    }

    public UICanva DisplayOverlay(string _OverlayID, bool _Value)
    {
        if(_OverlayID == string.Empty)
        {
            return null;
        }

        UICanva outUICanva = null;

        CanvasOverlay canvasFound = m_OverlayCanvasList[_OverlayID];
        if (canvasFound.GetOverlayID() == _OverlayID)
        {
            canvasFound.GetOverlayCanva().gameObject.SetActive(_Value);
            outUICanva = canvasFound.GetUICanva();
        }

        return outUICanva;
    }

    public void DisplayValidActionOverlay(ActionValidate _ActionToValidate)
    {
        if(m_ValidUI)
        {
            m_ValidUI.SetActionValidateHandler(_ActionToValidate);
            m_ValidActionOverlayCanva.gameObject.SetActive(true);
        }
    }

    #endregion


    #region Accessors
    #endregion
}