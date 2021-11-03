using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;
    public GameComponents gameComponents;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCounter(3));
    }

    // Update is called once per frame
    void Update()
    {

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
        playerController.ChangeState();
    }
}
