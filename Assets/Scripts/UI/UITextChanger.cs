using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UITextChanger : MonoBehaviour
{

    [SerializeField] private Inventory inventory;
    private TMP_Text coinText;

    private void Awake() 
    {
        coinText = GetComponent<TMP_Text>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateTextValue(inventory.Money);
    }

    void OnEnable()
    {
        inventory.OnMoneyChanged += UpdateTextValue;
    }
    
    private void UpdateTextValue(int value) 
    {
        coinText.text = value.ToString();
    }

    void OnDisable()
    {
        inventory.OnMoneyChanged -= UpdateTextValue;
    }
}
