using System; //базовое пространсво имен
using System.Globalization; //региональные настройки (для типа флоат)
using System.Text; //для работы с текстом

static string CalculateCompoundInterest(decimal initialDeposit, int years, decimal interestRate)
{
    if (initialDeposit <= 0)
        throw new ArgumentOutOfRangeException(nameof(initialDeposit), "Вклад должен быть положительным.");
    if (years <= 0)
        throw new ArgumentOutOfRangeException(nameof(years), "Количество лет должно быть положительным.");
    if (interestRate <= 0)
        throw new ArgumentOutOfRangeException(nameof(interestRate), "Ставка должна быть положительной.");


    var result = new StringBuilder();
    decimal amount = initialDeposit;
    decimal multiplier = 1 + interestRate / 100m;

    for (int year = 1; year <= years; year++)
    {
        amount *= multiplier; // сложный процент: проценты начисляются на уже накопленную сумму

        result.Append($"Год {year}: {amount.ToString("F2", CultureInfo.InvariantCulture)} руб.");
        if (year < years)
            result.AppendLine();
    }

    return result.ToString();
}

// Проверка
Console.WriteLine(CalculateCompoundInterest(1000, 3, 10));

