using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{    
    [Header("Health")]
    [SerializeField]  private float initialHealth = 10f;
    [SerializeField]  private float maxHealth = 10f;
     private float life_num = 3f;
    [SerializeField]  private GameObject Health1;
    [SerializeField]  private GameObject Health2;
    [SerializeField]  private GameObject Health3;



    [Header("Infection")] 
    [SerializeField]  private  float initialInfection = 0;
    [SerializeField]  private  float maxInfection = 10f;

    [Header("Settings")] 
    [SerializeField] private bool destroyObject;
    [SerializeField] private bool isinfecting;
    [SerializeField] private bool ishurting = false;
  

    private Character character;
    private Character_Controller controller;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;



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
        if (CurrentInfection >= (maxInfection / 2))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
       if (Input.GetKeyDown(KeyCode.K)||isinfecting)
        {
            BeInfected(1);
        }


    }

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
	
       
       if (character != null)
        {
       
            CurrentHealth -= damage;
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);      

        }
      
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
 	 if (life_num  == 1)
        {
        

         Health3.SetActive(false);
      
         gameObject.SetActive(false);


        }
    }
    
    // Revive this game object    
    public void Revive()
    {
      
        gameObject.SetActive(true);
        if (life_num  == 2)
        {
          
            if (character != null)
        {
                print("life_num  == 2  ccccc");
                collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }
        
         Health2.SetActive(false);
      
    
        CurrentHealth = initialHealth;
        CurrentInfection = initialInfection;

     

        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);  
      life_num = life_num - 1; 

        }

        if (life_num  == 3)
        {
            
            if (character != null)
        {
          
                collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }
        
         Health1.SetActive(false);
      
      

        CurrentHealth = initialHealth;
        CurrentInfection = initialInfection;



        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentInfection, initialInfection, maxInfection);   
        life_num = life_num - 1;
        }
 	

	}   

    // If destroyObject is selected, we destroy this game object
   private void DestroyObject()
    {
        gameObject.SetActive(false);
    }    
}



