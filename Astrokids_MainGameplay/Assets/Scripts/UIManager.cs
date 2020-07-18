using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private float screenEdgeHeight = 5.5f;

    private Spaceship _spaceship;
    private LevelManager _levelManager;
    private SpawnManager _spawnManager;


    [SerializeField]
    private Text _question1Text;
    [SerializeField]
    private Text _question2Text;

    [SerializeField]
    private Text _answerAText;
    [SerializeField]
    private Text _answerBText;
    [SerializeField]
    private Text _answerCText;
    [SerializeField]
    public int answer = 1;

    [SerializeField]
    private Text _livesText;
    [SerializeField]
    private Text _gameOverText;

    [SerializeField]
    private float _textSpeed = 3f;


    [SerializeField]
    private float dividerSpeed;
    [SerializeField]
    private GameObject divider1;
    [SerializeField]
    private GameObject divider2;
    [SerializeField]
    private float dividerX;
    [SerializeField]
    private float dividerY1;
    [SerializeField]
    private float dividerY2;




    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _spaceship = GameObject.Find("Spaceship").GetComponent<Spaceship>();


        _livesText.text = "Lives: " + 3;

        _gameOverText.gameObject.SetActive(false);

        divider1.transform.position = new Vector3(dividerX, dividerY1, 0);
        divider2.transform.position = new Vector3(dividerX, dividerY2, 0);

    }

    // Update is called once per frame
    void Update()
    {


        _livesText.text = "Lives: " + _spaceship._lives;

        //if player dies, say game over and restart level
        if (_spaceship._lives==0)
        {
            _gameOverText.gameObject.SetActive(true);
            StartCoroutine(restartLevel());
        }

        //moves the bar as long as the spaceship is not dead and not at destination
        if (_levelManager.TravelledDistance.transform.position.x < _levelManager.barRightEnd && _spawnManager._stopSpawning==false)
        {

            _levelManager.barSpeed = ((_levelManager.barRightEnd - _levelManager.barLeftEnd) / _levelManager.levelTime) * Time.deltaTime;
            _levelManager.TravelledDistance.transform.position += new Vector3(_levelManager.barSpeed, 0, 0);
        }

        //when the player reaches the end, stop spawning, and start moving the questions onto the screen
        if (_levelManager.TravelledDistance.transform.position.x >= _levelManager.barRightEnd -.01f)
        {
            _spawnManager._stopSpawning=true;

            //parent object that moves all question and answer objects
            transform.Translate(Vector3.left * Time.deltaTime * _textSpeed);

            divider1.transform.Translate(Vector3.left * Time.deltaTime * dividerSpeed);
            divider2.transform.Translate(Vector3.left * Time.deltaTime * dividerSpeed);

        }

        //once the spaceship has reached the answer section
        if (_spaceship.transform.position.x >= _answerAText.transform.position.x)
        {
            //if the spaceship is within the same divider that the answer is in then
            //finish the level and move the x of answerA so that the initial condition is no longer met.
            if (_spaceship.transform.position.y > divider1.transform.position.y / 6 && answer == 1)
            {
                _levelManager.finishLevel();
                _answerAText.transform.position += new Vector3(1000, 0, 0);
            }
            else if (_spaceship.transform.position.y < divider1.transform.position.y && _spaceship.transform.position.y > divider2.transform.position.y && answer == 2)
            {
                _levelManager.finishLevel();
                _answerAText.transform.position += new Vector3(1000, 0, 0);
            }
            else if (_spaceship.transform.position.y < divider2.transform.position.y && answer == 3)
            {
                _levelManager.finishLevel();
                 _answerAText.transform.position += new Vector3(1000, 0, 0);
            }
            else
            {
                //if incorrect answer, game over
                _gameOverText.gameObject.SetActive(true);
                StartCoroutine(restartLevel());
            }
        }

        //based on each level, what the questions and answers are.
        if (_levelManager.level == 1)
        {
            _question1Text.text = "How hot does Mercury's surface";
            _question2Text.text = "become during the day?";

            _answerAText.text = "430°C";
            _answerBText.text = "200°C";
            _answerCText.text = "340°C";

            answer = 1;
        }
        else if (_levelManager.level == 2)
        {
            _question1Text.text = "Where does Venus rank among the";
            _question2Text.text = "brightest objects in the night sky?";

            _answerAText.text = "1st";
            _answerBText.text = "2nd";
            _answerCText.text = "3rd";

            answer = 2;
        }
        else if (_levelManager.level == 3)
        {
            _question1Text.text = "Which Earth-like phenomenon";
            _question2Text.text = "also occurs on the Moon?";

            _answerAText.text = "Earthquakes";
            _answerBText.text = "Tornadoes";
            _answerCText.text = "Mudslides";

            answer = 1;
        }
        else if (_levelManager.level == 4)
        {
            _question1Text.text = "Mars is about the same size";
            _question2Text.text = "as which other planet?";

            _answerAText.text = "Saturn";
            _answerBText.text = "Mercury";
            _answerCText.text = "Earth";

            answer = 3;
        }
        else if (_levelManager.level == 5)
        {
            _question1Text.text = "What color is the large";
            _question2Text.text = "spot on Jupiter?";

            _answerAText.text = "brown";
            _answerBText.text = "red";
            _answerCText.text = "green";

            answer = 2;
        }
        else if (_levelManager.level == 6)
        {
            _question1Text.text = "Which planet has more confirmed";
            _question2Text.text = "moons than Saturn?";

            _answerAText.text = "Jupiter";
            _answerBText.text = "the Earth";
            _answerCText.text = "None";

            answer = 3;
        }
        else if (_levelManager.level == 7)
        {
            _question1Text.text = "Why does Uranus spin up and down,";
            _question2Text.text = "not side to side?";

            _answerAText.text = "It collided with another large object long ago";
            _answerBText.text = "It is extremely cold";
            _answerCText.text = "It doesn't feel the Sun's gravity because it is so far away";

            answer = 1;
        }
        else if (_levelManager.level == 8)
        {
            _question1Text.text = "How long would it take a";
            _question2Text.text = "human to freeze on Neptune?";

            _answerAText.text = "1 second";
            _answerBText.text = "1 minute";
            _answerCText.text = "10 seconds";

            answer = 1;
        }




    }
    IEnumerator restartLevel()
    {
            //function that creates a delay before restarting the level
            //(so that the player can actually see the game over text)
            yield return new WaitForSeconds(2f);
            _levelManager.restartLevel();

    }


}
