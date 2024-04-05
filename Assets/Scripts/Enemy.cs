using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed = 10;
    private BoundsChecker boundsChecker;

    void Awake()
    {
        boundsChecker = GetComponent<BoundsChecker>();
    }
    public Vector3 position
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }
    public virtual void Move()
    {
        Vector3 tempPosition = position;
        tempPosition.y -= speed * Time.deltaTime;
        position = tempPosition;
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        Move();
        if (boundsChecker != null && boundsChecker.down)
        {
          Destroy(gameObject);    
            
        }

    }
}
