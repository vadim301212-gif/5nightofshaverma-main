using UnityEngine;
using UnityEngine.AI;

public class Objectmove : MonoBehaviour
{
    public Transform target;
    public GameObject orderSheet; // Весь листок (UI-панель)
    
    private NavMeshAgent agent;
    private bool arrived = false;
    private bool isSheetOpen = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (orderSheet != null) orderSheet.SetActive(false); 
    }

    void Update()
    {
        // 1. Движение к цели
        if (target != null && !arrived)
        {
            agent.SetDestination(target.position);

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                ShowOrder();
            }
        }

        // 2. Возможность вернуть/скрыть листок кнопкой (например, Tab)
        // Кнопка сработает только если мы УЖЕ дошли до точки хотя бы раз
        if (arrived && Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isSheetOpen) ShowOrder();
            else CloseOrder();
        }
    }

    public void ShowOrder()
    {
        arrived = true;
        isSheetOpen = true;
        orderSheet.SetActive(true);
        
        // Показываем мышку
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseOrder()
    {
        isSheetOpen = false;
        orderSheet.SetActive(false);
        
        // Прячем мышку обратно в игру
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
