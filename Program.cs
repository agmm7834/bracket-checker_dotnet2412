using System;
using System.Collections.Generic;

class Program
{
    static bool QavslarniTekshir(string matn)
    {
        Stack<char> stek = new Stack<char>();
        Dictionary<char, char> juftlar = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        
        foreach (char belgi in matn)
        {
            if (belgi == '(' || belgi == '[' || belgi == '{')
            {
                stek.Push(belgi);
            }
            else if (belgi == ')' || belgi == ']' || belgi == '}')
            {
                if (stek.Count == 0 || stek.Pop() != juftlar[belgi])
                {
                    return false;
                }
            }
        }
        
        return stek.Count == 0;
    }
    
    static void Main(string[] args)
    {
        string[] testMisollar = {
            "([we]}",
            "()",
            "()[]{}",
            "(]",
            "([)]",
            "{[]}",
            "((()))",
            "(()",
            "hello(world)",
            "{a[b(c)d]e}",
            ""
        };
        
        Console.WriteLine("".PadRight(50, '='));
        Console.WriteLine("QAVSLARNI TEKSHIRISH DASTURI");
        Console.WriteLine("".PadRight(50, '='));
        Console.WriteLine();
        
        foreach (string matn in testMisollar)
        {
            bool natija = QavslarniTekshir(matn);
            string holat = natija ? "✓ To'g'ri" : "✗ Noto'g'ri";
            Console.WriteLine($"{matn,-20} → {holat}");
        }
        
        Console.WriteLine();
        Console.WriteLine("".PadRight(50, '='));
        Console.WriteLine("\nO'zingizning matnni kiriting:");
        Console.Write("Matn: ");
        string foydalanuvchiMatni = Console.ReadLine();
        bool natija2 = QavslarniTekshir(foydalanuvchiMatni);
        
        if (natija2)
        {
            Console.WriteLine("✓ Qavslar to'g'ri ochilgan va yopilgan!");
        }
        else
        {
            Console.WriteLine("✗ Qavslar noto'g'ri!");
        }
    }
}
