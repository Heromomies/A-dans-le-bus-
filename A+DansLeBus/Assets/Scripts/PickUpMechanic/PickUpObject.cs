using System;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public bool isPickable;
    private bool _canBePicked = false;
    [SerializeField] private GameObject vfx_liquide;

    private GameObject _player = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canBePicked = true;
            _player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canBePicked = false;
            _player = other.gameObject;
        }
    }

    private void Update()
    {
        if (_canBePicked && Input.GetMouseButtonDown(0) && isPickable && _player != null &&
            _player.CompareTag("Player"))
        {
            SoundManager.instance.Play("PickObject");
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            isPickable = false;
            if (vfx_liquide != null)
            {
                GameObject vfx = Instantiate(vfx_liquide, gameObject.transform.position, Quaternion.identity);
                Destroy(vfx, 3f);
            }

            gameObject.SetActive(false);
        }
    }
}