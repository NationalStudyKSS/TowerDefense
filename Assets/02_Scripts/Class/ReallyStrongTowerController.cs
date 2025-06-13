using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReallyStrongTowerController : TowerController
{
    protected override void Start()
    {
        base.Start();
        _attackPower *= 3;  // 예: 기본 공격력 2배
        _attackSpan *= 0.5f; // 예: 더 빠르게 공격
    }

    protected override void Update()
    {
        // 특별한 타워 로직이 있으면 여기에 작성
        base.Update();
    }
}
