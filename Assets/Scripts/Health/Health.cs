using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{    
    [Header("Health")]
    [SerializeField]  private float initialHealth = 10f;
    [SerializeField]  private float maxHealth = 10f;

    [SerializeField]  private GameObject Health1;
    [SerializeField]  private GameObject Health2;
    [SerializeField]  private GameObject Health3;



    [Header("Infection")] 
    [SerializeField]  private  float initialInfection = 0;
    [SerializeField]  private  float maxInfection = 10f;

    [Header("Settings")] 
    [SerializeField] private bool destroyObject;

    private Character character;
    private Character_Controller controller;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;

    private bool InfectionFull;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    // Returns the current health of this character
    public float CurrentInfection { get; set; }
    
    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<Character_Controller>();
        collider2D = GetComponent<Collider2D>();        
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        CurrentHealth = initialHealth;
        CurrentInfection = initialInfection;
       UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
      if (Input.GetKeyDown(KeyCode.K))
        {
            BeInfected(1);
        }


    }

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }
       if (!InfectionFull && character != null)
        {
            CurrentHealth -= damage;
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);      

            if ( CurrentInfection >= maxInfection)
            {
                InfectionFull = true;
            
            }
            return;
        }
       CurrentHealth = CurrentHealth - damage;
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);      

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Kills the game object

public void BeInfected(int infect)
    {
     if (CurrentInfection >= maxInfection)
        {
            return;
        }


        CurrentInfection += infect;
       UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);      
      if (CurrentInfection >= maxInfection )
        {
            
            Die();
        }
       
    }

    // infects the game object

    private void Die()
{
        if (character != null)
        {
            collider2D.enabled = false;
            spriteRenderer.enabled = false;

            character.enabled = false;
            controller.enabled = false;
        }

        if (destroyObject)
        {
            DestroyObject();
        }
    }
    
    // Revive this game object    
    public void Revive()
    {
        if (character != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }

        gameObject.SetActive(true);

        CurrentHealth = initialHealth;
        CurrentInfection = initialInfection;

        InfectionFull = false;

        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);   

	}   

    // If destroyObject is selected, we destroy this game object
   private void DestroyObject()
    {
        gameObject.SetActive(false);
    }    
}



