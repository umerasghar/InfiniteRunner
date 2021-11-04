using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;
    public ObstacleManager[] obstacleManager;
    public GameComponents gameComponents;

    public static bool GameStart;
    public static float SpeedFactor, gemCount;
    public static int currentHighScore, scoreCount;
    public float spawnDistance;
    float spawnPoint, nextSpawnPoint;
    float measureseconds = 0f;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            currentHighScore = PlayerPrefs.GetInt("HighScore");
            gameComponents.highScore.text = "High Score: " + currentHighScore;
        }
        StartCoroutine(startCounter(3));
        GameStart = false;

        nextSpawnPoint = Camera.main.transform.position.x;
        spawnPoint = (Mathf.Sign(nextSpawnPoint)*nextSpawnPoint) + spawnDistance;
        //var distance = Vector3.Distance(playerController.player.PlayerTransform.position, obstacleManager.obstacleSet.ObstaclePrefab.transform.position);
        //Debug.Log(distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStart)
        {
            playerController.enabled = true;
            scoreCount++;
            gameComponents.scoreCount.text = "Score: " + scoreCount;
            Camera.main.transform.Translate(Vector2.right * 10 * Time.deltaTime);
            if (Time.time - measureseconds >= 4f)
            {
                SpawnObstacles();
                measureseconds = Time.time;
            }


        }
    }
    IEnumerator startCounter(int count)
    {
        int counter = count;
       // yield return new WaitForSeconds(1f);
        while (counter != 0)
        {
           
            gameComponents.gameStartCounter.text = counter + "";
            counter--;
            yield return new WaitForSeconds(1f);
        }
        gameComponents.gameStartCounter.text = "Go!";
        yield return new WaitForSeconds(1f);
        
        StartGame();

    }
    void StartGame()
    {
        gameComponents.gameStartCounter.gameObject.SetActive(false);
        playerController.player.playerRigidBody.bodyType = RigidbodyType2D.Dynamic;
        playerController.player.CurrentState = 1;
        GameStart = true;
        playerController.ChangeState();
    }
    void SpawnObstacles()
    {
        int index = Random.Range(0, 3);
        GameObject obs=Instantiate(obstacleManager[index].obstacleSet.ObstaclePrefab);
        nextSpawnPoint = Camera.main.transform.position.x;
        spawnPoint = (Mathf.Sign(nextSpawnPoint) * nextSpawnPoint) + spawnDistance;
        obs.transform.position = new Vector3(spawnPoint, -3.7f, 0f);
    }
    public void Reload() 
    {
        SceneManager.LoadScene("GamePlay");
    }
}
