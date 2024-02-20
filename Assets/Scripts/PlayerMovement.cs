using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            animator.SetTrigger("Space");
            if(transform.position.z % 1 == 0) transform.Translate(new Vector3(1, 0, 0));
        }
    }
}
