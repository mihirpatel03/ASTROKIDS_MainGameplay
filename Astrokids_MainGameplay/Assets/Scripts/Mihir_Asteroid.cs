using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mihir_Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private float screenEdgeHeight = 5.5f;
    [SerializeField]
    private float screenEdgeWidth = 8.5f;

    private Mihir_Spaceship _spaceship;




    // Start is called before the first frame update
    private void Start()
    {
        //transform.position = new Vector3(0, screenEdgeHeight, 0);

        _spaceship = GameObject.Find("Mihir_Spaceship").GetComponent<Mihir_Spaceship>();

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);

        if (transform.position.x < -screenEdgeWidth - 1)
        {
            Destroy(this.gameObject);
                       
        }




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Spaceship")
        {
            _spaceship.Damage();
            Destroy(this.gameObject);
        }

        if (other.tag=="Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }


}
