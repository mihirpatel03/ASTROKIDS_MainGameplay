using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mihir_Background : MonoBehaviour
{
    [SerializeField]
    private float bgSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("Mihir_Game") == SceneManager.GetActiveScene())
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;

            //making the background perpetually offset, making it look side-scrolling
            offset.x += Time.deltaTime / bgSpeed;
            mat.mainTextureOffset = offset;
        }


        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetSceneByName("Mihir_PlanetInfo") == SceneManager.GetActiveScene())
        {
            Debug.Log("here");
            SceneManager.LoadScene("Mihir_Game");
        }


        

    }
}
