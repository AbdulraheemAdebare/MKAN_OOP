using MKAN;

public class Khaddim : Member
{
    public string? MkanID { get; set; }
    private List<Khaddim> Admin { get; set; } = new List<Khaddim>();
    private List<Khaddim> Members {get; set;} = new List<Khaddim>();

    readonly Random random = new();
    public Khaddim(string fullName, string memberNo, string jamaat, string circuit)
    {
        FullName = fullName;
        MemberNo = memberNo;
        Jamaat = jamaat;
        Circuit = circuit;
        Id = random.Next(1, 100);
        MkanID = GenerateMkanID();
    }
    public Khaddim()
    {
        Admin = [
            new("Moshood Nasirudeen", "3456", "FolaTyre", "Oyo"),
            new("Folarin Muh. Fath", "2345", "Agunpopo", "Oyo"),
            new("Abdulsalam AbdulQahar", "1231", "Pakoyi", "Oyo")
        ];
        Members = new List<Khaddim>{
            new("Abdulraheem Ibraheem", "1235", "Pakoyi", "Oyo"),
            new("Abdulraheem Adebare", "1234", "Pakoyi", "Oyo"),
            new("Abdulganiyy AbdulMuiz", "3457", "Folatyre", "Oyo"),
            new("Hamzat AbdulMuiz", "2348", "Agunpopo", "Oyo"),
            
        };
         using StreamWriter writeMemeber = new("Members.txt");
        writeMemeber.WriteLine($"{Members}");
        writeMemeber.WriteLine($"{Admin}");
    }

    private string GenerateMkanID()
    {
        return $"MK{random.Next(1, 5000)}";
    }

    public  void CreateKhaddim()
    {
        Console.Clear();
        Console.WriteLine("Enter Khaddim Name:");
        string? Name = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Membership Number:");
        string? memberNo = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Jama'at:");
        string? jamaat = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Circuit:");
        string? circuit = Console.ReadLine();

        var khaddim = new Khaddim(Name!, memberNo!, jamaat!, circuit!);
        Members.Add(khaddim);
        Console.WriteLine($"khaddim with name; {Name} created sucessfully. Your MkanID is: {khaddim.MkanID} ");
        using StreamWriter writeMemeber = new("Members.txt");
        writeMemeber.WriteLineAsync($"{Name} {memberNo} {jamaat} {circuit} {MkanID}");
    }
    public void GetAllKhuddam()
    {
        Console.Clear();
        Console.WriteLine("======ALL MEMBERSHIP DATA======");
        foreach (var khaddim in Admin)
        {   
            Console.WriteLine($"MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit} => ADMIN");
            
        }
        foreach(var khaddim in Members)
        {
            Console.WriteLine($"MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit} => Member \n");
        }
        Console.WriteLine("........ \nPress any key to continue()");
        Console.ReadKey();
        Console.Clear();
    }
   
