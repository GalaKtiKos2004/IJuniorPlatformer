public class Wallet
{
    private uint _money = 0;

    public void AddCoin()
    {
        _money++;
    }

    public void TrySpendMoney(uint money)
    {
        if (money < _money) 
            _money -= money;
    }
}
