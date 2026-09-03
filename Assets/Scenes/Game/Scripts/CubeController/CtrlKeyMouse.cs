using UnityEngine;


public class CtrlKeyMouse : MonoBehaviour
{
    public ControlMode          Cmode;
    public CubeMover            Cubemover;
    public CanvasRaycastBlocker Crb;
    public Transform            CustomAlgoBble;



    private Animator CustomAlgoBbleAnim;



    private void Start()
    {
        CustomAlgoBbleAnim = CustomAlgoBble.GetComponent<Animator>();

    }   // Start()


    private void Update()
    {
        if (Cmode.Mode == 0 && !CustomAlgoBbleAnim.GetBool("isOpen")) {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0) && !Crb.IsHittingUI()) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) {
                    switch (hit.transform.name) {
                        case "Arrow_F1":
                            Cubemover.Move("L_B");
                            break;
                        case "Arrow_F2":
                            Cubemover.Move("Rm_B");
                            break;
                        case "Arrow_F3":
                            Cubemover.Move("R_B");
                            break;
                        case "Arrow_F4":
                            Cubemover.Move("Um_L");
                            break;
                        case "Arrow_F50":
                            Cubemover.Move("A_UL");
                            break;
                        case "Arrow_F51":
                            Cubemover.Move("A_UR");
                            break;
                        case "Arrow_F6":
                            Cubemover.Move("Um_R");
                            break;
                        case "Arrow_F7":
                            Cubemover.Move("L_F");
                            break;
                        case "Arrow_F8":
                            Cubemover.Move("Rm_F");
                            break;
                        case "Arrow_F9":
                            Cubemover.Move("R_F");
                            break;
                        case "Arrow_R1":
                            Cubemover.Move("D_L");
                            break;
                        case "Arrow_R2":
                            Cubemover.Move("Um_L");
                            break;
                        case "Arrow_R3":
                            Cubemover.Move("U_L");
                            break;
                        case "Arrow_R4":
                            Cubemover.Move("Fm_R");
                            break;
                        case "Arrow_R50":
                            Cubemover.Move("A_FR");
                            break;
                        case "Arrow_R51":
                            Cubemover.Move("A_FL");
                            break;
                        case "Arrow_R6":
                            Cubemover.Move("Fm_L");
                            break;
                        case "Arrow_R7":
                            Cubemover.Move("D_R");
                            break;
                        case "Arrow_R8":
                            Cubemover.Move("Um_R");
                            break;
                        case "Arrow_R9":
                            Cubemover.Move("U_R");
                            break;
                        case "Arrow_U1":
                            Cubemover.Move("B_R");
                            break;
                        case "Arrow_U2":
                            Cubemover.Move("Fm_R");
                            break;
                        case "Arrow_U3":
                            Cubemover.Move("F_R");
                            break;
                        case "Arrow_U4":
                            Cubemover.Move("Rm_B");
                            break;
                        case "Arrow_U50":
                            Cubemover.Move("A_RB");
                            break;
                        case "Arrow_U51":
                            Cubemover.Move("A_RF");
                            break;
                        case "Arrow_U6":
                            Cubemover.Move("Rm_F");
                            break;
                        case "Arrow_U7":
                            Cubemover.Move("B_L");
                            break;
                        case "Arrow_U8":
                            Cubemover.Move("Fm_L");
                            break;
                        case "Arrow_U9":
                            Cubemover.Move("F_L");
                            break;
                    }
                }
            } else if (Input.GetKeyDown(KeyCode.A)) {
                Cubemover.Move("A_UL");
            } else if (Input.GetKeyDown(KeyCode.D)) {
                Cubemover.Move("A_UR");
            } else if (Input.GetKeyDown(KeyCode.W)) {
                Cubemover.Move("A_RB");
            } else if (Input.GetKeyDown(KeyCode.S)) {
                Cubemover.Move("A_RF");
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                Cubemover.Move("A_FL");
            } else if (Input.GetKeyDown(KeyCode.E)) {
                Cubemover.Move("A_FR");
            }
        }

    }   // Update()


}   // class CtrlKeyMouse

