using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public bool isPickable;
    [SerializeField]
    private GameObject vfx_liquide;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(0) && isPickable && other.CompareTag("Player"))
        {
            GameManager.gm.objectsCatchByPlayer.Add(gameObject);
            GameManager.gm.CheckIfVictory();
            isPickable = false;
            if (vfx_liquide != null)
            {
                GameObject vfx = Instantiate(vfx_liquide, transform.position, Quaternion.identity);
                Destroy(vfx, 3f);
            }
            gameObject.SetActive(false);
        }
    }
}