using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private Vector3 _initialOffset;
    [SerializeField] private Vector3 _correctedOffset;
    [SerializeField] private float _movingSpeed = 1f;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _minVerticalAngle = 35f;
    [SerializeField] private float _maxVerticalAngle = 65f;

    private void Awake()
    {
        _correctedOffset = _initialOffset;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            RotateAroundTarget();
        }

        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = _trackingTarget.position + _correctedOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, _movingSpeed * Time.deltaTime);
        transform.LookAt(_trackingTarget);
    }

    private void RotateAroundTarget()
    {
        float mouseOffsetX = Input.GetAxis("Mouse X");
        float mouseOffsetY = Input.GetAxis("Mouse Y");

        float deadZone = 0.1f;

        bool isMouseMoved = Mathf.Abs(mouseOffsetX) > deadZone || Mathf.Abs(mouseOffsetY) > deadZone;

        if (isMouseMoved)
        {
            transform.RotateAround(_trackingTarget.position, Vector3.up, _rotationSpeed * Time.deltaTime * mouseOffsetX);

            Vector3 positionBeforeVerticalRotation = transform.position;

            transform.RotateAround(_trackingTarget.position, transform.right, _rotationSpeed * Time.deltaTime * -mouseOffsetY);

            if (ShouldRotateVertically() == false)
                transform.position = positionBeforeVerticalRotation;

            _correctedOffset = transform.position - _trackingTarget.position;
        }
    }

    bool ShouldRotateVertically()
    {
        Vector3 vectorToTarget = _trackingTarget.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        float normalToTarget = transform.position.y - _trackingTarget.position.y;

        float verticalAngleInDegrees = Mathf.Acos(normalToTarget / distanceToTarget) * Mathf.Rad2Deg;

        return verticalAngleInDegrees > _minVerticalAngle && verticalAngleInDegrees < _maxVerticalAngle;
    }
}