using UnityEngine;
using System.Collections;
[System.Serializable]
[RequireComponent(typeof(AudioSource))]
public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;
    private Rigidbody rb;
    private AudioSource audio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    void Update()
    {

        if(Input.GetButton("Fire1")&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        } 
            
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        Vector3 position = new Vector3(
            Mathf.Clamp(rb.position.x ,boundary.xmin, boundary.xmax), 0.0f, Mathf.Clamp(rb.position.z,boundary.zmin,boundary.zmax)
    );
        rb.position = position;
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
    }
