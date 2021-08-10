using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    public float speed = 10f;
    protected Rigidbody rb;
    void Awake()
    {

        rb = GetComponent<Rigidbody>(); 
    }


}
