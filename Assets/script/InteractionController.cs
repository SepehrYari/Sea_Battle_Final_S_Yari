using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interact();

}
public class InteractionController : MonoBehaviour
{

    public Transform InteractionSource;
    public float InteractionRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractionSource.position, InteractionSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractionRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }


    }
}
