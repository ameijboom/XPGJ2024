using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _dashForce;

    private Rigidbody2D _rb;
    private Vector2 _input;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (_input.x != 0 || _input.y != 0) _input *= 0.7f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dashing");
            Dash();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new(_movementSpeed * _input.x * Time.deltaTime, _movementSpeed * _input.y * Time.deltaTime);
    }

    void Dash() => _rb.AddForce(new Vector2(_dashForce * _input.x, _dashForce * _input.y), ForceMode2D.Force);
}
