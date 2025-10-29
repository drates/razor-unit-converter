using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorStarterProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public string Result { get; set; }

    public void OnPost()
    {
    if (!double.TryParse(InputValue, out double value) || value <= 0)
    {
        Result = "Invalid input. Please enter a numeric value greater than zero.";
        return;
    }

    Result = UnitType switch
    {
        "length" => $"{value} inches = {LengthConversion(value):F2} meters",
        "temperature" => $"{value} °F = {TempConversion(value):F2} °C",
        _ => "Unknown conversion type."
    };
}

        [BindProperty]
    public string InputValue { get; set; }

    [BindProperty]
    public string UnitType { get; set; }

    private double LengthConversion(double inputInches)
{
    return inputInches * 0.0254;
}

private double TempConversion(double inputF)
{
    return (inputF - 32.00) * (5.00 / 9.00);
}


}



