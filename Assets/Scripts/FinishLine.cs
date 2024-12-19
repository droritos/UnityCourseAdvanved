using TMPro;
using UnityEngine;
using System.Collections;
using Unity.AI.Navigation;

public class FinishLine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finishText;
    [SerializeField] NavMeshModifier crimsonModifier;
    void Start()
    {
        finishText.gameObject.SetActive(false); // Make sure the text is off
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(collision.gameObject.name);
        if (other.CompareTag("Agent"))
        {
            StartCoroutine(ApplyText());
            crimsonModifier.enabled = true;
            print($"Reach finish line and crimson is now {crimsonModifier.enabled} if true than he walkable");
        }
    }

    private IEnumerator ApplyText()
    {
        finishText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        finishText.gameObject.SetActive(false);
    }
}
