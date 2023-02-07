using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public GameObject contonlsCanvasObj;
    public bool panelActive;

    private void Start()
    {
        panelActive = false;
    }

    private void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!panelActive)
            {
                contonlsCanvasObj.SetActive(true);
                panelActive = true;
                Time.timeScale = 0;
            }
            else if (panelActive)
            {
                contonlsCanvasObj.SetActive(false);
                panelActive = false;
                Time.timeScale = 1;
            }
        }
    }

    // Home scene buttons
    public void LoadLvl()
    {
        SceneManager.LoadScene (1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickDisplayContols()
    {
        if(!panelActive)
        {
            contonlsCanvasObj.SetActive(true);
            panelActive = true;
        }
    }
    public void OnClickHideContols()
    {
        if (panelActive)
        {
            contonlsCanvasObj.SetActive(false);
            panelActive = false;
        }
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
    }
}
