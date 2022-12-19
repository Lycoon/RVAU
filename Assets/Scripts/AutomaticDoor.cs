using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    SphereCollider trigger;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.AddComponent<SphereCollider>();
        trigger.isTrigger = true;
        trigger.radius = 2.0f;

        animator = GetComponent<Animator>();
        animator.SetBool("character_nearby", false);
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            animator.SetBool("character_nearby", true);
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
            animator.SetBool("character_nearby", false);
    }
}
