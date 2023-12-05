using MKAN;
namespace MKAN;

public class Khaddim : Member
{
    public string MkanID { get; set; }
    private List<Khaddim> Khuddam = new List<Khaddim>()
    {
        new Khaddim("Folarin Kehinde", "46584", "Agunpopo", "Oyo")
    };

    Random random = new Random();
    public Khaddim(string fullName, string memberNo, string jamaat, string circuit)
    {
        FullName = fullName;
        MemberNo = memberNo;
        Jamaat = jamaat;
        Circuit = circuit;
        Id = random.Next(1, 100);
        MkanID = GenerateMkanID();
    }
    public Khaddim(){}

    private string GenerateMkanID()
    {

        return $"MK{random.Next(1, 5000)}";
    }

    public void CreateKhaddim()
    {
        Console.WriteLine("Enter Khaddim Name:");
        string? Name = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Membership Number:");
        string? memberNo = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Jama'at:");
        string? jamaat = Console.ReadLine();
        Console.WriteLine("Enter Khaddim Circuit:");
        string? circuit = Console.ReadLine();

        var khaddim = new Khaddim(Name!, memberNo!, jamaat!, circuit!);
        Khuddam.Add(khaddim);
        Console.WriteLine($"khaddim with name; {Name} created sucessfully. Your MkanID is: {khaddim.MkanID} ");
    }
    public void GetAllKhuddam()
    {
        Console.WriteLine("======ALL MEMBERSHIP DATA======");
        foreach (var khaddim in Khuddam)
        {
            Console.WriteLine($"MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit}");
        }
    }

    public void UpdateKhaddim()
    {
        Console.WriteLine("Enter Your Membership number or Mkan ID");
        var id = Console.ReadLine();

        if(id == null || id == "")
        {
            Console.WriteLine("You must input a valid memebership number or Mkan ID");
        }
        else
        {
            var member = new Khaddim();
            foreach (var khaddim in Khuddam)
            {
                if(khaddim.MemberNo == id || khaddim.MkanID == id)
                {
                    member.MkanID = khaddim.MkanID;

                    Console.WriteLine($"Your Previous Data... \n MKANID: {khaddim.MkanID} Full Name: {khaddim.FullName} Member Number: {khaddim.MemberNo} JAMA'AT: {khaddim.Jamaat} CIRCUIT: {khaddim.Circuit}");
                    Khuddam.Remove(member);
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
            Khuddam.Add(member);

            
            
            Console.WriteLine($"Data Updated successfully... \nYour MkanID is: {member.MkanID} ");
        }
    }
    public void DeleteKhadim()
    {
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
            foreach(var Khaddim in Khuddam)
            {
                if(Khaddim.MkanID == id)
                {
                    Console.WriteLine($"Are you sure you want to delete member with the below information? \n{Khaddim.MkanID} Full Name: {Khaddim.FullName} Member Number: {Khaddim.MemberNo} JAMA'AT: {Khaddim.Jamaat} CIRCUIT: {Khaddim.Circuit}");
                    Khuddam.Remove(Khaddim);
                    Console.WriteLine("Member deleted successfully");
                }
            }
        }
    }

}