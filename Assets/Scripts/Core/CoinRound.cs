
using System;
using System.Collections.Generic;

public sealed class CoinRound
{
    private readonly HashSet<int> collectedIds = new HashSet<int>();

    public int Score { get; private set; }
    public float Remaining { get; private set; }

    public bool IsFinished => Remaining <= 0f;

    public CoinRound(float seconds)
    {
        Reset(seconds);
    }

    public bool TryCollect(int coinId)
    {
        // 이미 수집한 코인이거나 게임이 종료되었다면 수집 거절
        if (IsFinished || !collectedIds.Add(coinId))
        {
            return false;
        }

        Score += 1;

        return true;
    }

    public void Tick(float deltaTime)
    {
        // 잘못된 경과 시간 입력 방지
        if (deltaTime < 0f || float.IsNaN(deltaTime) || float.IsInfinity(deltaTime))
        {
            throw new ArgumentOutOfRangeException(nameof(deltaTime));
        }

        // 남은 시간 감소 (최소 0초)
        Remaining = Math.Max(0f, Remaining - deltaTime);
    }

    public void Reset(float seconds)
    {
        if (seconds <= 0f || float.IsNaN(seconds) || float.IsInfinity(seconds))
        {
            throw new ArgumentOutOfRangeException(nameof(seconds));
        }

        // 게임 재시작 시 기록 초기화
        collectedIds.Clear();
        Score = 0;
        Remaining = seconds;
    }
}

