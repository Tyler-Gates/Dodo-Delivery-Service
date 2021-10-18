using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigid;
    SpriteRenderer _spriteRenderer;
    BoxCollider2D _boxCollider2d;
    public int lives;
    public bool tool1, tool2, tool3, tool4;
    
    
    public float speed;
    public float jump;
    public bool dimSprite;
    private bool _moveRight;
    private bool _moveLeft;
    public bool grounded;
    private bool _jump;
    public bool open;
    private LivesManager _livesManager;
    [SerializeField] private LayerMask whatIsGround;
    
    // Start is called before the first frame update
    void Start()
    {
        tool1 =  GlobalControl.Instance.tool1;
        tool2 =  GlobalControl.Instance.tool2;
        tool3 = GlobalControl.Instance.tool3;
        tool4 =  GlobalControl.Instance.tool4;
        lives =  GlobalControl.Instance.lives;
        _livesManager =  FindObjectOfType<LivesManager>();
        _animator = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalControl.Instance.lives == 0)
            ChangeLevel();
        grounded = GroundCheck();
        _jump = Input.GetKey(KeyCode.Space) && grounded;
        if (open)
        {
            _rigid.velocity = Vector2.zero;
            return;
        }

        _moveLeft=(Input.GetKey("d") || Input.GetKey("right"));
        _moveRight=(Input.GetKey("a") || Input.GetKey("left"));
        if(!_moveLeft && !_moveRight && !_jump && grounded)
            _animator.Play(dimSprite ? "bird1_idle" : "1bird_idle");
        if (!grounded)
            _animator.Play(dimSprite ? "bird1_jump" : "1bird_jump");
    }
    
    private void FixedUpdate()
    {
        if (open)
        {
            _animator.Play("1bird_idle");
            return;
        }
        if(_moveLeft)
        {
            var velocity = _rigid.velocity;
            velocity = velocity.y < 0 ? new Vector2(speed,0) : new Vector2(speed,velocity.y);
            _rigid.velocity = velocity;

            if (grounded)
            {
                _animator.Play(dimSprite ? "bird1_move" : "1bird_move");
            }
            _spriteRenderer.flipX = false;
        }
        else if(_moveRight)
        {
            var velocity = _rigid.velocity;
            velocity = velocity.y < 0 ? new Vector2(-speed,0) : new Vector2(-speed,velocity.y);
            _rigid.velocity = velocity;

            if (grounded)
            {
                _animator.Play(dimSprite ? "bird1_move" : "1bird_move");
            }
            _spriteRenderer.flipX = true;
        }

        if (!_jump) return;
        _rigid.velocity = new Vector2(_rigid.velocity.x,jump);
        _jump = false;
    }

    private bool GroundCheck(){
        return Physics2D.BoxCast(_boxCollider2d.bounds.center, _boxCollider2d.size, 0, Vector2.down, 0.1f, whatIsGround);
    }

    public void KillPlayer()
    {
        GlobalControl.Instance.SetLivesCount(lives-1);
        StartCoroutine(RestartSceneAfterDelay(1.5f));
    }

    
    public void ChangeLevel()
    {
        StartCoroutine(ChangeSceneAfterDelay(1.5f));
        
    }
    IEnumerator ChangeSceneAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (GlobalControl.Instance.lives == 0)
        {
            GlobalControl.Instance.tool1 = false;
            GlobalControl.Instance.tool2 = false;
            GlobalControl.Instance.tool3 = false;
            GlobalControl.Instance.tool4 = false;
            GlobalControl.Instance.lives = -1;
            SceneManager.LoadScene(3);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GlobalControl.Instance.lives = 3;
            _livesManager.SetLivesCount(3);
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(1);
        
    }

    public void SavePlayer()//uwu
    {
        GlobalControl.Instance.lives = lives;
        GlobalControl.Instance.tool1 = tool1;
        GlobalControl.Instance.tool2 = tool2;
        GlobalControl.Instance.tool3 = tool3;
        GlobalControl.Instance.tool4 = tool4;
    }
    
    IEnumerator RestartSceneAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    
}
