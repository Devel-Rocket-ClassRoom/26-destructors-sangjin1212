using System;

// 메인 코드
Monster m1 = new Monster("슬라임");
Monster m2 = new Monster("고블린");
Monster m3 = new Monster("오크");

Console.WriteLine();
Monster.ShowStats();
Console.WriteLine();

// 모든 몬스터 제거
m1 = null;
m2 = null;
m3 = null;

GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine();
Monster.ShowStats();

class Monster
{
    private static int s_totalCount = 0;
    private static int s_aliveCount = 0;

    private int _id;
    private string _name;

    public Monster(string name)
    {
        s_totalCount++;
        s_aliveCount++;
        _id = s_totalCount;
        _name = name;
        Console.WriteLine($"몬스터 생성: {_name} (ID: {_id})");
        Console.WriteLine($"  - 현재 생존: {s_aliveCount}마리");
    }

    ~Monster()
    {
        s_aliveCount--;
        Console.WriteLine($"몬스터 소멸: {_name} (ID: {_id})");
        Console.WriteLine($"  - 현재 생존: {s_aliveCount}마리");
    }

    public static void ShowStats()
    {
        Console.WriteLine($"총 생성: {s_totalCount}, 현재 생존: {s_aliveCount}");
    }
}