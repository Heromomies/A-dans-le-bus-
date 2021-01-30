using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BigObject : MonoBehaviour
{
    public ParticleSystem particleExplosion;

    public int objectLife;

    private bool _playOnce = true;
    private bool _canBeHitting = false;

    public bool hasObjectHidden = false;
    public GameObject objectHidden;

    public new Transform transform;
    [SerializeField]
    private GameObject vfxSplashWater;
    private void Awake()
    {
        transform = gameObject.transform;
    }

    private void Start()
    {
        if (objectHidden != null)
        {
            objectHidden.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (objectLife <= 0 && _playOnce)
        {
            StartCoroutine(DisableObject());
            if (hasObjectHidden)
            {
                objectHidden.SetActive(true);
            }

            _playOnce = false;
        }

        if (_canBeHitting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Camera.main.DOShakePosition(0.5f, 0.1f, 90, 0.5f);
                Camera.main.DOShakeRotation(0.5f, .1f, 90, .5f);
                Damage(1);
            }
        }
    }

    IEnumerator DisableObject()
    {
        if (vfxSplashWater != null)
        {
            GameObject vfx = Instantiate(vfxSplashWater, transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
        }
        particleExplosion.Play();
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(5.5f);
        gameObject.SetActive(false);
    }

    public void Damage(int amount)
    {
        objectLife -= amount;
        Debug.Log(objectLife);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _canBeHitting = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _canBeHitting = false;
    }
}