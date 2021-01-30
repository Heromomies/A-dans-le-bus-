using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public bool isPickable;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0) && isPickable && other.CompareTag("Player"))
        {
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            isPickable = false;
            gameObject.SetActive(false);
        }
    }
}