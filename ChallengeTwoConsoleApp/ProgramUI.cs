using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsoleApp
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Claims Department.\n" +
                    "Select the number of the menu you would like to see:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit program");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        RunMenu();
                        break;
                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();
            List<ClaimContent> allClaims = _claimRepo.GetClaims();
            Console.WriteLine($"Claim ID     Type     Description                              Amount                   Date of Incident                      Date of Claim     Is Valid");
            foreach (ClaimContent claim in allClaims)
            {
                Console.WriteLine($"{claim.ClaimID}             {claim.ClaimType}      {claim.Description}             {claim.ClaimAmount}            {claim.DateOfIncident}         {claim.DateOfClaim}      {claim.IsValid}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DisplayClaim(ClaimContent claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID}\n" +
                $"Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Claim Amount: {claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is Valid: { claim.IsValid}\n" +
                $"");

        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:");

            int lowestClaimID;
            List<ClaimContent> claimList = _claimRepo.GetClaims();

            lowestClaimID = int.MaxValue;
            ClaimContent claim = null;
            foreach (ClaimContent clm in claimList)
            {
                if (clm.ClaimID <= lowestClaimID)
                {
                    lowestClaimID = clm.ClaimID;
                    claim = clm;
                }
            }
            if (claim != null)
            {
                DisplayClaim(claim);
                Console.WriteLine("Do you want to deal with this claim now?\n" +
                "Type y for yes and n for no");
                string dealWithClaim = Console.ReadLine().ToLower();
                if (dealWithClaim == "y")
                {
                    _claimRepo.RemoveClaimFromQueue(claim);
                    RunMenu();
                }
                else
                {
                    RunMenu();
                }
            }
            else
            {
                Console.WriteLine("You have no claims to manage. Take a break!");

            }
            Console.ReadKey();
            RunMenu();
        }

        private void EnterANewClaim()
        {
            Console.Clear();
            ClaimContent claim = new ClaimContent();
            Console.WriteLine("Enter the claim ID");
            claim.ClaimID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Select the claim type:\n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft");
            string claimType = Console.ReadLine();

            switch (claimType)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    break;
            }

            Console.WriteLine("Enter a description of the claim:");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            claim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of incident (MM/DD/YYYY)");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of claim (MM/DD/YYYY)");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimRepo.AddClaimToQueue(claim);
        }

        private void SeedClaimList()
        {
            ClaimContent carCrash = new ClaimContent(61, ClaimType.Car, "Car crash at Meridian and Washington", 50000, new DateTime(1992, 09, 16), new DateTime(2021, 03, 01));
            ClaimContent newCarCrash = new ClaimContent(15, ClaimType.Car, "Car crash at 62nd and Zionsville", 10000, new DateTime(2021, 03, 15), new DateTime(2021, 03, 25));
            ClaimContent houseFire = new ClaimContent(2, ClaimType.Home, "House fire in Lafayette, Indiana", 200000, new DateTime(2021, 02, 27), new DateTime(2021, 03, 05));
            ClaimContent homeTheft = new ClaimContent(5, ClaimType.Theft, "Apartment broken into in Muncie", 500, new DateTime(2021,03,28), new DateTime(2021, 03, 16));

            _claimRepo.AddClaimToQueue(carCrash);
            _claimRepo.AddClaimToQueue(newCarCrash);
            _claimRepo.AddClaimToQueue(houseFire);
            _claimRepo.AddClaimToQueue(homeTheft);

        }


    }
}
