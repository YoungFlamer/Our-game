using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed;
    public GameObject gun;
    public GameObject bullet;
    public Transform gunPoint;
    public float reloadTime;
    private float currentReloadTime;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gun = GameObject.FindWithTag("Gun");
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        RotateGun();
        Shoot();
        MoveCamera();
	}

    void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + new Vector2(h, v));
    }

    void RotateGun()
    {
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gun.transform.position = transform.position;
        Vector2 fignya = mp - rb.position;
        float angle = Mathf.Atan2(fignya.y, fignya.x) * Mathf.Rad2Deg;
        gun.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    void Shoot()
    {
        if (currentReloadTime > reloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject r = Instantiate(bullet, gunPoint.position, gunPoint.rotation) as GameObject;
                r.GetComponent<Rigidbody2D>().AddForce(gunPoint.right * 20f, ForceMode2D.Impulse);
                currentReloadTime = 0;
            }
        }
        else
        {
            currentReloadTime += Time.deltaTime;
        }
    }
    void OnDestroy()
    {
        Destroy(gun);
    }
    void MoveCamera()
    {
        GameObject cam = Camera.main.gameObject;
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }
}
