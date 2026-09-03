using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CanvasRaycastBlocker : MonoBehaviour
{
    private EventSystem      _EventSystem;
    private PointerEventData _PointerEventData;
    private GraphicRaycaster _Raycaster;



    private void Start()
    {
        _EventSystem = GetComponent<EventSystem>();
        _Raycaster   = GetComponent<GraphicRaycaster>();

    }   // Start()


    public bool IsHittingUI()
    {
        // Set up the new Pointer Event.
        _PointerEventData = new PointerEventData(_EventSystem);

        // Set the Pointer Event Position to that of the mouse position.
        _PointerEventData.position = Input.mousePosition;

        // Create a list of Raycast Results.
        List<RaycastResult> results = new();

        // Raycast using the Graphics Raycaster and mouse click position.
        _Raycaster.Raycast(_PointerEventData, results);

        return results.Count > 0;

    }   // isHittingUI()


}   // class CanvasRaycastBlocker
