using Newtonsoft.Json;

namespace Currnverter;

public partial class CurrnencyConverterPage : ContentPage
{
    private string currencyFrom;
    private string currencyTo;
    List<Currency> CurrencyList = new List<Currency>()
	{
        new Currency(){Name = "US Dollar", Code = "USD"},
        new Currency(){Name = "Algerian Dinar", Code = "DZD"},
        new Currency { Name = "Euro", Code = "EUR" },
        new Currency { Name = "Japanese Yen", Code = "JPY" },
        new Currency { Name = "British Pound", Code = "GBP" },
        new Currency { Name = "Swiss Franc", Code = "CHF" },
        new Currency { Name = "Canadian Dollar", Code = "CAD" },
        new Currency { Name = "Australian Dollar", Code = "AUD" },
        new Currency { Name = "New Zealand Dollar", Code = "NZD" },
        new Currency { Name = "Chinese Yuan", Code = "CNY" },
        new Currency { Name = "Hong Kong Dollar", Code = "HKD" },
        new Currency { Name = "Singapore Dollar", Code = "SGD" },
        new Currency { Name = "South Korean Won", Code = "KRW" },
        new Currency { Name = "Indian Rupee", Code = "INR" },
        new Currency { Name = "Russian Ruble", Code = "RUB" },
        new Currency { Name = "Brazilian Real", Code = "BRL" },
        new Currency { Name = "Mexican Peso", Code = "MXN" },
        new Currency { Name = "South African Rand", Code = "ZAR" }
    };
	public CurrnencyConverterPage()
	{
		InitializeComponent();
        PickerFrom.ItemsSource = CurrencyList;
        PickerTo.ItemsSource = CurrencyList;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("apikey", "bFUjiM2ssn7KMmiOtcQYh5hxP0czYs0d");
        var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={currencyTo}&from={currencyFrom}&amount={EntAmount.Text}");
        var currencyResult = JsonConvert.DeserializeObject<Root>(response);
        LblResult.Text = Math.Round(currencyResult.Result,2) + currencyTo;
    }

    private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerFrom.SelectedItem as Currency;
        currencyFrom = selectedItem.Code;
    }

    private void PickerTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerTo.SelectedItem as Currency;
        currencyTo = selectedItem.Code;
    }
}