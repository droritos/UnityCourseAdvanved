using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI counterText;

    private void Start()
    {
        UpdateText(0);
        gameManager.OnCounterChanged += UpdateText;
    }

    public void UpdateText(int counter)
    {
        counterText.text = $"Killed : {counter}";
    }
}
