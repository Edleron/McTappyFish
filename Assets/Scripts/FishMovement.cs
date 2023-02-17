using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    #region Event-Delegate System
    public delegate void ourEventDelegate();
    public static event ourEventDelegate scoreState;
    public static event ourEventDelegate gameStarted;
    public static event ourEventDelegate gameFinished;
    public static event ourEventDelegate instantObstacle;
    #endregion

    #region Component Variables
    private Rigidbody2D _myRb;
    private Animator _anim;
    private AudioSource _sfxSource;
    #endregion

    #region Constant Variables
    private float _speed = 9.0f;
    private int angle = 0;
    #endregion

    #region Variables
    public List<AudioClip> _sfxClip = new List<AudioClip>();
    #endregion

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sfxSource = GetComponent<AudioSource>();
        _myRb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameOver == false)
        {
            TouchPlease();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.isGameOver == false)
        {
            FishRotate();
        }
    }

    private void TouchPlease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(_sfxClip[0], Camera.main.transform.position);
            if (GameManager.isGameStarted == false)
            {
                _myRb.gravityScale = 4f;
                _myRb.velocity = Vector2.zero;
                _myRb.velocity = new Vector2(_myRb.velocity.x, _speed);
                instantObstacle();
                gameStarted();
            }
            else
            {
                _myRb.velocity = Vector2.zero;
                _myRb.velocity = new Vector2(_myRb.velocity.x, _speed);
            }
        }
    }

    private void FishRotate()
    {
        int maxAngle = 20;
        int minAngle = -60;

        if (_myRb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_myRb.velocity.y < -3)
        {
            if (angle > minAngle)
            {
                angle = angle - 1;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //_uiManager.addToScore();
            scoreState();
            AudioSource.PlayClipAtPoint(_sfxClip[1], Camera.main.transform.position);
        }
        else if (other.gameObject.CompareTag("Column") && GameManager.isGameOver == false)
        {
            gameFinished();
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameManager.isGameOver == false)
            {
                gameFinished();
            }
            GameOver();
        }
    }

    private void GameOver()
    {
        AudioSource.PlayClipAtPoint(_sfxClip[2], Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _anim.enabled = false;
    }
}
