using UnityEngine;

public class CastingHandler : MonoBehaviour
{
    public Rigidbody hookRB;
    public Transform cast;
    public Transform hookLocation;
    public FishingCatchHandler fishingCatchHandler;

    private bool isCasted = false;

    public void Casting()
    {
        if (!isCasted)
        {
            hookRB.transform.SetParent(null, true);

            hookRB.isKinematic = false;
            hookRB.useGravity = true;

            hookRB.AddForce(cast.forward * 550f);

            isCasted = true;
        }
        else if (isCasted)
        {
            hookRB.isKinematic = true;
            hookRB.useGravity = false;

            hookRB.linearVelocity = Vector3.zero;
            hookRB.angularVelocity = Vector3.zero;

            hookRB.transform.position = hookLocation.position;
            hookRB.transform.rotation = hookLocation.rotation;

            hookRB.transform.SetParent(hookLocation, true);

            fishingCatchHandler.ResetFishing();

            isCasted = false;
        }
    }
}