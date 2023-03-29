using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image image;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] public Button button;

    private string Text
    {
        get => textMeshProUGUI.text;
        set => textMeshProUGUI.text = value;
    }

    private void Awake()
    {
        image = GetComponentsInChildren<UnityEngine.UI.Image>()[1];
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponentInChildren<Button>() 
                 ?? throw new System.Exception("Button not found");
    }


    public void SetEmpty()
    {
        image.sprite = null;
        image.color = Color.clear;
        Text = "";
    }

    public void SetItem(Item item)
    {
        
        Debug.Assert(image);
        
        image.sprite = item.sprite;
        image.color = item.sprite ? Color.white : Color.clear;
        Text = item.amount == 0 ? "" : item.amount.ToString();
    }
    
    
}