namespace SIMS
{
    public class SIMS
    {
        private Inventory MyInventory;
        private bool active;
        public SIMS() 
        {
            MyInventory = new Inventory();
            active = true;
        }

        public void Main()
        {
            Console.WriteLine("Welcome to The Simple Inventory Management System!");
            Console.WriteLine();

           
            do
            {
                Menu.DisplayMainMenu();

                char choice = Console.ReadKey().KeyChar;
                DoWork(choice);

            } while (active);

            
            Console.WriteLine("See Ya!Bye!");
            Console.ReadLine();
        }

        private void DoWork(char choice)
        {
            Console.Clear();

            switch (choice) 
            {
                case '1':
                    Tuple<string, int, double> info = InputManager.GetFullInfo();

                    if (MyInventory.AddProduct(info.Item1, info.Item2, info.Item3))
                        Console.WriteLine("Added successfully");
                    else
                        Console.WriteLine("The Product already exists");

                    break;


                case '2':
                    MyInventory.ViewAllProducts();

                    break;



                case '3':

                    Console.WriteLine("Enter The Name of the product you wanna edit");

                    string name = InputManager.GetName();
                    int idx = MyInventory.Find(name);
                    if (idx == -1)
                        Console.WriteLine("The name of the product does not exist!!!!");
                    else
                    {
                        Tuple<string, int, double> EditedInfo = GetEditedInfo();
                        MyInventory.EditProduct(EditedInfo.Item1, EditedInfo.Item2, EditedInfo.Item3, idx);
                    }

                    break;


                case '4':
                    Console.WriteLine("Enter The Name of the product you wanna delete");

                    name = InputManager.GetName();
                    if (!MyInventory.RemoveProduct(name))
                        Console.WriteLine("The name of the product does not exist!!!!");
                    else
                        Console.WriteLine("Deleted Successfully");

                    break;


                case '5':
                    Console.WriteLine("Enter The Name of the product you wanna search for");

                    name = InputManager.GetName();
                    MyInventory.SearchForProduct(name);

                    break;



                case '6':

                    Console.Clear();
                    active = false;
                break;


                default:
                    Console.WriteLine("Invalid Choice");
                break;

            }
        }

        private Tuple<string, int, double> GetEditedInfo()
        {
            string name = "";
            int quantity = -1;
            double price = -1;


            char choice = '0';
            do
            {
                Menu.DisplayEditMenu();
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        name = InputManager.GetName();
                    break;

                    case '2':
                        price = InputManager.GetPrice();
                    break;

                    case '3':
                        quantity = InputManager.GetQuantity();
                    break;

                    case '0':
                    break;

                    default:
                        Console.WriteLine("Invalid Choice");
                    break;
                }
            } while (choice != '0');


            return Tuple.Create(name, quantity, price);
        }
    }
}