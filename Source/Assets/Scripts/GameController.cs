using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int score = 0;
    [SerializeField]
    private GameObject _gameOverMenu;
    [SerializeField]
    private GameObject _startGameMenu;
    [SerializeField]
    private GameObject _UI;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private WayController wayController;

    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _bestScore;

    void Start()
    {
        score = 0;
        ChangeMenu(_startGameMenu);
        Time.timeScale = 0f;
    }
    void Update()
    {
        _score.text = "Score: "+score.ToString() ;

        if (!_playerController.GroundCheck()) {

            if (score > PlayerPrefs.GetInt("Score"))
                PlayerPrefs.SetInt("Score", score);
            _bestScore.text = "Best score: " + PlayerPrefs.GetInt("Score");
            ChangeMenu(_gameOverMenu);

            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                SceneManager.LoadScene("turning");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeMenu(_UI);
            Time.timeScale = 1f;
        }
    }


    void ChangeMenu(GameObject menu) {
        _gameOverMenu.SetActive(false);
        _startGameMenu.SetActive(false);
        _UI.SetActive(false);

        menu.SetActive(true);
    }


}
