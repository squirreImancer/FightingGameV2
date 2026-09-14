using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hpmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float health, maxhealth;
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("ded");
            SceneManager.LoadScene(0);

        } 
    }
}
