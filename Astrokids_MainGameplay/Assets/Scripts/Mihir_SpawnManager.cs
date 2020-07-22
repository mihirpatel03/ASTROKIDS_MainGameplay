using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mihir_SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float screenEdgeWidth = 8.5f;
    [SerializeField]
    private float screenEdgeHeight = 5.5f;

    [SerializeField]
    private GameObject _asteroidPrefab;

    //time between asteroid spawns
    private float spawnTime;

    //the rate that spawn time changes (happens every (value of spawn time) seconds)
    private float spawnIncrease;

    //value that spawn time cannot go below (so that there isn't infinite asteroids)
    private float maxSpawn;

    //y value of where the asteroid spawns
    float spawnY;

    [SerializeField]
    private GameObject _asteroidContainer;

    [SerializeField]
    public bool _stopSpawning;

    private Mihir_LevelManager _levelManager;




    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.Find("Mihir_LevelManager").GetComponent<Mihir_LevelManager>();
        StartCoroutine(SpawnRoutine());

        spawnY = screenEdgeHeight;
    }

    // Update is called once per frame
    void Update()
    {
        //setting difficuty of each level by manipulating spawn variables
        if (_levelManager.level==1)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .5f;
        }
        if (_levelManager.level == 2)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .5f;
        }
        if (_levelManager.level == 3)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .4f;
        }
        if (_levelManager.level == 4)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .4f;
        }
        if (_levelManager.level == 5)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .3f;
        }
        if (_levelManager.level == 6)
        {
            spawnTime = 1f;
            spawnIncrease = .05f;
            maxSpawn = .3f;
        }
        if (_levelManager.level == 7)
        {
            spawnTime = 1f;
            spawnIncrease = .1f;
            maxSpawn = .3f;
        }
        if (_levelManager.level == 8)
        {
            spawnTime = .5f;
            spawnIncrease = .2f;
            maxSpawn = 0.1f;
        }

    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            //float that represents the random y value where asteroids will spawn
            spawnY = Random.Range(-screenEdgeHeight, screenEdgeHeight);

            //storing the created asteroids within asteroid container
            GameObject newAsteroid = Instantiate(_asteroidPrefab, new Vector3(screenEdgeWidth+2, spawnY, 0), Quaternion.identity);
            newAsteroid.transform.parent = _asteroidContainer.transform;

            //decreasing the space between when asteroids spawn, makes the level more difficult
            if (spawnTime>maxSpawn)
            {
                spawnTime -= spawnIncrease;
            }

            //waiting a certain amount of time before repeating the loop, i.e. spacing out the spawns
            yield return new WaitForSeconds(spawnTime);
        }
    }


        

}
