using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UIComponents uiComponents;
    private void Awake()
    {
        instance = this;
        if (instance != null)
            DontDestroyOnLoad(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowComponents", 0.5f);
    }
    void ShowComponents()
    {
        uiComponents.mainMenuComponent.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGameScene(float delay)
    {
        StartCoroutine(LoadWithDelay("GamePlay",delay));
    }
    IEnumerator LoadWithDelay(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
