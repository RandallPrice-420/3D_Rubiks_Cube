using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CFOPmain : MonoBehaviour
{
    public CubeMover  Cubemover;
    public CubeStatus Cubestatus;
    public bool       IsAuto;

    [SerializeField] private TMP_Text _textSteps;


    private List<string> current_moves;
    private int          stepsLeft;
    private SolverPLL    solverPLL;
    private SolverOLL    solverOLL;
    private SolverF2L    solverF2L;
    private SolverF1L    solverF1L;
    private SolverCross  solverCross;



    public string FindCurrentStage(string status)
    {
        if (Cubestatus.isFinished(status))
        {
            return "Finished";
        }
        else
        {
            if (HasCross(status))
            {
                if (HasF1L(status))
                {
                    if (HasF2L(status))
                    {
                        if (hasTop(status))
                        {
                            return "PLL";
                        }

                        return "OLL";
                    }

                    return "F2L";
                }

                return "F1L";
            }

            return "Cross";
        }

    }   // FindCurrentStage()


    public void Solve()
    {
        if (Cubemover.isAvailable())
        {
            string status = Cubestatus.GetStatus();

            // Lock the mover, and unlock when finished.
            string stage = FindCurrentStage(status);
            //print(stage

            switch (stage)
            {
                case "Cross":
                    current_moves = solverCross.Solve(status);
                    stepsLeft = current_moves.Count;
                    break;

                case "F1L":
                    current_moves = solverF1L.Solve(status);
                    stepsLeft = current_moves.Count;
                    break;

                case "F2L":
                    current_moves = solverF2L.Solve(status);
                    stepsLeft = current_moves.Count;
                    break;

                case "OLL":
                    current_moves = solverOLL.Solve(status);
                    stepsLeft = current_moves.Count;
                    break;

                case "PLL":
                    current_moves = solverPLL.Solve(status);
                    stepsLeft = current_moves.Count;
                    break;

                case "Finished":
                    ToggleAuto();
                    break;
            }
        }

    }


    public void ToggleAuto()
    {
        if (IsAuto)
        {
            IsAuto             = !IsAuto;
            Cubemover.isLocked = false;
            current_moves      = new List<string>();
            stepsLeft          = 0;
        }
        else
        {
            if (!Cubemover.isLocked)
            {
                IsAuto             = !IsAuto;
                Cubemover.isLocked = true;
            }
        }

    }



    private bool HasCross(string status)
    {
        if (status[28] == status[31] && status[30] == status[31] &&
            status[32] == status[31] && status[34] == status[31] &&
            status[13] == status[16] && status[22] == status[25] &&
            status[40] == status[43] && status[49] == status[52])
        {
            return true;
        }

        return false;
    }


    private bool HasF1L(string status)
    {
        for (int i = 28; i < 36; i++)
        {
            if (status[i] != status[27])
            {
                return false;
            }
        }

        if (status[13] != status[16])
        {
            return false;
        }

        if (status[22] != status[25])
        {
            return false;
        }

        if (status[40] != status[43])
        {
            return false;
        }

        if (status[49] != status[52])
        {
            return false;
        }

        return true;

    }


    private bool HasF2L(string status)
    {
        for (int i = 13; i < 18; i++)
        {
            if (status[i] != status[12])
            {
                return false;
            }
        }

        for (int i = 22; i < 27; i++)
        {
            if (status[i] != status[21])
            {
                return false;
            }
        }

        for (int i = 40; i < 45; i++)
        {
            if (status[i] != status[39])
            {
                return false;
            }
        }

        for (int i = 49; i < 54; i++)
        {
            if (status[i] != status[48])
            {
                return false;
            }
        }

        return true;

    }


    private bool hasTop(string status)
    {
        for (int i = 1; i < 9; i++)
        {
            if (status[i] != status[0])
            {
                return false;
            }
        }

        return true;

    }


    private void Start()
    {
        current_moves = new List<string>();
        IsAuto        = false;
        stepsLeft     = 0;

        solverPLL   = new SolverPLL();
        solverOLL   = new SolverOLL();
        solverF2L   = new SolverF2L();
        solverF1L   = new SolverF1L();
        solverCross = new SolverCross();

        //   (### / ###)
    }


    private void Update()
    {
        if (IsAuto)
        {
            if (stepsLeft > 0)
            {
                string code = current_moves[current_moves.Count - stepsLeft];

                if (Cubemover.isAvailable())
                {
                    stepsLeft -= 1;
                    Cubemover.move(code);
                }
            }
            else
            {
                Solve();
            }
        }

    }


}   // class CFOPmain
