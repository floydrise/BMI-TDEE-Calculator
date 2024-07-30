/*
    1. Write entrance menue
        * ask whether they want to use BMI calculator or calories calculator

    2. Write logic for BMI calculator using this formula: BMI = weight(kg) / (height(metres) x height(metres))

    3. Write logic to calculate BMR (Basal Metabolic Rate) using this formula:
        Mifflin-St Jeor Equation (considered more accurate):
            For Men:

            BMR=(10×weight in kg)+(6.25×(height in meters×100))−(5×age in years)+5

            For women:
            BMR=(10×weight in kg)+(6.25×(height in meters×100))−(5×age in years)−161

    4. Adjust for activity level:
        * Sedentary (little or no exercise): BMR ×1.2
        * Lightly active (light exercise/sports 1-3 days/week): BMR ×1.375
        * Moderately active (moderate exercise/sports 3-5 days/week): BMR ×1.55
        * Very active (hard exercise/sports 6-7 days a week): BMR ×1.725
        * Super active (very hard exercise/physical job & exercise 2x/day): BMR ×1.9
        This gives you your Total Daily Energy Expenditure (TDEE), which is the number of calories you need to maintain your current weight.

    5. Adjust for weight goals:
        *To Maintain Weight: Consume calories equal to your TDEE.
        *To Lose Weight: Consume fewer calories than your TDEE. A common approach is to create a deficit of 500 calories per day to
        *lose approximately 0.45 kg (1 lb) per week.
        *To Gain Weight: Consume more calories than your TDEE. An additional 500 calories per day can help you gain approximately
        *0.45 kg (1 lb) per week.
*/

// * Main()
bool exit = true;
while (exit)
{
    Console.Clear();
    System.Console.WriteLine("Welcome to BMI/TDEE calculators!");
    System.Console.Write("Chose which calculator you want to use (BMI or TDEE): ");

    string? userInput = Console.ReadLine();
    if (userInput != null)
    {
        if (userInput == "BMI" || userInput.ToLower() == "bmi")
        {
            BMICalc();
            exit = Exit();
        }
        else
        {
            System.Console.Write("Choose gender (male/female): ");
            userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput.ToLower() == "male")
                {
                    BMRCalcMales();
                    exit = Exit();
                }
                else
                {
                    BMRCalcFemales();
                    exit = Exit();
                }
            }

        }
    }

}

// * Methods
void BMICalc()
{
    double bmiHeight = GetHeight();
    double bmiWeight = GetWeight();
    double bmiCalc = bmiWeight / Math.Pow(bmiHeight, 2);
    System.Console.WriteLine($"Your BMI is: {bmiCalc:F2}");
    System.Console.WriteLine();
}
void BMRCalcMales()
{
    double bmrHeight = GetHeight();
    double bmrWeight = GetWeight();
    int age = GetAge();
    System.Console.WriteLine();
    double bmrCalc = (10 * bmrWeight) + (6.25 * (bmrHeight * 100)) - (5 * age) + 5;
    System.Console.WriteLine($"Your BMR (Basal Metabolic Rate) is: {bmrCalc:F2}");
    System.Console.WriteLine();

    double sedentary = bmrCalc * 1.2;
    double lightlyActive = bmrCalc * 1.375;
    double moderatelyActive = bmrCalc * 1.55;
    double veryActive = bmrCalc * 1.725;
    double superActive = bmrCalc * 1.9;

    System.Console.WriteLine("Based on your activity level, you should be consuming this much calories:");
    System.Console.WriteLine($"\tSedentary (little or no exercise): {sedentary:F2}\n\tLightly active (light exercise/sports 1-3 days/week): {lightlyActive:F2}");
    System.Console.WriteLine($"\tModerately active (moderate exercise/sports 3-5 days/week): {moderatelyActive:F2}\n\tVery active (hard exercise/sports 6-7 days a week): {veryActive:F2}");
    System.Console.WriteLine($"\tSuper active (very hard exercise/physical job & exercise 2x/day): {superActive:F2}");
    System.Console.WriteLine();
}
void BMRCalcFemales()
{
    double bmrHeight = GetHeight();
    double bmrWeight = GetWeight();
    int age = GetAge();
    System.Console.WriteLine();
    double bmrCalc = (10 * bmrWeight) + (6.25 * (bmrHeight * 100)) - (5 * age) - 161;
    System.Console.WriteLine($"Your BMR (Basal Metabolic Rate) is: {bmrCalc:F2}");
    System.Console.WriteLine();

    double sedentary = bmrCalc * 1.2;
    double lightlyActive = bmrCalc * 1.375;
    double moderatelyActive = bmrCalc * 1.55;
    double veryActive = bmrCalc * 1.725;
    double superActive = bmrCalc * 1.9;

    System.Console.WriteLine("Based on your activity level, you should be consuming this much calories:");
    System.Console.WriteLine($"\tSedentary (little or no exercise): {sedentary:F2}\n\tLightly active (light exercise/sports 1-3 days/week): {lightlyActive:F2}");
    System.Console.WriteLine($"\tModerately active (moderate exercise/sports 3-5 days/week): {moderatelyActive:F2}\n\tVery active (hard exercise/sports 6-7 days a week): {veryActive:F2}");
    System.Console.WriteLine($"\tSuper active (very hard exercise/physical job & exercise 2x/day): {superActive:F2}");
    System.Console.WriteLine();
}
double GetHeight()
{
    Console.Write("Enter your height (metres): ");
    double height = Convert.ToDouble(Console.ReadLine());
    return height;
}
double GetWeight()
{
    Console.Write("Enter your weight (kg): ");
    double weight = Convert.ToDouble(Console.ReadLine());
    return weight;
}
int GetAge()
{
    System.Console.Write("Enter your age: ");
    int age = Convert.ToInt32(Console.ReadLine());
    return age;
}
bool Exit()
{
    System.Console.WriteLine("Do you want to continue or exit? ");
    string? userInput = Console.ReadLine();
    if (userInput == "continue")
    {
        return true;
    }
    return false;
}