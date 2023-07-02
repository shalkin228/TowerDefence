using UnityEngine;
using System.Linq;

namespace TowerDefence.Gameplay
{
    public abstract class TargetSearcher<Target> : MonoBehaviour where Target : MonoBehaviour
    {
        public Target CurrentTarget;

        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _searchRadius;

        private void LateUpdate()
        {
            if (IsTargetInsideSearchRadius(CurrentTarget))
            {
                FindNewTarget();
            }
        }

        private bool IsTargetInsideSearchRadius(Target target)
        {
            if (target == null) return false;

            Vector3 targetPosition = target.transform.position;
            Vector3 myPosition = transform.position;
            return Vector3.Distance(myPosition, targetPosition) < _searchRadius;
        }

        private void FindNewTarget()
        {
            Collider[] overlappedColliders = OverlapSphere();
            OrderCollidersArrayByDistance(ref overlappedColliders);
            foreach (var overlappedCollider in overlappedColliders)
            {
                if (IsColliderTarget(overlappedCollider, out Target targetComponent))
                {
                    CurrentTarget = targetComponent;
                }
            }
        }

        private void OrderCollidersArrayByDistance(ref Collider[] colliders)
        {
            colliders.OrderBy(c => (transform.position - c.transform.position).sqrMagnitude).ToArray();
        }

        private Collider[] OverlapSphere()
        {
            return Physics.OverlapSphere(transform.position, _searchRadius, _layerMask); 
        }

        private bool IsColliderTarget(Collider collider, out Target targetComponent)
        {
            targetComponent = collider.GetComponent<Target>();
            return targetComponent != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _searchRadius);
        }
    }
}
