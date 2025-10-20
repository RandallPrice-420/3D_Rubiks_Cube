using UnityEngine;


public class SettingsControl : MonoBehaviour
{
    //[SerializeField] private GameObject panelDialog;


    private void Start()
    {
        DialogBox.Instance.ShowDialog();
        //panelDialog.SetActive(true);

    }   // Start()


}   // class SettingsContro
