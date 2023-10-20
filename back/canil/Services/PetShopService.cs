using canil.Models;
using Microsoft.AspNetCore.Mvc;

namespace canil.Services;

// Meu Canino Feliz: Está distante 2km do canil. Em dias de semana o banho para
// cães pequenos custa R$20,00 e o banho em cães grandes custa R$40,00.
// Durante os finais de semana o preço dos banhos é aumentado em 20%.
// ● Vai Rex: Está localizado na mesma avenida do canil, a 1,7km. O preço do banho
// para dias úteis em cães pequenos é R$15,00 e em cães grandes é R$50,00.
// Durante os finais de semana o preço para cães pequenos é R$ 20,00 e para os
// grandes é R$ 55,00.
// ● ChowChawgas: Fica a 800m do canil. O preço do banho é o mesmo em todos os
// dias da semana. Para cães pequenos custa R$30 e para cães grandes R$45,00.

public class PetShopService : ServiceCollection
{
    internal Budget getBestOption(int SmallDogsQuantity, int LargeDogsQuantity, string DateString)
    {
        if (!DateTime.TryParse(DateString, out DateTime Date))
        {
            throw new Exception("Invalid date string");
        }

        List<PetShop> Options = new()
        {
            new PetShop("Meu Canino Feliz", 20.0M, 40.0M, 24.0M, 48.0M, 2.0M),
            new PetShop("Vai Rex", 15.0M, 50.0M, 20.0M, 55.0M, 1.7M),
            new PetShop("ChowChawgas", 30.0M, 45.0M, 0.8M)
        };

        Options.Sort((shop1, shop2) => {
            decimal result1 = shop1.Calculate(SmallDogsQuantity, LargeDogsQuantity, IsWeekend(Date));
            decimal result2 = shop2.Calculate(SmallDogsQuantity, LargeDogsQuantity, IsWeekend(Date));

            if (result1 != result2)
            {
                return result1.CompareTo(result2);
            }
            else
            {
                return shop1.Distance.CompareTo(shop2.Distance);
            }
        });

        return new Budget(Options[0], Options[0].Calculate(SmallDogsQuantity, LargeDogsQuantity, IsWeekend(Date)));
    }

    internal bool IsWeekend(DateTime Date)
    {
        DayOfWeek WeekendDay = Date.DayOfWeek;
        return WeekendDay == DayOfWeek.Saturday || WeekendDay == DayOfWeek.Sunday;
    }
}