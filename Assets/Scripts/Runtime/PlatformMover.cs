
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlatformMover : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private GameSession session;
    [SerializeField] private float speed = 5f;

    private void OnEnable()
    {
        move.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
    }

    private void Update()
    {
        if (!session.CanMove)
        {
            return;
        }

        // 대각선 이동 속도가 더 빨라지지 않도록 제한
        Vector2 input = Vector2.ClampMagnitude(
            move.action.ReadValue<Vector2>(), 1f);

        // 입력값을 바닥의 X, Z 방향으로 변환
        Vector3 next = transform.position
            + new Vector3(input.x, 0f, input.y) * speed * Time.deltaTime;

        // 바닥 밖으로 나가지 않도록 이동 범위 제한
        next.x = Mathf.Clamp(next.x, -9f, 9f);
        next.z = Mathf.Clamp(next.z, -9f, 9f);

        transform.position = next;
    }
}

