using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] paths;
    public Transform startPoint;
    public int points;
    [SerializeField] TextMeshProUGUI gameOverText;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        points = 150;
    }

    public void InscreasePoints(int amount)
    {
        points += amount;
    }

    public bool Buy(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough points");
            return false;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;  // game stops means speed of the time is now 0 so nothing moves
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
