using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the canvas to disable itself 
/// after being activated for a predefined time
/// </summary>

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [Header("Deactivate after:")]
    [SerializeField] private float second = 3f;

    private float timer = 0;

    private void Update()
    {
        if(canvas.activeInHierarchy)
        {
            LateDisable();
        }
    }

    private void OnEnable()
    {
        timer = Time.time + second;
    }

    private void LateDisable()
    {
        if(Time.time > timer)
        {
            canvas.SetActive(false);
        }
    }
}
