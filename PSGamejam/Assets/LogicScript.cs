using UnityEngine;
using UnityEngine.UI;

public class Bartender : MonoBehaviour
{
    public Slider[] sliders; // Array to hold sliders for each liquid
    public Text[] amounts; // Array to hold text elements to display amounts
    public Image glassFill; // Image to show filling of the glass
    private float totalLiquid = 0f; // To keep track of the total liquid in the glass
    void CheckMix()
    {
        // Define some logic to check the mixture
        // For example, if the total liquid is between certain ranges, the player might succeed or fail
        if (totalLiquid > 50f && totalLiquid < 80f)
        {
            Debug.Log("Good Mix!");
        }
        else
        {
            Debug.Log("Bad Mix!");
        }
}
    void Start()
    {
        // Initialize sliders and amounts
        foreach (Slider slider in sliders)
        {
            slider.onValueChanged.AddListener(delegate { UpdateAmounts(); });
        }
        UpdateAmounts();
    }

    void UpdateAmounts()
    {
        totalLiquid = 0f;
        for (int i = 0; i < sliders.Length; i++)
        {
            amounts[i].text = sliders[i].value.ToString("0.0");
            totalLiquid += sliders[i].value;
        }
        UpdateGlassFill();
    }

    void UpdateGlassFill()
    {
        glassFill.fillAmount = totalLiquid / 100f; // Assuming 100 is the max fill amount
    }
}


