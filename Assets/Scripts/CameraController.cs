using Assets.Scripts;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    private Interactable currentInteractable;
    [SerializeField] private float interactionDistance;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position,this.transform.forward, out hit,  1000f))
        {
            Interactable newInteractable = hit.transform.GetComponent<Interactable>();
            if (newInteractable == null)
            {
                if (this.currentInteractable != null)
                {
                    this.currentInteractable.OnLookExit();
                    this.currentInteractable = null;
                }
            }
            else
            {
                if (this.currentInteractable != null)
                {
                    if (newInteractable.GetInstanceID() != this.currentInteractable.GetInstanceID())
                    {
                        this.currentInteractable = newInteractable;
                        this.currentInteractable.OnLookEnter();
                        Debug.Log("OnLookEnter");
                    }
                    
                    this.currentInteractable.OnLook(this.transform, this.interactionDistance);
                    Debug.Log("OnLook");
                }
                else
                {
                    this.currentInteractable = newInteractable;
                    this.currentInteractable.OnLookEnter();
                    Debug.Log("OnLookEnter");
                }
            }
        }
        Debug.DrawRay(this.transform.position, this.transform.forward * 1000f, Color.red);
    }
}
