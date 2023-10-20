

using System.Text.Json;

namespace canil.Models;

public class PetShop
{
    public string Name { get; set; }
    
    public decimal SmallDogsPrice { get; set; }

    public decimal LargeDogsPrice { get; set; }

    public decimal Distance { get; set; }

    public bool HasIncreaseOnWeekends { get; set; }

    public decimal WeekendSmallDogsPrice { get; set; }

    public decimal WeekendLargeDogsPrice { get; set; }

    public PetShop(string name, decimal smPrice, decimal lgPrice, decimal distance)
    {
        Name = name;
        SmallDogsPrice = smPrice;
        LargeDogsPrice = lgPrice;
        Distance = distance;
        HasIncreaseOnWeekends = false;
        WeekendSmallDogsPrice = 0.0M;
        WeekendLargeDogsPrice = 0.0M;
    }

    public PetShop(string name, decimal smPrice, decimal lgPrice, decimal wkndSmDogsPrice, decimal wkndLgDogsPrice ,decimal distance)
    {
        Name = name;
        SmallDogsPrice = smPrice;
        LargeDogsPrice = lgPrice;
        Distance = distance;
        HasIncreaseOnWeekends = true;
        WeekendSmallDogsPrice = wkndSmDogsPrice;
        WeekendLargeDogsPrice = wkndLgDogsPrice;
    }

    public decimal Calculate(int smallDogsQuantity, int largeDogsQuantity, bool isWeekendDay)
    {
        if(isWeekendDay && HasIncreaseOnWeekends)
        {
            return (smallDogsQuantity * WeekendSmallDogsPrice) + (largeDogsQuantity * WeekendLargeDogsPrice);
        }

        return (smallDogsQuantity * SmallDogsPrice) + (largeDogsQuantity * LargeDogsPrice);
    }
}