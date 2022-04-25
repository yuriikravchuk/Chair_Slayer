using UnityEngine;
using UnityEngine.UI;

public class DisplayStatistics : MonoBehaviour
{
    public GameObject statisticsObj;
    private bool isActive;
    public bool IsActive
    {
        get
        {
            return IsActive;
        }
        set
        {
            if(isActive != value)
            {
                HidePanel(value);
                isActive = value;
            }

        }
    }
    public Image UIHealth;
    private void HidePanel(bool current) 
    {
        statisticsObj.SetActive(current);
    }
    
    
}
