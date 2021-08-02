using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class NavMeshDebugger : MonoBehaviour
{
    [SerializeField] private Player agent;

    private LineRenderer lines;

    void Start()
    {
        lines = GetComponent<LineRenderer>();    
    }

    void Update()
    {
        if (agent.Path.corners.Length > 0)
        {
            lines.positionCount = agent.Path.corners.Length;
            lines.SetPositions(agent.Path.corners);
            lines.enabled = true;
        }
        else
        {
            lines.enabled = false;
        }
    }
}
