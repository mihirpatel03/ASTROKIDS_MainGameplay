﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mihir_LevelManager : MonoBehaviour
{
    public static Mihir_LevelManager Instance;

    public float levelTime;

    private bool endLevel = false;

    private bool restart = false;

    public int level;






    public float barLeftEnd;
    public float barRightEnd;
    public float barSpeed;


    [SerializeField]
    public GameObject TravelledDistance;
    [SerializeField]
    private GameObject TotalDistance;
    private Renderer rend;




    // Start is called before the first frame update
    private void Start()
    {


    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //setting the level + leveltime for the first level
        level = 1;
        levelTime = 20f;

        //calculating the length and position of the bar
        float barScaleX = levelTime / 10;
        float barPosX = (.5f * barScaleX) - 6;



        TotalDistance.transform.localScale = new Vector3(barScaleX, TotalDistance.transform.localScale.y, TotalDistance.transform.localScale.z);
        TotalDistance.transform.position = new Vector3(barPosX, TotalDistance.transform.position.y, TotalDistance.transform.position.z);

        rend = TotalDistance.GetComponent<Renderer>();
        barLeftEnd = rend.bounds.min.x;
        barRightEnd = rend.bounds.max.x;

        //reseting the marker to the left end of the bar
        TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);

        TotalDistance.gameObject.SetActive(true);
        TravelledDistance.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Mihir_PlanetInfo")
        {
            //resetting the marker on the bar
            TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);

            if (level>=1)
            {
                level++;
            }

            SceneManager.LoadScene("Mihir_Game");
            Debug.Log("level " + level);

            //changing the leveltime based on which level is the current
            if (level == 2)
            {
                levelTime = 20f;
            }
            else if (level == 3)
            {
                levelTime = 20f;
            }
            else if (level == 4)
            {
                levelTime = 20f;
            }
            else if (level == 5)
            {
                levelTime = 30f;
            }
            else if (level == 6)
            {
                levelTime = 30f;
            }
            else if (level == 7)
            {
                levelTime = 35f;
            }
            else if (level == 8)
            {
                levelTime = 40f;
            }


            //re-calculating the bar
            float barScaleX = levelTime / 10;
            float barPosX = (.5f * barScaleX) - 6;

            TotalDistance.transform.localScale = new Vector3(barScaleX, TotalDistance.transform.localScale.y, TotalDistance.transform.localScale.z);
            TotalDistance.transform.position = new Vector3(barPosX, TotalDistance.transform.position.y, TotalDistance.transform.position.z);

            rend = TotalDistance.GetComponent<Renderer>();
            barLeftEnd = rend.bounds.min.x;
            barRightEnd = rend.bounds.max.x;

            TotalDistance.gameObject.SetActive(true);
            TravelledDistance.gameObject.SetActive(true);
        }


        if (endLevel == true)
        {
            SceneManager.LoadScene("Mihir_PlanetInfo");

            endLevel = false;

        }
        


        if (restart == true)
        {
            //restarting a level by loading the scene again and moving the marker
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            TravelledDistance.transform.position = new Vector3(barLeftEnd, TravelledDistance.transform.position.y, TravelledDistance.transform.position.z);
            restart = false;
        }


    }


    public void finishLevel()
    {
        if (level<8)
        {
            endLevel = true;
        }

    }

    public void restartLevel()
    {
        restart = true;

    }




}
