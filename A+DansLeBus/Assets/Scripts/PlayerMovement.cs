using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private float _timerParticle = .3f;

    private Rigidbody2D _rb;

    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        
        _rb.AddForce(new Vector3(xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed, 0));
        if (xMove != 0 || yMove != 0)
        {
            _timerParticle -= Time.deltaTime;
            if (_timerParticle <= 0)
            {
                dust.Play();
                _timerParticle = .3f;
            }
        }
    }
}