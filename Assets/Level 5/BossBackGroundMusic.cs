using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackGroundMusic : MonoBehaviour
{
    private bool isPlay = false;
    private new BoxCollider2D collider2D;
    private Ken ken;
    
    void Awake()
    {
    
        collider2D = GetComponentInChildren<BoxCollider2D>();
        ken = GameObject.Find("Ken").GetComponent<Ken>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPlay) {
            AudioManager.Instance.Play(AudioEnum.BossTheme);
            isPlay = true;
        }

    }
    
}
