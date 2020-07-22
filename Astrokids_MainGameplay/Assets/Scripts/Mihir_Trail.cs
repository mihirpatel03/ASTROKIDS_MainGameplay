using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mihir_Trail : MonoBehaviour
{

    [SerializeField]
    private float _speed = 8f;

    [SerializeField]
    private float screenEdge = 8.5f;

    [SerializeField]
    private float scaleChange = -.05f;



    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);

        //shrinking the size of the trail
        transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);

        //if the trail leaves the screen or gets too small
        if (transform.position.x < -screenEdge || transform.localScale.x<.01)
        {
            Destroy(this.gameObject);
        }
    }
}
