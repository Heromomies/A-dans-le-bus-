using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    #region singleton

    public static PlayerMovement _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    #endregion

    public float speed;

    private float _timerParticle = .3f;
    private float _timerStep = .2f;

    private Rigidbody2D _rb;

    public ParticleSystem dust;

    [SerializeField] private Animator _animator;

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

        if (xMove != 0 && yMove != 0)
        {
            xMove /= 2;
            yMove /= 2;
        }

        _animator.SetFloat("Horizontal", xMove);
        _animator.SetFloat("Vertical", yMove);
        _animator.SetFloat("Speed", _rb.velocity.sqrMagnitude);

        _rb.AddForce(new Vector3(xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed, 0));
        if (xMove != 0 || yMove != 0)
        {
            _timerParticle -= Time.deltaTime;
            if (_timerParticle <= 0)
            {
                dust.Play();
                _timerParticle = .3f;
            }

            _timerStep -= Time.deltaTime;
            if (_timerStep <= 0)
            {
                int step = Random.Range(0, 4);
                switch (step)
                {
                    case 1:
                        SoundManager.instance.Play("Step1");
                        return;
                    case 2:
                        SoundManager.instance.Play("Step2");
                        return;
                    case 3:
                        SoundManager.instance.Play("Step3");
                        return;
                    case 4:
                        SoundManager.instance.Play("Step4");
                        return;
                }

                _timerStep = .2f;
            }
        }


        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && yMove > 0)
        {
            _animator.SetTrigger("Attack_Up");
            SoundManager.instance.Play("Punch");
        }

        else if (Input.GetMouseButtonDown(0) && yMove < 0)
        {
            _animator.SetTrigger("Attack_Down");
            SoundManager.instance.Play("Punch");
        }

        else if (Input.GetMouseButtonDown(0) && xMove > 0)
        {
            _animator.SetTrigger("AttackRight");
            SoundManager.instance.Play("Punch");
        }

        else if (Input.GetMouseButtonDown(0) && xMove < 0)
        {
            _animator.SetTrigger("Attack_Left");
            SoundManager.instance.Play("Punch");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door") && GameManager.gm.win)
        {
            GameManager.gm.panelWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}