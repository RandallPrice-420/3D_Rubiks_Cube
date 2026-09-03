using UnityEngine;


public class CtrlKeyboard : MonoBehaviour
{
    public ControlMode Cmode;
    public CubeMover   Cubemover;
    public Transform   CustomAlgoBble;



    private Animator CustomAlgoBbleAnim;



    private void Start()
    {
        CustomAlgoBbleAnim = CustomAlgoBble.GetComponent<Animator>();
    }

    private void Update()
    {
        if ((Cmode.Mode == 1) && (!CustomAlgoBbleAnim.GetBool("isOpen")))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.I)) 
                {
                    Cubemover.Move("U_L");
                }
                else if (Input.GetKey(KeyCode.Comma))
                {
                    Cubemover.Move("D_L");
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    Cubemover.Move("Um_L");
                }
                else
                {
                    Cubemover.Move("A_UL");
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.I)) 
                {
                    Cubemover.Move("U_R");
                }
                else if (Input.GetKey(KeyCode.Comma)) 
                {
                    Cubemover.Move("D_R");
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    Cubemover.Move("Um_R");
                }
                else
                {
                    Cubemover.Move("A_UR");
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.J))
                {
                    Cubemover.Move("L_B");
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    Cubemover.Move("R_B");
                }
                else if (Input.GetKey(KeyCode.K)) 
                {
                    Cubemover.Move("Rm_B");
                }
                else
                {
                    Cubemover.Move("A_RB");
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.J))
                {
                    Cubemover.Move("L_F");
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    Cubemover.Move("R_F");
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    Cubemover.Move("Rm_F");
                }
                else
                {
                    Cubemover.Move("A_RF");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Input.GetKey(KeyCode.I))
                {
                    Cubemover.Move("B_L");
                }
                else if (Input.GetKey(KeyCode.Comma))
                {
                    Cubemover.Move("F_L");
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    Cubemover.Move("Fm_L");
                }
                else
                {
                    Cubemover.Move("A_FL");
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (Input.GetKey(KeyCode.I)) 
                {
                    Cubemover.Move("B_R");
                }
                else if (Input.GetKey(KeyCode.Comma))
                {
                    Cubemover.Move("F_R");
                }
                else if (Input.GetKey(KeyCode.K))
                {
                    Cubemover.Move("Fm_R");
                }
                else
                {
                    Cubemover.Move("A_FR");
                }
            }
        }

    }   // Update()


}   // class CtrlKeyboard
