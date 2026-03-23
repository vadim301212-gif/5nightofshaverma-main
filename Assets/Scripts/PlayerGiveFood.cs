using UnityEngine;

public class PlayerGiveFood : MonoBehaviour
{
    public bool hasShawarma = true;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NPC") && Input.GetKeyDown(KeyCode.E))
        {
            if (hasShawarma)
            {
                NPCController npc = other.GetComponent<NPCController>();

                if (npc != null)
                {
                    npc.ReceiveShawarma();
                    hasShawarma = false;
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
