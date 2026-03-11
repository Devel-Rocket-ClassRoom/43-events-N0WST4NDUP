using System;

public class AutoBuyer
{
    public void ItemEmpty(string name, int _, int newCount)
    {
        if (newCount == 0)
        {
            Console.WriteLine($"[자동구매] {name} 재고 소진! 자동 구매 요청");
        }
    }
}