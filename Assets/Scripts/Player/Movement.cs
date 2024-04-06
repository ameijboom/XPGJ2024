using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _dashForce;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashCooldown;

    private float _dashDurationCounter, _dashCooldownCounter;
    private float _currentMoveSpeed;

    private Rigidbody2D _rb;
    private Vector2 _input;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentMoveSpeed = _movementSpeed;
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (_input.x != 0 || _input.y != 0) _input *= 0.7f;
        _rb.velocity =  _input * _currentMoveSpeed;

        Dash();
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_dashCooldownCounter <= 0 && _dashDurationCounter <= 0)
            {
                _currentMoveSpeed = _dashForce;
                _dashDurationCounter = _dashDuration;
            }
        }
        
        if (_dashDurationCounter > 0)
        {
            _dashDurationCounter -= Time.deltaTime;

            if (_dashDurationCounter <= 0)
            {
                _currentMoveSpeed = _movementSpeed;
                _dashCooldownCounter = _dashCooldown;
            }
        }

        if (_dashCooldownCounter > 0)
        {
            _dashCooldownCounter -= Time.deltaTime;
        }
    } 
}
