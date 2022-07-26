using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
      
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
      
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex   + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("aaaa");
    }

    public void end()
    {
        SceneManager.LoadScene(3);
    }
}
