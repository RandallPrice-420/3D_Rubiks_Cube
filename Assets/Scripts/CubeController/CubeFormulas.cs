using System.Collections.Generic;
using UnityEngine;


public class CubeFormulas : MonoBehaviour
{
    public int       StepsLeft;
    public CubeMover Cubemover;



    private string[] current_formula;
    private string[] formula_2_L;
    private string[] formula_2_R;
    private string[] formula_3_cross_L;
    private string[] formula_3_fish_L;
    private string[] formula_3_fish_R;
    private string[] formula_3_corner;
    private string[] formula_3_triple_L;
    private string[] formula_3_triple_R;
    private string[] formula_3_quadruple;



    public void runFormula(List<string> my_formula)
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = my_formula.ToArray();
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula()


    public void runFormula_2_L()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_2_L;
            StepsLeft          = current_formula.Length;

            if (StepsLeft == 0)
            {
                Cubemover.isLocked = false;
            }
        }

    }   // runFormula_2_L()


    public void runFormula_2_R()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_2_R;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_2_R()


    public void runFormula_3_cross_L()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_cross_L;
            StepsLeft          = current_formula.Length;
        }
    }

    public void runFormula_3_fish_L()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_fish_L;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_fish_L()


    public void runFormula_3_fish_R()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_fish_R;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_fish_R()


    public void runFormula_3_corner()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_corner;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_corner()


    public void runFormula_3_triple_L()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_triple_L;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_triple_L()


    public void runFormula_3_triple_R()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_triple_R;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_triple_R()


    public void runFormula_3_quadruple()
    {
        if (StepsLeft <= 0 && !Cubemover.isLocked)
        {
            Cubemover.isLocked = true;
            current_formula    = formula_3_quadruple;
            StepsLeft          = current_formula.Length;
        }

    }   // runFormula_3_quadruple()


    private void Start()
    {
        formula_2_L       = new string[] { "U_L", "R_B", "U_R", "R_F", "U_R", "F_L", "U_L", "F_R" };
        formula_2_R       = new string[] { "U_R", "F_L", "U_L", "F_R", "U_L", "R_B", "U_R", "R_F" };
        formula_3_cross_L = new string[] { "F_R", "U_L", "R_B", "U_R", "R_F", "F_L"               };
        formula_3_fish_L  = new string[] { "F_R", "U_L", "F_L", "U_L", "F_R", "U_L", "U_L", "F_L" };
        formula_3_fish_R  = new string[] { "R_F", "U_R", "R_B", "U_R", "R_F", "U_R", "U_R", "R_B" };

        formula_3_corner = new string[]
        {
            "A_UR", "A_FL", "U_L", "U_L", "R_B", "U_R", "U_R", "R_F", "F_R",
            "F_R",  "U_L",  "U_L", "L_B", "U_L", "U_L", "L_F", "F_L", "F_L", "A_FR",
        };

        formula_3_triple_L = new string[]
        {
            "A_UL", "A_UL", "R_F", "U_R", "R_B", "U_R", "R_F", "U_R", "U_R", "R_B",
            "A_UL", "A_UL", "F_R", "U_L", "F_L", "U_L", "F_R", "U_L", "U_L", "F_L",
        };

        formula_3_triple_R = new string[]
        {
            "A_UL", "F_R", "U_L", "F_L", "U_L", "F_R", "U_L", "U_L", "F_L", "A_UR",
            "A_UR", "R_F", "U_R", "R_B", "U_R", "R_F", "U_R", "U_R", "R_B", "A_UL",
        };

        formula_3_quadruple = new string[]
        {
            "Rm_F", "Rm_F", "U_R", "Rm_F", "Rm_F", "U_R",
            "U_R",  "Rm_F", "Rm_F", "U_R", "Rm_F", "Rm_F"
        };

        current_formula = null;

    }   // Start()


    private void Update()
    {
        if (StepsLeft > 0)
        {
            if (Cubemover.isAvailable())
            {
                string code = current_formula[current_formula.Length - StepsLeft];
                StepsLeft  -= 1;

                Cubemover.move(code);

                if (StepsLeft == 0)
                {
                    Cubemover.isLocked = false;
                    current_formula    = null;
                }
            }
        }

    }   // Update()


}   // class CubeFormulas
