using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CFOPmain : MonoBehaviour
{
    public CubeMover  Cubemover;
    public CubeStatus Cubestatus;
    public bool       IsAuto;



    [SerializeField] private Text _textStepsTaken;



    private List<string> _current_moves;
    private int          _stepsLeft;
    private int          _stepsTaken;
    private SolverPLL    _solverPLL;
    private SolverOLL    _solverOLL;
    private SolverF2L    _solverF2L;
    private SolverF1L    _solverF1L;
    private SolverCross  _solverCross;



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
        if (Cubemover.IsAvailable())
        {
            string status = Cubestatus.GetStatus();

            // Lock the mover, and unlock when finished.
            string stage = FindCurrentStage(status);
            //print(stage

            switch (stage)
            {
                case "Cross":
                    _current_moves = _solverCross.Solve(status);
                    _stepsLeft     = _current_moves.Count;
                    _stepsTaken   += _stepsLeft;
                    break;

                case "F1L":
                    _current_moves = _solverF1L.Solve(status);
                    _stepsLeft     = _current_moves.Count;
                    _stepsTaken   += _stepsLeft;
                    break;

                case "F2L":
                    _current_moves = _solverF2L.Solve(status);
                    _stepsLeft     = _current_moves.Count;
                    _stepsTaken   += _stepsLeft;
                    break;

                case "OLL":
                    _current_moves = _solverOLL.Solve(status);
                    _stepsLeft     = _current_moves.Count;
                    _stepsTaken   += _stepsLeft;
                    break;

                case "PLL":
                    _current_moves = _solverPLL.Solve(status);
                    _stepsLeft     = _current_moves.Count;
                    _stepsTaken   += _stepsLeft;
                    break;

                case "Finished":
                    ToggleAuto();
                    break;
            }

            _textStepsTaken.text = $"(Step:  {_stepsTaken})";
        }

    }   // Solve()


    public void ToggleAuto()
    {
        if (IsAuto)
        {
            IsAuto             = !IsAuto;
            Cubemover.IsLocked = false;
            _current_moves      = new List<string>();
            _stepsLeft          = 0;
        }
        else
        {
            if (!Cubemover.IsLocked)
            {
                IsAuto             = !IsAuto;
                Cubemover.IsLocked = true;
            }
        }

    }   // ToggleAuto()



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
            if (status[i] != status[27]) return false;
        }

        if (status[13] != status[16]) return false;
        if (status[22] != status[25]) return false;
        if (status[40] != status[43]) return false;
        if (status[49] != status[52]) return false;

        return true;

    }


    private bool HasF2L(string status)
    {
        for (int i = 13; i < 18; i++)
        {
            if (status[i] != status[12]) return false;
        }

        for (int i = 22; i < 27; i++)
        {
            if (status[i] != status[21]) return false;
        }

        for (int i = 40; i < 45; i++)
        {
            if (status[i] != status[39]) return false;
        }

        for (int i = 49; i < 54; i++)
        {
            if (status[i] != status[48]) return false;
        }

        return true;

    }


    private bool hasTop(string status)
    {
        for (int i = 1; i < 9; i++)
        {
            if (status[i] != status[0]) return false;
        }

        return true;

    }


    private void Start()
    {
        _current_moves = new List<string>();
        IsAuto        = false;
        _stepsLeft     = 0;
        _solverPLL     = new SolverPLL();
        _solverOLL     = new SolverOLL();
        _solverF2L     = new SolverF2L();
        _solverF1L     = new SolverF1L();
        _solverCross   = new SolverCross();

    }   // Start()


    private void Update()
    {
        if (IsAuto)
        {
            if (_stepsLeft > 0)
            {
                string code = _current_moves[_current_moves.Count - _stepsLeft];

                if (Cubemover.IsAvailable())
                {
                    _stepsLeft -= 1;
                    Cubemover.Move(code);
                }
            }
            else
            {
                Solve();
            }
        }

    }   // Update()


}   // class CFOPmain
