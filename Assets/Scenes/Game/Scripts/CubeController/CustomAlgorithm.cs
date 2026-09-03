using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomAlgorithm : MonoBehaviour
{
    public ControlBadAlgoTip ControlBadAlgoTip;
    public CubeMover         Cubemover;
    public InputField        InputField;
    public int               StepsLeft;



    private string[]        _current_formula;
    private HashSet<string> _validMoves;



    public void ClearInput()
    {
        InputField.text = "";

    }   // clearInput()


    public void RevInput()
    {
        string[] moves  = InputField.text.Trim().Split(' ');
        string[] moves_ = new string[moves.Length];

        for (int i = 0; i < moves.Length; i++)
        {
            string m = moves[moves.Length - 1 - i];

            if (m[^1] == '_' || m[^1] == '\'')
            {
                moves_[i] = m.Substring(0, m.Length - 1);
            }
            else if (m[m.Length - 1] == '2')
            {
                moves_[i] = m;
            }
            else
            {
                moves_[i] = m + "\'";
            }
        }

        InputField.text = string.Join(" ", moves_);

        return;

    }   // RevInput()


    public void RunInput()
    {
        string[]     moves    = InputField.text.Replace("'", "_").Split(' ');
        List<string> moveList = new();

        foreach (string m in moves)
        {
            if (m.Length == 0) continue;

            if (!_validMoves.Contains(m))
            {
                ControlBadAlgoTip.setTimer(3);

                return;
            }
            else
            {
                moveList.Add(m);
            }
        }

        moveList = Translator.translate(moveList);
        moves = moveList.ToArray();

        if ((!Cubemover.IsLocked) && (moves.Length > 0))
        {
            Cubemover.IsLocked = true;
            _current_formula   = moves;
            StepsLeft          = moves.Length;
            // clearInput();
        }

        return;

    }   // runInput()



    private void Start()
    {
        _validMoves = new HashSet<string>
        {
            "x", "x_", "x2", "y", "y_", "y2", "z", "z_", "z2",
            "U", "U_", "U2", "R", "R_", "R2", "F", "F_", "F2",
            "D", "D_", "D2", "L", "L_", "L2", "B", "B_", "B2",
            "E", "E_", "E2", "M", "M_", "M2", "S", "S_", "S2",
            "u", "u_", "u2", "r", "r_", "r2", "f", "f_", "f2",
            "d", "d_", "d2", "l", "l_", "l2", "b", "b_", "b2",
        };

    }   // Start()


    private void Update()
    {
        if (StepsLeft > 0)
        {
            if (Cubemover.IsAvailable())
            {
                string code = _current_formula[_current_formula.Length - StepsLeft];
                StepsLeft  -= 1;

                Cubemover.Move(code);

                if (StepsLeft <= 0)
                {
                    Cubemover.IsLocked = false;
                    _current_formula    = null;
                }
            }
        }

    }   // Update()


}   // class 
