using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{

    Playercontrols controls;
    Animator CatMovementController;

    bool taskSolved = false;

    private void Awake()
    {        
        controls = new Playercontrols();
        CatMovementController = GetComponent<Animator>();

        controls.InGame.TouchObjectC.performed += context => SelectObjectC();
    }

    void SelectObjectC()
    {
        Debug.Log("MovementController: Object C was selected");
        if (taskSolved == false)
        {
            CatMovementController.SetBool("catFound", true);
        }
        taskSolved = true;
    }
    private void OnEnable()
    {
        controls.InGame.Enable();
    }

    private void OnDisable()
    {
        controls.InGame.Disable();
    }



}
