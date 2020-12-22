using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerController : MonoBehaviour
{
    [Header("Game Object to be set active on trigger")]
    [SerializeField] GameObject GameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.SetActive(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.SetActive(false);
        }
    }
}
