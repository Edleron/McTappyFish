using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    // Todo : proje başladıktan sonra, git uset değiştirilecek.
    // Todo : Commitler bu sebeple gözükmüyor.
    Rigidbody2D _myRb;
    Animator _anim;
    AudioSource _sfxSource;
    SpriteRenderer _sp;
    [SerializeField] private float _speed = 9.0f;
    public UIManager _uiManager;
    public GameManager _gameManager;
    public ObjectSpawner _objectSpawner;
    public Sprite fishDie;
    private int maxAngle = 20;
    private int minAngle = -60;
    private int angle = 0;

    public List<AudioClip> _sfxClip = new List<AudioClip>();

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sp = GetComponent<SpriteRenderer>();
        _sfxSource = GetComponent<AudioSource>();
        _myRb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            TouchPlease();
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.gameOver == false)
        {
            FishRotate();
        }
    }

    private void TouchPlease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(_sfxClip[0], Camera.main.transform.position);
            if (GameManager.gameStarted == false)
            {
                _myRb.gravityScale = 4f;
                _myRb.velocity = Vector2.zero;
                _myRb.velocity = new Vector2(_myRb.velocity.x, _speed);
                _objectSpawner.InstantiateObstacle();
                _gameManager.GameStarted();
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
            _uiManager.addToScore();
            AudioSource.PlayClipAtPoint(_sfxClip[1], Camera.main.transform.position);
        }
        else if (other.gameObject.CompareTag("Column") && GameManager.gameOver == false)
        {
            _gameManager.GameOver();
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                _gameManager.GameOver();
            }
            GameOver();
        }
    }

    private void GameOver()
    {
        AudioSource.PlayClipAtPoint(_sfxClip[2], Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _anim.enabled = false;
        _sp.sprite = fishDie;
    }
}
