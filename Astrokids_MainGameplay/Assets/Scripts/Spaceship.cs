using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    public float verticalInput;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = .35f;
    [SerializeField]
    private float _canFire = -1f;

    public int _lives = 3;

    [SerializeField]
    private float screenEdge = 5.5f;


    [SerializeField]
    private GameObject _trailPrefab;
    [SerializeField]
    private GameObject _trailContainer;
    private float trailOffset;

    private SpawnManager _spawnManager;

    [SerializeField]
    private float rotationAngle = 20;


    [SerializeField]
    private AudioSource laserSound;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(-6f, 0, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        laserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        CalculateMovement();
        drawTrail();

        //cooldown between laser firing
        if (Time.time>_canFire && _spawnManager._stopSpawning==false)
        {
            _canFire = Time.time + _fireRate;
            Shoot();
        }
    }

    //Calculating change in player's position
    private void CalculateMovement()
    {
        //makes the spaceship come from the other side of the screen
        if (transform.position.y > screenEdge)
        {
            transform.position = new Vector3(transform.position.x, - screenEdge, 0);
        }
        if (transform.position.y < -screenEdge)
        {
            transform.position = new Vector3(transform.position.x, screenEdge, 0);
        }
        float verticalInput = Input.GetAxis("Vertical");

        //rotating the spaceship based on the direction of the input
        if (verticalInput>0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);
            transform.Translate(new Vector3(Mathf.Sin(Mathf.PI/9), Mathf.Cos(Mathf.PI / 9), 0) * _speed * Time.deltaTime * verticalInput);
        }
        if (verticalInput<0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, - rotationAngle);
            transform.Translate(new Vector3(Mathf.Sin(Mathf.PI / 9), -Mathf.Cos(Mathf.PI / 9), 0) * _speed * Time.deltaTime * -verticalInput);
        }
        if (verticalInput==0)
        {
            transform.localRotation = Quaternion.identity;
        }

    }

    //Shoot lasers
    private void Shoot()
    {
        //laserSound.Play();
        Instantiate(_laserPrefab, transform.position + new Vector3(1.5f, 0, 0), Quaternion.Euler(0f, 0f, -90f)) ;
    }

    //drawing the ships trail
    private void drawTrail()
    {
        

        if (transform.rotation.z>0)
        {
            trailOffset = -.35f;
        }
        if (transform.rotation.z < 0)
        {
            trailOffset = .35f;
        }
        if (transform.rotation.z == 0)
        {
            trailOffset = 0;
        }

        //creating trails and storing them in trail container
        GameObject newTrail = Instantiate(_trailPrefab, transform.position + new Vector3(-1f, trailOffset, 0), Quaternion.identity);
        newTrail.transform.parent = _trailContainer.transform;

    }

    public void Damage()
    {
        if (_lives>0)
        {
            _lives--;
        }


        if (_lives==0)
        {
            //telling asteroids to stop spawning once the player is dead.
            _spawnManager._stopSpawning=true;
        }
    }




}
