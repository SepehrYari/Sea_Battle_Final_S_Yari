using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlatform : MonoBehaviour
{
    Animator Animator;
    public float delayTime = 2f;

    


    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator.SetBool("triggered", true);

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator.SetBool("triggered", false);

        }
    }



}
