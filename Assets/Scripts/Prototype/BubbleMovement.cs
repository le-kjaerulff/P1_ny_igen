using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    Animator BubbleMovementController;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        
        BubbleMovementController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            BubbleMovementController.SetBool("bubbleVisible", true);
        }
        else
        {
            BubbleMovementController.SetBool("bubbleVisible", false);
        }
    }

}
