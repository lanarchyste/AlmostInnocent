using Almost_Innocent.Scenarios;
using System.Text.RegularExpressions;

Regex regexScenario = new("^[1-7]{1}$");

Console.Clear();
Console.WriteLine("--- ALMOST INNOCENT ---");
Console.Write("Choisissez un scénario [1-7] : ");

var scenario = ChooseScenario();
scenario.Launch();

IScenario ChooseScenario()
{
    var scenario = Console.ReadLine();

    if (string.IsNullOrEmpty(scenario) || !regexScenario.IsMatch(scenario))
        ChooseNotUnderstood();

    return scenario switch
    {
        "7" => Scenario7.Setup(),
        "6" => Scenario6.Setup(),
        "5" => Scenario5.Setup(),
        "4" => Scenario4.Setup(),
        "3" => Scenario3.Setup(),
        "2" => Scenario2.Setup(),
        "1" => Scenario1.Setup(),
        _ => ChooseNotUnderstood(),

    };
}

IScenario ChooseNotUnderstood()
{
    Console.Write("Je n'ai pas compris votre choix ! ");
    return ChooseScenario();
}