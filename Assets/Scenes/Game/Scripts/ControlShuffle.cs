using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlShuffle : MonoBehaviour
{
    public CubeMover Cubemover;
    public Text      ShuffleText;
    public int       StepsLeft;



    private int           _mode;
    private List<string>  _modes;
    private List<string>  _movingCodes;
    private System.Random _random;



    private void Start()
    {
        _random = new System.Random();

        StepsLeft = 0;
        _mode     = 0;

        _modes = new List<string>
        {
            "Shuffle (10 Steps)",
            "Shuffle (20 Steps)",
            "Shuffle (40 Steps)"
        };

        _movingCodes = new List<string>(new string[]
        {
            "F_L", "F_R", "Fm_L" ,"Fm_R", "B_L", "B_R",
            "R_F", "R_B", "Rm_F" ,"Rm_B", "L_F", "L_B",
            "U_R", "U_L", "Um_R", "Um_L", "D_R", "D_L"
        });

    }   // Start()


    public void ModeIncrease() 
    {
        _mode += 1;

        if (_mode >= _modes.Count)
        {
            _mode = 0;
        }

        ShuffleText.text = _modes[_mode];

    }   //  ModeIncrease()


    public void ModeReduce()
    {
        _mode -= 1;

        if (_mode < 0) 
        {
            _mode = _modes.Count - 1;
        }

        ShuffleText.text = _modes[_mode];

    }   // ModeReduce()


    public void ShuffleCube()
    {
        if (!Cubemover.IsLocked) 
        {
            Cubemover.IsLocked = true;

            switch (_mode)
            {
                case 0: StepsLeft = 10; break;
                case 1: StepsLeft = 20; break;
                case 2: StepsLeft = 40; break;
            }
        }

    }   // ShuffleCube()



    private void Update()
    {
        if (StepsLeft > 0)
        {
            if (Cubemover.IsAvailable())
            {
                StepsLeft  -= 1;
                string code = _movingCodes[_random.Next(_movingCodes.Count)];

                Cubemover.Move(code);

                if (StepsLeft == 0) 
                {
                    Cubemover.IsLocked = false;
                }
            }
        }

    }   // Update()


}   // class ControlShuffle
