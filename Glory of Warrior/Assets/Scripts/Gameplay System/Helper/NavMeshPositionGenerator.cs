using UnityEngine;
using UnityEngine.AI;

namespace Gameplay_System.Helper
{
    public class NavMeshPositionGenerator
    {
        public Vector3 GetRandomNavMeshPosition(Vector3 center, float range)
        {
            Vector3 randomPoint = center + new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return center;
        }
    }
}