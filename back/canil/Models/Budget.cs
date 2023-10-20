using System.Text.Json;

namespace canil.Models;

public class Budget
{
    public PetShop PetShop { get; set; }

    public decimal Price { get; set; }

    public Budget(PetShop petShop, decimal price) {
        PetShop = petShop;
        Price = price;
    }
}