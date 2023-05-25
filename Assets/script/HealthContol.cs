using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContol : MonoBehaviour
{
    public int maxHealth = 4;
    [SerializeField] private int currentHealth;
    public GameObject cannonBall;
    public GameObject Cannon1;
    public GameObject Cannon2;
    public GameObject Cannon3;
    public GameObject Cannon4;
    public float CooldownDuration = 3f;
    public bool GameOver = false;
    

    private IEnumerator destruction(GameObject gameObject)
    {
        Debug.Log("waiting... " + Time.deltaTime);
        yield return new WaitForSeconds(CooldownDuration);
        Destroy(gameObject);
        Debug.Log("waiting... " + Time.deltaTime);
    }





    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CannonBall(Clone)")
        {
            currentHealth -= 1;
            

            if (currentHealth <= 0)
            {
                Die();
                gameObject.SetActive(false);
                StartCoroutine(destruction(Cannon4));
            }
            if (currentHealth == 1)
            {

                StartCoroutine(destruction(Cannon3));
            }
            if (currentHealth == 2)
            {

                StartCoroutine(destruction(Cannon2));
            }
            if (currentHealth == 3)
            {

                StartCoroutine(destruction(Cannon1));
            }
        }


    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add your custom logic for when the object dies or is destroyed
        Debug.Log("Object destroyed");
        GameOver = true;
        
    }
}
