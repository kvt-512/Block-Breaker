using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle;
    [SerializeField] float velocityX = 2.0F;
    [SerializeField] float velocityY = 15.0F;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2F;

    //cached reference
    Rigidbody2D myRigidBody2d;

    //State
    Vector2 paddleToBallDistanceVector;
    bool clicked;
    bool shouldMouseClick;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
        shouldMouseClick = true;
        myRigidBody2d = GetComponent<Rigidbody2D>();
        paddleToBallDistanceVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == false)
        {
            LockBallToPaddle();
        }
        
        if (Input.GetMouseButtonDown(0) && shouldMouseClick ==  true)
        {
            clicked = true;
            LaunchTheBall();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 ballPosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = ballPosition + paddleToBallDistanceVector;
    }

    private void LaunchTheBall()
    {
        myRigidBody2d.velocity = new Vector2(velocityX, velocityY);
        shouldMouseClick = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 velocityTweek = new Vector2(Random.Range(0F, randomFactor), Random.Range(0F, randomFactor));
        if(clicked == true) {
            AudioClip singleAudioClip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(singleAudioClip);
            myRigidBody2d.velocity += velocityTweek;
        }    
    }
}
