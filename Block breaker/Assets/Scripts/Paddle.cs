using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] float minPaddleX = 0F;
    [SerializeField] float maxPaddleX = 14.0F;
    [SerializeField] float unityScreenWidth = 16.00F;

    // cashed reference
    GameStatus myGameStatus;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        myGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // float mouseX = Input.mousePosition.x / Screen.width * unityScreenWidth;
        Vector2 paddlePosition = new Vector2 (transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minPaddleX, maxPaddleX);
        transform.position = paddlePosition;
    }

    private float GetXPos() {
        if(myGameStatus.IsActiveAndEnabled()) {
            return theBall.transform.position.x - 1;
        }
        else {
            return Input.mousePosition.x / Screen.width * unityScreenWidth;
        }
    }
}