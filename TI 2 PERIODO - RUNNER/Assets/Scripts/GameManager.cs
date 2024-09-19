using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Vari�veis

    [Header("Controllers")]
        private LogController logController;
        private PowerUpController powerUpController;
    [Header("Panels")]
        public GameObject menuPanel;
        public GameObject pausePanel;
        public GameObject settingPanel;
        public GameObject gameOverPanel;
    [Header("Utilitaries")]
        public bool isPaused; 
        

    #endregion

    #region M�todos

    private void Awake()
    {
        //logController = new LogController();
        Time.timeScale = 1f;
    }


    private void Update()
    {
        //Cheats();
    }

    private void Cheats()
    {
        // Vidas infinitas
        if (Input.GetKeyDown(KeyCode.F3))
        {

        }
    }

    public void StartGame()
    {
        // TO-DO: ALTERAR PARA OS MENUS SEREM UMA CENA DIFERENTE DA GAMEPLAY
        
        Time.timeScale = 1f;
        isPaused = false;
       
        // menuPanel.SetActive(false);         // Desativa o painel de MENU PRINCIPAL (Precisa disso n�o, s� desativar usando os bot�es)
        // pausePanel.SetActive(false);        // Desativa o painel de PAUSE (Precisa disso n�o, s� desativar usando os bot�es)
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
       
        // pausePanel.SetActive(true);         // Ativa o painel de PAUSE (Precisa disso n�o, s� desativar usando os bot�es)
        //logController.PanelActivite(Panels.pause, pausePanel.active);
    }

    [System.Obsolete]
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);      // Ativa o painel de GAME OVER
        isPaused = true;
        //logController.PanelActivite(Panels.gameOver, gameOverPanel.active);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

}