using UnityEngine;
using UnityEngine.AI;

public class InputController : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private Player playerAgent;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (ray.direction.y != 0)
            {
                Vector3 point = ray.GetPoint(-ray.origin.y / ray.direction.y);
                NavMeshHit hit;
                if (NavMesh.SamplePosition(point, out hit, 1f, NavMesh.AllAreas))
                {
                    playerAgent.GoTo(hit.position);
                }
            }
        }
    }
}
