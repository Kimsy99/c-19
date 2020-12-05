using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SingleShotWeapon : MonoBehaviour
{
    [SerializeField] private Vector3 projectileSpawnPosition;
    [SerializeField] private Vector3 projectileSpread;

    // Controls the position of our projectile spawn
    public Vector3 ProjectileSpawnPosition { get; set; }

    private Vector3 projectileSpawnValue;
    private Vector3 randomProjectileSpread;

    //character movement
    private SpriteFlippable2D characterMovingDirection;

    // Start is called before the first frame update
    protected void Start()
    {
        projectileSpawnValue = projectileSpawnPosition;
        projectileSpawnValue.y = -projectileSpawnPosition.y;

        characterMovingDirection = GetComponentInParent<SpriteFlippable2D>();
    }

    /*    REMOVE this Update method because we are inheriting the Weapon class & use Awake method
    protected override void Update ()
    {
	  base.Update();
	}
	*/

    // Calculates the position where our projectile is going to be fired
    private void EvaluateProjectileSpawnPosition()
    {
        if (characterMovingDirection.Direction == 0)
        {
            // Right side
            ProjectileSpawnPosition = transform.position + transform.rotation * projectileSpawnPosition;
        }
        else
        {
            // Left side
            ProjectileSpawnPosition = transform.position - transform.rotation * projectileSpawnValue;
        }
    }

    private void OnDrawGizmosSelected()
    {
        EvaluateProjectileSpawnPosition();

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ProjectileSpawnPosition, 0.1f);
    }
}

