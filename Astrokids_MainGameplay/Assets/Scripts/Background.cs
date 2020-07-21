using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float bgSpeed = 1f;

    private SpawnManager _spawnManager;
    private UIManager _uiManager;
    private Spaceship _spaceship;
    private Canvas _canvas;

    private int bg;

    [SerializeField]
    private Texture2D background1;

    [SerializeField]
    private Texture2D mainbackground;

    private bool newBackground = false;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        _spaceship = GameObject.Find("Spaceship").GetComponent<Spaceship>();
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        bg = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //updating background whenever space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && bg<2)
        {
            newBackground = true;
            bg++;
        }

        //finding the values of the components of the background object
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        if (bg==1)
        {
            //Debug.Log("First");
            mat.mainTexture = background1;

            //making the level inactive while on info screens
            _spawnManager._stopSpawning = true;
            //_uiManager.stopBar();
            _canvas.gameObject.SetActive(false);

            newBackground = false;
        }

        if (bg==2)
        {
            if (newBackground == true)
            {
                mat.mainTexture = mainbackground;

                //re-activating the level now that the main background is on
                _spawnManager._stopSpawning = false;
                //_uiManager.startBar();
                _spaceship._lives = 3;
                _canvas.gameObject.SetActive(true);
                this.gameObject.transform.position += new Vector3(0, 0, 9);

                newBackground = false;
            }

            //making the background perpetually offset, making it look side-scrolling
            offset.x += Time.deltaTime / bgSpeed;
            mat.mainTextureOffset = offset;


            
        }

    }
}
