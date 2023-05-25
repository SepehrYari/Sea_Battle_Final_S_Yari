using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    public int damageAmount;
    public bool IsHit = false;

    public void SetTarget(GameObject enemy)
    {
        target = enemy;
    }

    public void SetDamageAmount(int damage)
    {
        damageAmount = damage;
    }

    private void Update()
    {
        if (target != null)
        {
            // Move the projectile toward the target enemy
            float speed = 60f;
            Vector3 direction = transform.TransformDirection(Vector3.forward * speed);
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("enemy was hit!");
            IsHit = true;
            Destroy(gameObject);
        }
        else
        {
            IsHit = false;
        }
    }
}
