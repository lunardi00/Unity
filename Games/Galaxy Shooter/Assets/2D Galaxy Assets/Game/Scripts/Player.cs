using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public bool canTripleShoot = false;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _nextFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;


    void Start()
    {
        //current position = new position
        transform.position = new Vector3(0, 0, 0);
    }


    void Update()
    {
        Movement();

        //if space key is presses
        //spawn laser at player's position

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))     
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time > _nextFire)
        {
            if (canTripleShoot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                
            }

            _nextFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        //player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        //boundary on y
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        }

        //boundary on x
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }
    }
}

