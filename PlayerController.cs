using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float reloadTime;
    public float currentReloadTime;
    public GameObject bulletPrefab;
    public Transform gunPoint;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
        Move();
        Shoot();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Vector3 move = new Vector3(v, 0, -h);
        rb.MovePosition(transform.position + move);
    }
    void Rotate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)){
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    void Shoot()
    {
        if (currentReloadTime > reloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
                currentReloadTime = 0;
            }
        }
        else
        {
            currentReloadTime += Time.deltaTime;
        }
    }
}