using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDestroyed = 100;
    [SerializeField] int score = 0;
    [SerializeField] Text scoreDisplay;
    [SerializeField] new bool isActiveAndEnabled;

    // Load the game score object
    private void Awake() {
        int gameStatusobjectCount = FindObjectsOfType<GameStatus>().Length;

        if(gameStatusobjectCount > 1) {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore() {
        score = score + scorePerBlockDestroyed;
        scoreDisplay.text = score.ToString();
    }

    public void ResetGame() {
        Destroy(this.gameObject);
    }

    public bool IsActiveAndEnabled() {
        return isActiveAndEnabled;
    }
}
