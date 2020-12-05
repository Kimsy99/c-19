using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    
    [SerializeField] private GameObject npcSprite;
    [SerializeField] private Animator npcAnimator;
    
    public GameObject NPCSprite => npcSprite;
    public Animator NPCAnimator => npcAnimator;
}
