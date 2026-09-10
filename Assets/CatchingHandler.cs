using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FishingCatchHandler : MonoBehaviour
{
    public XRSocketInteractor hookSocket;

    public GameObject sodaCanPrefab;
    public GameObject fishPrefab;

    public Transform baitAttachPoint;

    private bool hasCaughtSomething = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !hasCaughtSomething)
        {
            StartCoroutine(WaitForCatch());
        }
    }

    private void RemoveBait()
    {
        if (hookSocket.hasSelection)
        {
            var selected = hookSocket.interactablesSelected[0];

            GameObject bait = selected.transform.gameObject;

            Destroy(bait);
        }
    }

    private IEnumerator WaitForCatch()
    {
        hasCaughtSomething = true;

        yield return new WaitForSeconds(Random.Range(1f, 2f));

        bool wasBaited = hookSocket.hasSelection;

        if (wasBaited)
        {
            RemoveBait();
        }

        // Wait 3–6 seconds
        float waitTime = Random.Range(3f, 6f);
        yield return new WaitForSeconds(waitTime);

        if (wasBaited)
        {
            SpawnFish();
        }
        else
        {
            SpawnCatch();
        }
    }

    private void SpawnCatch()
    {
        float roll = Random.Range(0f, 100f);

        GameObject catchPrefab;

        if (roll < 90f)
        {
            catchPrefab = sodaCanPrefab;
        }
        else
        {
            catchPrefab = fishPrefab;
        }

        Instantiate(
            catchPrefab,
            baitAttachPoint.position,
            baitAttachPoint.rotation
        );
    }

    private void SpawnFish()
    {
        float roll = Random.Range(0f, 100f);

        GameObject catchPrefab;

        if (roll < 90f)
        {
            catchPrefab = fishPrefab;
        }
        else
        {
            catchPrefab = sodaCanPrefab;
        }

        Instantiate(
            catchPrefab,
            baitAttachPoint.position,
            baitAttachPoint.rotation
        );
    }

    public void ResetFishing()
    {
        hasCaughtSomething = false;
    }
}