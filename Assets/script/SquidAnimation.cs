using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidAnimation : MonoBehaviour
{

    private Animator SquidAnimator;

    public float currentTime = 0f;
    public float startingTime = 10f;
    private bool AttackPhase = true;


    private IEnumerator Countdown5Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(15); //wait 5 seconds
            SquidAnimator.SetBool("Attack opportunity", true); //do thing
            yield return new WaitForSeconds(15); //wait 5 seconds

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SquidAnimator = GetComponent<Animator>();

    }



    void Update()
    {
       if (AttackPhase == true)
       {
            StartCoroutine(Countdown5Attack());
            
       }

    }

}
