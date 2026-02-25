using System;
Seat s1 = new Seat("김민수");
Seat s2 = new Seat("이지영");
Seat s3 = new Seat("박서준");
s1.Study();
s2.Study();
s3.Study();
Seat.ShowStatus();

s1 = null;
s2 = null;
s3 = null;

GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine();
Seat.ShowStatus();
class Seat
{
    string name;
    int id;
    
    static int totalCount = 0;
    static int aliveCount = 0;
    public Seat(string name)
    {
        aliveCount++;
        totalCount++;
        id = totalCount;
        this.name = name;
        Console.WriteLine($"좌석{id} 착석: {name}");
    }
    public void Study()
    {
        Console.WriteLine($"{name}이(가) 좌석{id}에서 공부중...");
    }

    ~Seat()
    {
        aliveCount--;
        Console.WriteLine($"좌석 {aliveCount}번 반납: {name}");

    }
    public static void ShowStatus()
    {
        Console.WriteLine($"총 이용:{totalCount}명, 현재 착석:{aliveCount}명");
    }
}