    public void UpdateMember()
    {
        Console.Clear();
        Console.WriteLine("Enter Your Membership number or Mkan ID");
        var id = Console.ReadLine();

        if(id is null || id == "")
        {
            Console.WriteLine("You must input a valid memebership number or Mkan ID");
            id = Console.ReadLine();
        }
        else
        {
            Console.Clear();
            var member = new Khaddim();
            foreach (var khaddim in Members)
            {
                if(khaddim.MemberNo == id || khaddim.MkanID == id)
                {
                    member.MkanID = khaddim.MkanID;

                    Console.WriteLine($"Your Previous Data... \n MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit}");
                    Members.Remove(member);
                }
                
            }
            
            Console.WriteLine("Enter your New Data \n =>Enter Khaddim Name:");
            string? _Name = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Membership Number:");
            string? _memberNo = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Jama'at:");
            string? _jamaat = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Circuit:");
            string? _circuit = Console.ReadLine();
            member.FullName = _Name!;
            member.Jamaat = _jamaat!;
            member.MemberNo = _memberNo!;
            member.Circuit = _circuit!;
            Members.Add(member);

            Console.WriteLine($"Data Updated successfully... \nYour MkanID is: {member.MkanID} \n........ \nPress any key to continue()");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void UpdateAdmin()
    {
        Console.WriteLine("=>Enter Your Membership number or Mkan ID");
        var id = Console.ReadLine();

        if(id == null || id == "")
        {
            Console.WriteLine("You must input a valid memebership number or Mkan ID \n=>Re-enter your Membership Number or Mkan ID:");
            id = Console.ReadLine();

        }
        else
        {
             Console.Clear();
            var member = new Khaddim();
            foreach (var khaddim in Admin)
            {
                if(khaddim.MemberNo == id || khaddim.MkanID == id)
                {
                    member.MkanID = khaddim.MkanID;

                    Console.WriteLine($"Your Previous Data... \n MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit}");
                    Admin.Remove(member);
                }
                
            }
           
            Console.WriteLine("Enter your New Data \n =>Enter Khaddim Name:");
            string? _Name = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Membership Number:");
            string? _memberNo = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Jama'at:");
            string? _jamaat = Console.ReadLine();
            Console.WriteLine("Enter Khaddim Circuit:");
            string? _circuit = Console.ReadLine();
            member.FullName = _Name!;
            member.Jamaat = _jamaat!;
            member.MemberNo = _memberNo!;
            member.Circuit = _circuit!;
            Admin.Add(member);

            
            
            Console.WriteLine($"Data Updated successfully... \nYour MkanID is: {member.MkanID} \n........ \nPress any key to continue()");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void DeleteMember()
    {
        Console.Clear();
        Console.WriteLine("Enter the MKAN ID of the member you wish to delete below...");
        Console.Write("=>Enter Member's MKAN ID:");
        var id = Console.ReadLine();
        if(id == null || id == "")
        {
            Console.WriteLine("Sorry, You couldn't delete this member as He does not exist! \n Check your input and enter a correct one...");
            Console.Write("=>Re-enter MKAN ID:");
            id = Console.ReadLine();
        }
        else
        {
            foreach(var kha in Members)
            {
                if(kha.MkanID == id)
                {
                
                    Members.Remove(kha);
                    Console.WriteLine($"Member ({kha.FullName}) deleted successfully... \n........ \nPress any key to continue()");
                    Console.ReadKey();
            Console.Clear();
                    break;
                }
            }
            
        }
    }
    public void DeleteAdmin()
    {
        Console.Clear();
        Console.WriteLine("Enter the MKAN ID of the member you wish to delete below...");
        Console.Write("=>Enter Member's MKAN ID:");
        var id = Console.ReadLine();
        if(id == null || id == "")
        {
            Console.WriteLine("Sorry, You couldn't delete this member as He does not exist! \n Check your input and enter a correct one...");
            Console.Write("=>Re-enter MKAN ID:");
            id = Console.ReadLine();
        }
        else
        {
            foreach(var kha in Admin)
            {
                if(kha.MkanID == id)
                {
                
                    Admin.Remove(kha);
                    Console.WriteLine($"Admin ({kha.FullName}) deleted successfully... \n........ \nPress any key to continue()");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            
        }
    } 

    public void SpecialFunctions()
    {
        Console.Clear();
        Console.WriteLine("Select an Option \n 1: Update an Admin. 2: Delete an Admin. #:Exit. ");
        string option = Console.ReadLine()!;
        Khaddim usable = new Khaddim();
        switch(option)
        {
            case "1":
            Console.Clear();
            usable.UpdateAdmin();
            break;
            case "2":
            Console.Clear();
            usable.DeleteAdmin();
            break;
            case "3":
            Console.Clear();
            break;
            default:
            Console.Clear();
            Console.Write("Please enter a correct value.");
            break;
        }
        
    }

    public void MemberMenu()
    {
        Khaddim usable = new Khaddim();
        bool run = true;
        while(run)
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("1: View All Member. 2: Add a new member. 3: View your info. #: Exit");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                usable.GetAllKhuddam();
                break;
                case "2":
                usable.CreateKhaddim();
                break;
                case "3":
                Console.WriteLine("Sorry, this function is currently not available... \nOur team is working on it. We will get you updated when it's available. \nJazakallah.");
                Console.ReadKey();
                Console.Clear();
                break;
                case "#":
                Console.WriteLine("Thanks for using the Mkan APP...\n\n==>Have you paid your Chanda this month? If not, kindly do so, now! \n\nJazakallah...");
                run = false;
                break;
                default:
                Console.Write("Please enter a correct value.");
                option = Console.ReadLine()!;
                break;
            }
            
        }
    }
    public void AdminMenu()
    {
        Khaddim usable = new Khaddim();
        bool run = true;
        while(run)
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("1: Add Member. \n2: Get All Member. \n3: Update Member. \n4: Delete Member. 5: Special Functions #: Exit");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                usable.CreateKhaddim();
                break;
                case "2":
                usable.GetAllKhuddam();
                break;
                case "3":
                usable.UpdateMember();
                break;
                case "4":
                usable.DeleteMember();
                break;
                case "5":
                usable.SpecialFunctions();
                break;
                case "#":
                run = false;
                break;
                default:
                Console.Write("Please enter a correct value.");
                option = Console.ReadLine()!;
                break;
            }
            
        }
    }

    public void HomePage()
    {
        Console.Clear();
        Console.Title = "HomePage";
        Console.WriteLine("========================= Welcome to the MKAN App HomePage =========================\n\n=> Enter 1 to sign up......\n\n Already a member? \n=>Enter 2 to sign in....");
        string choice = Console.ReadLine()!;
        Khaddim khad = new Khaddim();
        if(choice is "1")
        {
            Console.WriteLine("Sorry, this function is currently not available... \nOur team is working on it. We will get you updated when it's available. \n Enter 2 to sign in:");
            choice = Console.ReadLine()!;
        }
        else if(choice is "2")
        {
            khad.LoginPage();
        }
        else{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid input...");
            Console.ResetColor();
            choice = Console.ReadLine()!;
        }

    }

    public void LoginPage()
    {
        Console.Clear();
        Console.WriteLine("Enter your Membership Number:");
        string checkNumber = Console.ReadLine()!;
        if(checkNumber is null || checkNumber is ""){
            Console.WriteLine($"Member with the Membership Number {checkNumber} does not exist... \n=>Re-enter your MkanID:");
            checkNumber = Console.ReadLine()!;
        }
        else{
            foreach(var kha in Admin){
                if(checkNumber == kha.MemberNo){
                    Khaddim khad = new Khaddim();
                    Console.Clear();
                    Console.WriteLine("You are logged in as an Admin...");
                    khad.AdminMenu();
                    break;
                }
            }
            foreach(var kha in Members){
                if(checkNumber == kha.MemberNo){
                     Khaddim khad = new Khaddim();
                    Console.WriteLine("You are logged in as a Member...");
                    khad.MemberMenu();
                }
            }
        }
    }
}