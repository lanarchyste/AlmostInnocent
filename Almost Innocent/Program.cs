// See https://aka.ms/new-console-template for more information

//TODO: Poser en priorité une qestion de type dans une colonne/ligne ou le type existe !
//TODO: Lors de la réponse ne pas répéter ce qu'on dis

using Almost_Innocent.Scenarios;
using System.Text.RegularExpressions;

Regex regexScenario = new("^[1-5]{1}$");

Console.Write("Choisissez un scénario : ");

var scenario = ChooseScenario();
scenario.Launch();

IScenario ChooseScenario()
{
    var scenario = Console.ReadLine();

    if(string.IsNullOrEmpty(scenario) || !regexScenario.IsMatch(scenario))
    {
        Console.Write("Je n'ai pas compris votre choix ! ");
        return ChooseScenario();
    }

    return scenario switch
    {
        "5" => Scenario5.Setup(),
        "4" => Scenario4.Setup(),
        "3" => Scenario3.Setup(),
        "2" => Scenario2.Setup(),
        _ => Scenario1.Setup(),
    };
}