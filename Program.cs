using System;
using ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = new Employee[3];
        int employeesCounter = 1;
        employees[0] = new Employee(1812, "Adham", 20, 700, 10000, Gender.Male, new HiringDate(10, 10, 2024), SecurityLevel.Admin);
        employees[1] = new Employee(1505, "Marwa", 22, 400, 12000, Gender.Female, new HiringDate(1, 9, 2024), SecurityLevel.Officer);
        //employees[2] = new Employee(1711, "Nano", 23, 900, 15000, Gender.Female, new HiringDate(16, 10, 2024), SecurityLevel.HR);
        //Console.WriteLine(employees[0].ToString());

        while (true)
        {
            Console.Clear(); 
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Sort Employees");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee(employees, employeesCounter);
                    break;
                case "2":
                    PrintEmployees(employees);
                    break;
                case "3":
                    SortEmployees(employees);
                    break;
                case "4":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }

    // Add Employee
    static void AddEmployee(Employee[] employees, int counter)
    {
        counter++;
        employees[counter] = new Employee();

        Console.WriteLine("\nEnter details for the new employee:");

        // read ID
        int id;
        while (true)
        {
            Console.Write("Enter ID: ");
            if (int.TryParse(Console.ReadLine(), out id))
                break;
            else
                Console.WriteLine("Invalid input. Please enter a valid number for ID.");
        }


        // read Name
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();


        // read Age
        int age;
        while (true)
        {
            Console.Write("Enter Age (18 to 45): ");
            if (int.TryParse(Console.ReadLine(), out age) && age >= 18 && age <= 45)
                break;
            else
                Console.WriteLine("Invalid age. Age must be between 18 and 45.");
        }

        // read Target
        int target;
        while (true)
        {
            Console.Write("Enter Target (greater than 300): ");
            if (int.TryParse(Console.ReadLine(), out target) && target > 300)
                break;
            else
                Console.WriteLine("Invalid target. Target must be greater than 300.");
        }


        // read Salary
        float salary;
        while (true)
        {
            Console.Write("Enter Salary (between 6000 and 20000): ");
            if (float.TryParse(Console.ReadLine(), out salary) && salary >= 6000 && salary <= 20000)
                break;
            else
                Console.WriteLine("Invalid salary. Salary must be between 6000 and 20000.");
        }


        // read Gender
        Gender gender;
        while (true)
        {
            Console.Write("Enter Gender (Male/Female): ");
            string genderInput = Console.ReadLine();
            if (genderInput.Equals("Male", StringComparison.OrdinalIgnoreCase))
            {
                gender = Gender.Male;
                break;
            }
            else if (genderInput.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                gender = Gender.Female;
                break;
            }
            else
                Console.WriteLine("Invalid input. Please enter 'Male' or 'Female'.");
        }

        // Read Hiring Date
        int day, month, year;
        while (true)
        {
            Console.Write("Enter Hiring Day: ");
            if (int.TryParse(Console.ReadLine(), out day) && day > 0 && day <= 31)
                break;
            else
                Console.WriteLine("Invalid day. Please enter a valid day (1-31).");
        }

        while (true)
        {
            Console.Write("Enter Hiring Month: ");
            if (int.TryParse(Console.ReadLine(), out month) && month > 0 && month <= 12)
                break;
            else
                Console.WriteLine("Invalid month. Please enter a valid month (1-12).");
        }

        while (true)
        {
            Console.Write("Enter Hiring Year: ");
            if (int.TryParse(Console.ReadLine(), out year) && year > 1900 && year < 2025)
                break;
            else
                Console.WriteLine("Invalid year. Please enter a valid year.");
        }

        HiringDate hireDate = new HiringDate(day, month, year);


        // read Security Level
        SecurityLevel securityLevel;
        while (true)
        {
            Console.Write("Enter Security Level (Admin/HR/Officer): ");
            string securityLevelInput = Console.ReadLine();
            if (Enum.TryParse(securityLevelInput, true, out securityLevel))
                break;
            else
                Console.WriteLine("Invalid input. Please enter 'Admin', 'HR', or 'Officer'.");
        }


        // Finally push the new Employee
        employees[counter] = new Employee(id, name, age, target, salary, gender, hireDate, securityLevel);
        Console.WriteLine($"Employee {name} added successfully!");
    }

    // Print Employees
    static void PrintEmployees(Employee[] employees)
    {
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee.ToString());
            Console.WriteLine();
        }
    }

    // Sort Employees
    static void SortEmployees(Employee[] employees)
    {
        Array.Sort(employees);

        Console.WriteLine("Employees are Sorted...");
    }
}