using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public MapGenerator MapGenerator; 

    [SerializeField] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "star") Debug.Log("carrot got");
    }

    // Update is called once per frame
    void Update()
    {
        float newZ = 0;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetTrigger("Space");
            if (transform.position.z % 1 != 0) newZ = Mathf.Round(transform.position.z) - transform.position.z;
            DoMove(new Vector3(1.001f, 0, newZ));
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            DoMove(new Vector3(0,0, 1.001f));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DoMove(new Vector3(0, 0, -1.001f));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DoMove(new Vector3(-1.001f, 0, 0));
        }
    }

    void DoMove(Vector3 world)
    {
        animator.SetTrigger("Space");
        transform.position = (transform.position + world);

        MapGenerator.SpawnMap(false, transform.position);
    }
}