using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurn : MonoBehaviour
{
    public GameObject enemy;
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    public GameObject ExplosionPrefab;
    public int damageAmount = 4;
    public float CooldownDuration = 5f;
    private bool isInsideTrigger = false;

    private bool hasShot = false;

    // this is for the Trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = true;
        }
    }

    // this is for the Trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = false;
        }
    }

    private IEnumerator Countdown5Attack()
    {

        hasShot = true;
        yield return new WaitForSeconds(CooldownDuration);
        hasShot = false;


    }

    private void Update()
    {
        if (enemy != null)
        {
            if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
            {
                
                // Check if it's the cannon's turn to shoot
                if (!hasShot)
                {
                    // Shoot at the enemy
                    Shoot();
                    hasShot = true;
                    StartCoroutine(Countdown5Attack());
                }
            }
        }
    }
    private void Shoot()
    {
        // Instantiate the projectile at the shooting point
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Instantiate(ExplosionPrefab, shootingPoint.position, shootingPoint.rotation);
        Projectile projectileController = projectile.GetComponent<Projectile>();
        

        // Set the damage amount and target enemy
        projectileController.SetDamageAmount(damageAmount);
        projectileController.SetTarget(enemy);

    }

    public void ResetTurn()
    {
        hasShot = false;
    }
}
