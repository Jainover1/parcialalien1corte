using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] Spaceship player;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject winUI;
    [SerializeField] int numEnemies;
    [SerializeField] public int puntosVida; 
    bool gamePaused = false;
    bool gameWin = false;
    bool realentizar = false;
    public bool estaLento = false;
    int intentos = 0;
    float tiempoLento = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameWin == false)
            PauseGame();
        if (Input.GetKeyDown(KeyCode.T))
            realentizar = true;
        slowTime();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("level1");
        Time.timeScale = 1;
    }

    void slowTime()
    {
        if (realentizar == true)
        {
            if (estaLento != true)
            {
                intentos++;
                if (intentos <= 3)
                {
                    realentizar = true;
                    estaLento = true;
                    tiempoLento = 1.5f;
                }
            }
            else
            {
                    if (tiempoLento<= 0)
                    {
                        realentizar = false;
                        estaLento = false;
                        Time.timeScale = 1;
                    }
                    else
                    {
                         tiempoLento = tiempoLento - Time.deltaTime;
                         Time.timeScale = 0.5f;
                }
                
            }
        }
    }

    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;

        player.gamePaused = gamePaused;
        
        pauseUI.SetActive(gamePaused);

        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if(numEnemies < 1)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        Time.timeScale = 0;
        player.gamePaused = true;
        winUI.SetActive(true);
    }


    public void nextLevel(string level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}
