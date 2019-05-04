using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
