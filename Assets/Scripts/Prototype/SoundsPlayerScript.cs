using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundsPlayerScript : MonoBehaviour
{
    Playercontrols controls;
    int selectedObject;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClipArray;
    


    private void Awake()
    {
        controls = new Playercontrols();

        controls.InGame.TouchObjectA.performed += context => SelectObjectA();
        controls.InGame.TouchObjectB.performed += context => SelectObjectB();
        controls.InGame.TouchObjectC.performed += context => SelectObjectC();
    }

    void SelectObjectA()
    {
        Debug.Log("SoundsPlayer: Object A was selected");
        selectedObject = 0;

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClipArray[selectedObject]);
        }
    }

    void SelectObjectB()
    {
        Debug.Log("SoundsPlayer: Object B was selected");
        selectedObject = 1;

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClipArray[selectedObject]);
        }
    }
    void SelectObjectC()
    {
        Debug.Log("SoundsPlayer: Object C was selected");
        selectedObject = 2;

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClipArray[selectedObject]);
        }
    }

    private void Start()
    {
        Debug.Log("SoundsPlayer: Now running");
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
