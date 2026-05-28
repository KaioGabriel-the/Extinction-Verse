using UnityEngine;
using System.Collections;

public class CanvasTrigger : MonoBehaviour
{
    [Header("Canvas da UI")]
    public GameObject canvasObject;

    [Header("Tempo de Exibição")]
    public float displayTime = 3f;

    private Coroutine displayCoroutine;

    void Start()
    {
        if (canvasObject != null)
        {
            canvasObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }

            displayCoroutine = StartCoroutine(ShowCanvasRoutine());
        }
    }

    IEnumerator ShowCanvasRoutine()
    {
        canvasObject.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        canvasObject.SetActive(false);
        displayCoroutine = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }

            if (canvasObject != null)
            {
                canvasObject.SetActive(false);
            }
        }
    }
}