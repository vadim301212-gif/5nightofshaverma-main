using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int tomato;
    public int cucumber;
    public int cheese;
    public int shawarma;

    public Text tomatoText;
    public Text cucumberText;
    public Text cheeseText;
 

    public GameObject shawarmaObject; // 🔥 объект шаурмы в руках

    public void UpdateUI()
    {
        tomatoText.text = tomato.ToString();
        cucumberText.text = cucumber.ToString();
        cheeseText.text = cheese.ToString();
   
    }

    public void GiveShawarma()
    {
        shawarma += 1;
        UpdateUI();

        if (shawarmaObject != null)
        {
            shawarmaObject.SetActive(true); // 🔥 показываем шаурму
        }
        shawarmaObject.transform.localPosition = new Vector3(0.5f, 0.5f, 1f);
    }
}