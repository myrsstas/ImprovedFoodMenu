namespace Exercise1._16_Myrsini_Stasinou;

/*
 * Άσκηση 1.16
Τροποποιήστε την εφαρμογή φαγητού ως εξής:
       * Δημιουργήστε ένα interface με όνομα “IFood” το οποίο θα περιλαμβάνει ένα string property
με όνομα “FoodTitle” και ένα int property με όνομα “OptionNumber”.
       * Δημιουργήστε μία κλάση για το κάθε φαγητό του μενού, η οποία θα υλοποιεί το συγκεκριμένο interface.
       * Αλλάξτε το array των επιλογών ώστε να περιέχει όλα αυτά τα αντικείμενα φαγητού, που υλοποιούν το interface “IFood”.
       * Το array με τις επιλογές φαγητού πρέπει να έρχεται από άλλη κλάση, από μέθοδο που να λέγεται “GetMenuItems”.
       * Αντικαταστήστε τις κλήσεις της Int32.TryParse με Convert.ToInt32. Δεν πρέπει να υπάρχει πουθενά
κλήση της Int32.TryParse
       * Φροντίστε, με το κατάλληλο error handling, η εφαρμογή να λειτουργεί κανονικά. Σε περίπτωση exception, να δείχνει ένα κατάλληλο μήνυμα στον χρήστη και να μην έχει crash.
       * Η εφαρμογή πρέπει να μην τερματίζει, εκτός και αν ο χρήστης το επιλέξει.
 */

class Program
{
    static void Main(string[] args)
    {
        ShowMenu.GetMenuItems();
    }
}

public interface IFood
{
    string FoodTitle { get; set; }
    int OptionNumber { get; set; }

    IFood SetFood();
}

class Spaghetti : IFood
{
    public string FoodTitle { get; set; }
    public int OptionNumber { get; set; }

    public IFood SetFood()
    {
        FoodTitle = "Spaghetti";
        OptionNumber = 1;
        return this;
    }
}

class Pizza : IFood
{
    public string FoodTitle { get; set; }
    public int OptionNumber { get; set; }

    public IFood SetFood()
    {
        FoodTitle = "Pizza";
        OptionNumber = 2;
        return this;
    }
}

class Steak : IFood
{
    public string FoodTitle { get; set; }
    public int OptionNumber { get; set; }

    public IFood SetFood()
    {
        FoodTitle = "Steak";
        OptionNumber = 3;
        return this;
    }
}

class ExitMenu : IFood
{
    public string FoodTitle { get; set; }
    public int OptionNumber { get; set; }

    public IFood SetFood()
    {
        FoodTitle = "Exit";
        OptionNumber = 0;
        return this;
    }
}

class ShowMenu
{
    public static IFood[] SetMenuItems()
    {
        IFood spaghetti = new Spaghetti();
        IFood pizza = new Pizza();
        IFood steak = new Steak();
        IFood exitMenu = new ExitMenu();
        IFood[] foodMenu =
        [
            spaghetti.SetFood(),
            pizza.SetFood(),
            steak.SetFood(),
            exitMenu.SetFood()
        ];

        return foodMenu;
    }

    public static void GetMenuItems()
    {
        Console.WriteLine("Welcome to our New and Improved Menu!");
        IFood[] foodMenu = SetMenuItems();
        foreach (IFood food in foodMenu)
        {
            Console.WriteLine($"For {food.FoodTitle} : Press {food.OptionNumber}");
        }

        UserSelectionInput.ReadUserInput(foodMenu);
    }

    public static void GetTheItemTheUserAsked(int userInput, IFood[] foodMenu)
    {
        switch (userInput)
        {
            case 1:
                Console.WriteLine($"You selected {foodMenu[0].FoodTitle}");
                break;
            case 2:
                Console.WriteLine($"You selected {foodMenu[1].FoodTitle}");
                break;
            case 3:
                Console.WriteLine($"You selected {foodMenu[2].FoodTitle}");
                break;
            case 0:
                Console.WriteLine($"You want to {foodMenu[3].FoodTitle} the application. Bye bye!");
                break;
            default:
                Console.WriteLine("You haven't entered a valid number, please try again.");
                UserSelectionInput.ReadUserInput(foodMenu);
                break;
        }
    }
}

class UserSelectionInput
{
    public static void ReadUserInput(IFood[] foodMenu)
    {
        try
        {
            int userInput = Convert.ToInt32(Console.ReadLine());
            ShowMenu.GetTheItemTheUserAsked(userInput, foodMenu);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("You haven't entered a valid number, please try again.");
            ReadUserInput(foodMenu);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong - {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Thank you for dining with us!");
        }
    }
}