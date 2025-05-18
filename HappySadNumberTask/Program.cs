namespace HappySadNumberTask
{
    internal class Program
    {
        static bool IsHappyNumber(int num)
    {
        //floyd cycle detection its more efficient space wise than hash set lookups
        int slow = num, fast = num;
        do
        {
            slow = GetSumOfSquares(slow); // Moves one step
            fast = GetSumOfSquares(GetSumOfSquares(fast)); // Moves two steps
        }
        while (slow != fast); // Detects cycle
        return slow == 1;
    }
    static int GetSumOfSquares(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            int digit = num % 10;
            sum += digit * digit;
            num /= 10;
        }
        return sum;
    }
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        if (IsHappyNumber(num)){
            Console.WriteLine($"{num} is a Happy Number!");
        } else {
            Console.WriteLine($"{num} is a Sad Number!");
        }

        Console.WriteLine("Testing with 19 and 20:");
        Console.WriteLine(19 + " -> " + (IsHappyNumber(19) ? "Happy" : "Sad"));
        Console.WriteLine(20 + " -> " + (IsHappyNumber(20) ? "Happy" : "Sad"));
    }
    }
}
