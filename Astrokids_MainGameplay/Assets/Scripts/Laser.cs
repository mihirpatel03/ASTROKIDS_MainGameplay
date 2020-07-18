using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15;

    [SerializeField]
    private float screenEdge = 8.5f;

    private Spaceship _spaceship;

    private Vector3 movement;
    // Start is called before the first frame update
    private void Start()
    {
        _spaceship = GameObject.Find("Spaceship").GetComponent<Spaceship>();

        /*if (_spaceship.transform.rotation.z < 0)
        {
            movement = new Vector3(Mathf.Sin(Mathf.PI / 9), Mathf.Cos(Mathf.PI / 9), 0);
        }
        if (_spaceship.transform.rotation.z > 0)
        {
            movement = new Vector3(-Mathf.Sin(Mathf.PI / 9), Mathf.Cos(Mathf.PI / 9), 0);
        }
        if (_spaceship.transform.rotation.z == 0)
        {*/
            movement = new Vector3(0, 1, 0);
        //}
    }

    // Update is called once per frame
    private void Update()
    {

        transform.Translate(movement * Time.deltaTime * _speed);

        if (transform.position.x > screenEdge || transform.position.x<-screenEdge)
        {
            Destroy(this.gameObject);
        }
    }
}
