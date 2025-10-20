using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogButtons
{
    public enum ButtonPanel
    {
        OK,
        OkCancel,
        YesNo
    }

}   // class DialogButtons



public class DialogBox : Singleton<DialogBox>
{
    [SerializeField] private GameObject _panelDialog;
    [SerializeField] private GameObject _panelOk;
    [SerializeField] private GameObject _panelOkCancel;
    [SerializeField] private GameObject _panelYesNo;
    [SerializeField] private TMP_Text   _textHeader;
    [SerializeField] private TMP_Text   _textMessage;
    [SerializeField] private Button     _buttonNewGame;
    [SerializeField] private Button     _buttonQuit;
    [SerializeField] private Button     _buttonSettings;

    public DialogButtons.ButtonPanel PanelButtons;

    public string Header  = "( header )";
    public string Message = "( message )";



    public void HideDialog()
    {
        _buttonNewGame .interactable = true;
        _buttonQuit    .interactable = true;
        _buttonSettings.interactable = true;

        _panelDialog.SetActive(false);

    }   // HideDialog()


    public void ShowDialog()
    {
        _buttonNewGame .interactable = false;
        _buttonQuit    .interactable = false;
        _buttonSettings.interactable = false;

        _panelDialog.SetActive(true);

    }   // ShowDialog()



    private void Start()
    {
        _textHeader.text  = Header;
        _textMessage.text = Message;

        _panelOk      .SetActive(false);
        _panelOkCancel.SetActive(false);
        _panelYesNo   .SetActive(false);

        switch (PanelButtons)
        {
            case DialogButtons.ButtonPanel.OK:
                _panelOk.SetActive(true);
                break;

            case DialogButtons.ButtonPanel.OkCancel:
                _panelOkCancel.SetActive(true);
                break;

            case DialogButtons.ButtonPanel.YesNo:
                _panelYesNo.SetActive(true);
                break;
        }

    }   // Start()


}   // class DialogBox
