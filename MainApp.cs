using System;
using System.Collections.Generic;


/*
변경불가능 객체: 상태(속성)의 변화를 허용하지 않는 객체
변경불가능 구조체: 모든 필드와 프로퍼티의 값을 수정할 수 없는 구조체.
구조체를 선언할 때 readonly 키워드만 기입하면 됨.

 */


namespace ReadonlyStruct
{
    readonly struct Transaction // readonly 키워드
    {
        public Transaction(string from, string to, int amount)
        {
            transactionId = Guid.NewGuid();
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public readonly Guid transactionId; // readonly로 선언된 구조체 안에서는 모든 필드와 프로퍼티가 readonly 키워드로 선언돼야 함.
        public readonly string from;
        public readonly string to;
        public readonly int amount;
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction("Alice", "Bob", 100));
            transactions.Add(new Transaction("Alice", "Charlie", 50));
            transactions.Add(new Transaction("Bob", "Charlie", 20));
            transactions.Add(new Transaction("Dave", "Alice", 40));

            int revenue = 0;
            int expense = 0;
            foreach (var t in transactions)
            {
                if (t.from == "Alice")
                    revenue += t.amount;
                else if (t.to == "Alice")
                    expense += t.amount;
            }

            Console.WriteLine($"Alice's profit : {revenue - expense}");
        }
    }
}