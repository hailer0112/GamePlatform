
using UnityEngine;

public sealed class CoinPickup : MonoBehaviour
{
    [SerializeField] private int coinId;

    private GameSession session;
    private Transform player;

    public void Initialize(GameSession owner, Transform target)
    {
        session = owner;
        player = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 지정한 플레이어와 충돌했는지 확인
        if (session == null || other.transform != player)
        {
            return;
        }

        // 코인 수집이 승인되면 코인을 숨김
        if (session.TryCollect(coinId))
        {
            gameObject.SetActive(false);
        }
    }
}
