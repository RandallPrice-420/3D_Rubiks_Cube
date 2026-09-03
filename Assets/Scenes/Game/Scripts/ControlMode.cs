using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlMode: MonoBehaviour
{
    public int            Mode;
    public Button         ModeButton;
    public Transform      RubiksArrows;
    public CubeMover      Cubemover;
    public ControlShuffle ControlShuffle;
    public CubeFormulas   CubeFormulas;



    private List<string> _modes;



    public void ChangeMode()
    {
        Mode += 1;

        if (Mode >= _modes.Count)
        {
            Mode = 0;
        }

        ModeButton.GetComponentInChildren<Text>().text = _modes[Mode];

    }   // ChangeMode()



    private void Start()
    {
        Mode   = 0;
        _modes = new List<string>
        {
            "Keyboard + Mouse",
            "Keyboard"
        };

        RubiksArrows.gameObject.SetActive((Mode == 0) && (!Cubemover.IsLocked));

        //if ((mode == 0) && (!cubemover.isLocked))
        //{
        //    rubiksArrows.gameObject.SetActive(true);
        //}
        //else
        //{
        //    rubiksArrows.gameObject.SetActive(false);
        //}

    }   // Start()


    private void Update()
    {
        bool isActive = ((Mode == 0)
                      && (!Cubemover.IsLocked)
                      && (ControlShuffle.StepsLeft <= 0)
                      && (CubeFormulas.StepsLeft <= 0));

        RubiksArrows.gameObject.SetActive(isActive);

        //if ((Mode == 0)                     &&
        //    (Cubemover.isAvailable())       &&
        //    (!Cubemover.isLocked)           &&
        //    (ControlShuffle.StepsLeft <= 0) &&
        //    (CubeFormulas.  StepsLeft <= 0))
        //{
        //    RubiksArrows.gameObject.SetActive(true);
        //}
        //else
        //{
        //    RubiksArrows.gameObject.SetActive(false);
        //}

    }   // Update()


}   // class ControlMode
