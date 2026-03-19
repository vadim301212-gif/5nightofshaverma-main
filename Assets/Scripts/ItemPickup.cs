using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        Tomato,
        Cucumber,
        Cheese
    }

    public ItemType itemType;
    public int amount = 1;

    private bool playerInRange = false;
    private Inventory inv;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            inv = other.GetComponent<Inventory>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            inv = null;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inv != null)
            {
                switch (itemType)
                {
                    case ItemType.Tomato:
                        inv.tomato += amount;
                        break;

                    case ItemType.Cucumber:
                        inv.cucumber += amount;
                        break;

                    case ItemType.Cheese:
                        inv.cheese += amount;
                        break;
                }

                inv.UpdateUI();
                Destroy(gameObject);
            }
        }
    }
}