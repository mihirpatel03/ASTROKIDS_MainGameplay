using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float bgSpeed = 1f;

    private LevelManager _levelManager;

    private int bg;

    [SerializeField]
    private Material background1;

    [SerializeField]
    private Material mainbackground;

    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        bg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //updating background whenever space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && bg<2)
        {
            Debug.Log("levelChanged");
            bg++;
        }

        //finding the values of the components of the background object
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        if (bg==1)
        {
            Debug.Log("First");
            mat = mainbackground;
        }

        if (bg==2)
        {
            Debug.Log("Second");
            mat = mainbackground;

            //making the background perpetually offset, making it look side-scrolling\
            offset.x += Time.deltaTime / bgSpeed;
            mat.mainTextureOffset = offset;
        }

    }
}
