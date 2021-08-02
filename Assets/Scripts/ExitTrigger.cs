using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        GameController.Instance.ExitReached();
    }
}
