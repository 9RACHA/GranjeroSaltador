using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour {
    Animator animator;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
        }

        if(rb.velocity.y < 0) {
            animator.ResetTrigger("Jump_trig");            
            animator.SetBool("Jump_b", true);
        }

        if(IsGrounded() && animator.GetBool("Jump_b")) {
            animator.SetBool("Jump_b", false);
        }
        
    }
    


    void OnCollisionEnter(Collision other) {
        Debug.Log("FarmerController.OnCollisionEnter");
        if(other.gameObject.CompareTag("Barrier")) {
            GameManager.instance.GameOver();

            animator.SetInteger("DeathType_int", Random.Range(1, 3));
            animator.SetBool("Death_b", true);
            
        }
    }

    private bool IsGrounded() {
        return transform.position.y < 0.05f;
    }
}
