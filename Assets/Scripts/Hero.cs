using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero solo;
    [Header("Set in Inspector")]
    public float speed = 30;

    void Awake()
    {
        if(solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Hero.Awake()");
        }
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        position.x += xAxis * speed * Time.deltaTime;
        position.y += yAxis * speed * Time.deltaTime;
        transform.position = position;


        transform.rotation = Quaternion.Euler(yAxis * 25, xAxis * -25, 0);




    }
}
