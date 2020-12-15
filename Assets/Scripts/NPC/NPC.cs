using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject npcSprite = null;
    [SerializeField] private Animator npcAnimator = null;
    
    public GameObject NPCSprite => npcSprite;
    public Animator NPCAnimator => npcAnimator;
}
