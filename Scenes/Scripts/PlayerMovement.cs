using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float runingSpeed = 6f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float _speedJump;
    [SerializeField] private float horizontal;
    [SerializeField] private float animationInterpolation = 1f;
    [SerializeField] private float vertical;
    [SerializeField] private float lerpMultiplayer = 2f;
    [SerializeField] private Animator _animator;


    public bool Grounded;
    void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if (Grounded) {
                Rigidbody.AddForce(0f, _speedJump, 0f, ForceMode.VelocityChange);
            }
        }
    }

    void FixedUpdate() {
        animationInterpolation = Mathf.Clamp(animationInterpolation, 1f, Time.deltaTime);
        _animator.SetFloat("speed", horizontal * animationInterpolation);
        _animator.SetFloat("speed", vertical * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runingSpeed, Time.deltaTime);

        horizontal = Mathf.Lerp(horizontal, joystick.Horizontal, Time.deltaTime * lerpMultiplayer);
        vertical = Mathf.Lerp(vertical, joystick.Vertical, Time.deltaTime * lerpMultiplayer);

        Vector3 directionVector = new Vector3(horizontal, 0f, vertical);

        if (directionVector.magnitude > Mathf.Abs(0.05f)) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * _speedRotation);
            _animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
            Rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * _speed;
            Rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        float dot = UnityEngine.Vector2.Dot(collision.contacts[0].normal, UnityEngine.Vector2.up);
        if (dot > 0f) {
            Grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        Grounded = false;
    }
}
