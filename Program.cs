// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Account account = new()
{
    Name = "Mohamed Fazrin Mohamed Farook",
    Email = "mfmfazrin1986@gmail.com",
    Phone = "+94772049123",
    Address = "No 1, Jalan 1, Taman 1, 12345, Kuala Lumpur, Malaysia"
};

await account.Deposit(5000);

Console.WriteLine($"Account Name: {account.Name}");
Console.WriteLine($"Account Email: {account.Email}");
Console.WriteLine($"Account Phone: {account.Phone}");
Console.WriteLine($"Account Address: {account.Address}");
Console.WriteLine($"Account Balance: {account.Balance}");

Console.WriteLine("Enter the amount to Withdraw: ");

var amount = Console.ReadLine();

await account.Withdraw(Convert.ToInt64(amount));

Console.WriteLine($"New Account Balance After Withdrawal: {account.Balance}");


public class Account
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    private long AccountBalance { get; set; }

    public async Task Deposit(long amount)
    {
        var semaphore = new SemaphoreSlim(1, 1);
        try
        {
            await semaphore.WaitAsync();
            AccountBalance += amount;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            semaphore.Release();
        }
    }
    
    public async Task Withdraw(long amount)
    {
        var semaphore = new SemaphoreSlim(1, 1);
        try
        {
            await semaphore.WaitAsync();
            AccountBalance -= amount;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            semaphore.Release();
        }
    }
    
    public long Balance => AccountBalance;
}