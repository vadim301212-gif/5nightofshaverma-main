using UnityEngine;

public class Crafting : MonoBehaviour
{
    public int needTomato = 1;
    public int needCucumber = 1;
    public int needCheese = 1;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (inv != null &&
                inv.tomato >= needTomato &&
                inv.cucumber >= needCucumber &&
                inv.cheese >= needCheese)
            {
                inv.tomato -= needTomato;
                inv.cucumber -= needCucumber;
                inv.cheese -= needCheese;

                inv.GiveShawarma(); // 🔥 создаём шаурму

                inv.UpdateUI();

            }
        }
    }
}