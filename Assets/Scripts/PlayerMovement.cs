using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public MapGenerator MapGenerator; 

    [SerializeField] public Animator animator;

    [SerializeField] public GameObject scoreLabel;
    [SerializeField] public GameObject camera;
    private GameObject chicken;

    private int playerResult;

    // Start is called before the first frame update
    void Start()
    {
        chicken = transform.Find("Chicken").gameObject;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.transform.gameObject.tag=="star1") Debug.Log("carrot got");
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "star")
        {
            Destroy(other.gameObject);
            playerResult += 10;
            scoreLabel.GetComponent<Text>().text = playerResult.ToString(); ;

        }

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

            scoreLabel.GetComponent<Text>().text=playerResult.ToString(); ;

            chicken.transform.Rotate(0,0,0);

            playerResult++;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            DoMove(new Vector3(0,0, 1.001f));

            int isRight = chicken.transform.rotation.y == -90 ? 0 : -90;
            chicken.transform.Rotate(new Vector3(0,1,0), isRight);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DoMove(new Vector3(0, 0, -1.001f));

            int isLeft = chicken.transform.rotation.y == 90 ? 0 : 90;
            chicken.transform.Rotate(new Vector3(0, 1, 0), isLeft);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DoMove(new Vector3(-1.001f, 0, 0));

            int isBack = chicken.transform.rotation.y == 180 ? 0 : 180;
            chicken.transform.Rotate(new Vector3(0, 1, 0), isBack);
        }

        CheckDeath();
    }

    private void CheckDeath()
    {
        if(transform.position.y < -10)
        {
            Time.timeScale = 0;

            FileStream s = new FileStream(Application.dataPath+"/ress.json", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(s);

            var r = new GameResult(DateTime.Now.ToString(), playerResult.ToString());

            string result = JsonUtility.ToJson(r, true);
            sw.WriteLine(result);

            sw.Close();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }

    void DoMove(Vector3 world)
    {
        animator.SetTrigger("Space");
        transform.position = (transform.position + world);

        MapGenerator.SpawnMap(false, transform.position);
    }
}
