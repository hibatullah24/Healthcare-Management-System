using System;
using System.Collections.Generic;

namespace List_code
{
    internal class Program
    {
        
        static List<string> patientNames = new List<string>();
        //static string[] patientIDs = new string[100];
        static List<string> patientIDs = new List<string>();
        //static string[] diagnoses = new string[100];
        static List<string> diagnoses = new List<string>();

        //static bool[] admitted = new bool[100];
        static List<bool> admitted = new List<bool>();

        //static string[] assignedDoctors = new string[100];
        static List<string> assignedDoctors = new List<string>();
        //static string[] departments = new string[100];
        static List<string> departments = new List<string>();
        //static int[] visitCount = new int[100];
        static List<int> visitCount = new List<int>();
        //static double[] billingAmounts = new double[100];
        static List<double> billingAmounts = new List<double>();
        //static DateTime[] lastVisitDate = new DateTime[100];
        static List<DateTime> lastVisitDate = new List<DateTime>();
        //static DateTime[] lastDischargeDate = new DateTime[100];
        static List<DateTime> lastDischargeDate = new List<DateTime>();
        //static int[] daysInHospital = new int[100];
        static List<int> daysInHospital = new List<int>();
        //static string[] bloodType = new string[100];
        static List<string> bloodType = new List<string>();

        //static string[] doctorNames = new string[50];
        static List<string> doctorNames = new List<string>();
        //static int[] doctorAvailableSlots = new int[50];
        static List<int> doctorAvailableSlots = new List<int>();
        //static int[] doctorVisitCount = new int[50];
        static List<int> doctorVisitCount = new List<int>();

     

        static double BASE_SALARY = 300;
        static double BONUS_PER_VISIT = 15;


        static void SeedData()
        {
            
            patientNames.Add("Ali Hassan");
            patientIDs.Add( "P001");
            diagnoses.Add( "Flu");
            departments.Add( "General");
            admitted.Add(false) ;
            assignedDoctors.Add( "");
            visitCount.Add(2);
            billingAmounts.Add( 0);
            lastVisitDate.Add ( new DateTime(2025, 01, 10));
            lastDischargeDate.Add(new DateTime(2025, 01, 15));
            daysInHospital.Add(12);
            bloodType.Add("A+");

            
            patientNames.Add( "Sara Ahmed");
            patientIDs.Add( "P002");
            diagnoses.Add("Fracture");
            departments.Add("Orthopedics");
            admitted.Add(true);
            assignedDoctors.Add("Dr. Noor");
            visitCount.Add( 4);
            billingAmounts.Add( 0);
            lastVisitDate.Add( new DateTime(2025, 03, 02));
            lastDischargeDate.Add(DateTime.MinValue);
            daysInHospital.Add( 8);
            bloodType.Add("O-");

            
            patientNames.Add( "Omar Khalid");
            patientIDs.Add("P003");
            diagnoses.Add( "Diabetes");
            departments.Add("Cardiology");
            admitted.Add( false);
            assignedDoctors.Add("");
            visitCount.Add( 1);
            billingAmounts.Add( 0);
            lastVisitDate.Add( new DateTime(2024, 12, 20));
            lastDischargeDate.Add(new DateTime(2024, 12, 28));
            daysInHospital.Add(5);
            bloodType.Add( "B+");

            
            doctorNames.Add("Dr. Noor");
            doctorAvailableSlots.Add(5);
            doctorVisitCount.Add( 0);

  
            doctorNames.Add("Dr. Salem");
            doctorAvailableSlots.Add( 3);
            doctorVisitCount.Add( 0);

 
            doctorNames.Add("Dr. Hana");
            doctorAvailableSlots.Add(8);
            doctorVisitCount.Add(0);
        }


        static void DisplayMenu()
        {
            Console.WriteLine("===== Healthcare Management System =====");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Register New Patient");
            Console.WriteLine("2. Admit Patient");
            Console.WriteLine("3. Discharge Patient");
            Console.WriteLine("4. Search Patient");
            Console.WriteLine("5. List All Admitted Patients");
            Console.WriteLine("6. Transfer Patient to Another Doctor");
            Console.WriteLine("7. View Most Visited Patients");
            Console.WriteLine("8. Search Patients by Department");
            Console.WriteLine("9. Billing Report");
            Console.WriteLine("10. Exit");
            Console.WriteLine("11. Add Doctor");
            Console.WriteLine("12. Doctor Salary Report");

        }

        static int SearchPatient(string searchInput)
        {
            for (int i = 0; i < patientNames.Count; i++)
            {
                if (patientNames[i].ToLower() == searchInput.ToLower() ||
                    patientIDs[i].ToLower() == searchInput.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }

        static int SearchDoctor(string doctorInput)
        {
            for (int i = 0; i < doctorNames.Count; i++)
            {
                if (doctorNames[i].ToLower() == doctorInput.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }

        statistatic string GeneratePatientID(int num)
        {
            return "P" + num.ToString("D3");
        }

        static void PrintPatientDetails(int i)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Patient Name: {patientNames[i]}");
            Console.WriteLine($"Patient ID: {patientIDs[i].ToUpper()}");
            Console.WriteLine("Diagnosis: " + diagnoses[i] + " (" + diagnoses[i].Length + " characters)");
            Console.WriteLine("Department: " + departments[i]);
            Console.WriteLine("Blood Type: " + bloodType[i]);
            Console.WriteLine("Admitted: " + admitted[i]);
            Console.WriteLine("Visit Count: " + visitCount[i]);
            Console.WriteLine($"Total Billing Amount: {Math.Round(billingAmounts[i], 2)} OMR");
            Console.WriteLine("Total Days in Hospital: " + daysInHospital[i]);

            if (admitted[i])
            {
                Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);
            }
            else
            {
                Console.WriteLine("Not currently admitted");
            }

            if (lastVisitDate[i] == DateTime.MinValue)
            {
                Console.WriteLine("Last Visit Date: No admission recorded");
            }
            else
            {
                Console.WriteLine("Last Visit Date: " + lastVisitDate[i].ToString("yyyy-MM-dd"));
            }

            if (lastDischargeDate[i] == DateTime.MinValue)
            {
                Console.WriteLine("Last Discharge Date: Still admitted");
            }
            else
            {
                Console.WriteLine("Last Discharge Date: " + lastDischargeDate[i].ToString("yyyy-MM-dd"));
            }

            Console.WriteLine("------------------------------------------------");
        }

        static void RegisterPatient()
        {
            Console.Write("Patient Name: ");
            string nameInput = (Console.ReadLine() ?? "").Trim();

            Console.Write("Diagnosis: ");
            string diagnosisInput = (Console.ReadLine() ?? "").Trim();

            Console.Write("Blood Type: ");
            string bloodInput = (Console.ReadLine() ?? "").Trim().ToUpper();

            Console.Write("Department: ");
            string deptInput = (Console.ReadLine() ?? "").Trim();

            patientNames.Add(nameInput);
            diagnoses.Add(diagnosisInput);
            departments.Add( deptInput);
            bloodType.Add( bloodInput);
            patientIDs.Add(GeneratePatientID(patientNames.Count));


            admitted.Add(false);
            assignedDoctors.Add( "");
            visitCount.Add( 0);
            billingAmounts.Add( 0);
            lastVisitDate.Add( DateTime.MinValue);
            lastDischargeDate.Add(DateTime.MinValue);
            daysInHospital.Add( 0);

            Console.WriteLine("Patient registered successfully!");
            Console.WriteLine("Generated Patient ID: " + patientIDs[patientIDs.Count -1]);
        }

        static void AdmitPatient()
        {
            Console.Write("Enter Patient ID or Name: ");
            string admitInput = (Console.ReadLine() ?? "").Trim();

            int admitFound = SearchPatient(admitInput);

            if (admitFound == -1)
            {
                Console.WriteLine("Patient not found");
            }
            else
            {
                if (admitted[admitFound] == false)
                {
                    Console.Write("Doctor Name: ");
                    string doctorName = (Console.ReadLine() ?? "").Trim();

                    int doctorIndex = SearchDoctor(doctorName);

                    if (doctorIndex == -1)
                    {
                        Console.WriteLine("Doctor not found in the system. Please register the doctor first.");
                        return;
                    }

                    if (doctorAvailableSlots[doctorIndex] <= 0)
                    {
                        Console.WriteLine(doctorNames[doctorIndex] + " has no available slots at this time.");
                        return;
                    }

                    admitted[admitFound] = true;
                    assignedDoctors[admitFound] = doctorNames[doctorIndex];
                    visitCount[admitFound]++;

                    DateTime admissionDate = DateTime.Now;
                    lastVisitDate[admitFound] = admissionDate;
                    lastDischargeDate[admitFound] = DateTime.MinValue;


                    doctorAvailableSlots[doctorIndex]--;
                    doctorVisitCount[doctorIndex]++;

                    Console.WriteLine("Patient admitted successfully!");
                    Console.WriteLine("Admitted on: " + admissionDate.ToString("yyyy-MM-dd HH:mm"));
                    Console.WriteLine("Assigned to " + doctorNames[doctorIndex]);
                    Console.WriteLine(doctorNames[doctorIndex] + " now has " + doctorAvailableSlots[doctorIndex] + " slot(s) remaining.");

                    if (visitCount[admitFound] > 1)
                    {
                        Console.WriteLine("This patient has been admitted " + visitCount[admitFound] + " times");
                    }
                    else
                    {
                        Console.WriteLine("This is the patient's first admission");
                    }
                }
                else
                {
                    Console.WriteLine("Patient is already admitted under " + assignedDoctors[admitFound]);
                }
            }
        }

        static void DischargePatient()
        {
            Console.Write("Enter Patient ID or Name: ");
            string dischargeInput = (Console.ReadLine() ?? "").Trim();

            int dischargeFound = SearchPatient(dischargeInput);

            if (dischargeFound == -1)
            {
                Console.WriteLine("Patient not found");
            }
            else
            {
                if (admitted[dischargeFound] == true)
                {
                    double visitCharges = 0;

                    Console.Write("Was there a consultation fee? (yes/no): ");
                    string consultation = (Console.ReadLine() ?? "").ToLower();

                    if (consultation == "yes")
                    {
                        Console.Write("Enter consultation fee amount: ");
                        double consultAmount;

                        if (double.TryParse(Console.ReadLine(), out consultAmount))
                        {
                            if (consultAmount > 0)
                            {
                                visitCharges += consultAmount;
                                billingAmounts[dischargeFound] += consultAmount;
                            }
                            else
                            {
                                Console.WriteLine("Consultation amount must be positive");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount entered. No charge added.");
                        }
                    }

                    Console.Write("Was there a medication fee? (yes/no): ");
                    string medication = (Console.ReadLine() ?? "").ToLower();

                    if (medication == "yes")
                    {
                        Console.Write("Enter medication fee amount: ");
                        double medAmount;

                        if (double.TryParse(Console.ReadLine(), out medAmount))
                        {
                            if (medAmount > 0)
                            {
                                visitCharges += medAmount;
                                billingAmounts[dischargeFound] += medAmount;
                            }
                            else
                            {
                                Console.WriteLine("Medication amount must be positive");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount entered. No charge added.");
                        }
                    }

                    DateTime dischargeDate = DateTime.Now;
                    lastDischargeDate[dischargeFound] = dischargeDate;

                    DateTime admissionDate = lastVisitDate[dischargeFound];
                    TimeSpan stayDuration = DateTime.Now - admissionDate;

                    int days = (int)Math.Ceiling(stayDuration.TotalDays);

                    if (days < 1)
                    {
                        days = 1;
                    }
                    daysInHospital[dischargeFound] += days;

                    string assignedDoctorName = assignedDoctors[dischargeFound];
                    int doctorIndex = -1;

                    for (int i = 0; i <= doctorNames.Count; i++)
                    {
                        if (doctorNames[i].ToLower() == assignedDoctorName.ToLower())
                        {
                            doctorIndex = i;
                            break;
                        }
                    }

                    if (doctorIndex != -1)
                    {
                        doctorAvailableSlots[doctorIndex]++;
                        Console.WriteLine(doctorNames[doctorIndex] + " now has " + doctorAvailableSlots[doctorIndex] + " slot(s) available.");
                    }
                    else
                    {
                        Console.WriteLine("Warning: assigned doctor not found in registry. Slots not updated.");
                    }

                    admitted[dischargeFound] = false;
                    assignedDoctors[dischargeFound] = "";

                    double roundedVisit = Math.Round(visitCharges, 2);
                    double roundedTotal = Math.Round(billingAmounts[dischargeFound], 2);

                    if (visitCharges > 0)
                    {
                        Console.WriteLine("Total charges added this visit: " + roundedVisit + " OMR");
                        Console.WriteLine("Patient running total: " + roundedTotal + " OMR");
                    }
                    else
                    {
                        Console.WriteLine("No charges recorded for this visit");
                    }

                    Console.WriteLine($"Discharge date recorded: {dischargeDate:yyyy-MM-dd HH:mm}"); Console.WriteLine($"Days for this visit: {days}");
                    Console.WriteLine($"Total days in hospital so far: {daysInHospital[dischargeFound]}");
                    Console.WriteLine("Patient discharged successfully!");
                }
                else
                {
                    Console.WriteLine("This patient is not currently admitted");
                }
            }
        }

        static void BillingReport()
        {
            Console.WriteLine("Billing Report:");
            Console.WriteLine("1. System-wide total");
            Console.WriteLine("2. Individual patient");
            Console.Write("Choose option: ");

            int billingOption = 0;
            try
            {
                billingOption = int.Parse((Console.ReadLine() ?? "").Trim());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                return;
            }

            if (billingOption == 1)
            {
                double totalBilling = 0;
                double maxBilling = 0;
                double minBilling = 0;
                bool hasBilling = false;

                for (int i = 0; i <= patientNames.Count; i++)
                {
                    totalBilling += billingAmounts[i];

                    if (billingAmounts[i] > 0)
                    {
                        if (hasBilling == false)
                        {
                            minBilling = billingAmounts[i];
                            hasBilling = true;
                        }

                        maxBilling = Math.Max(maxBilling, billingAmounts[i]);
                        minBilling = Math.Min(minBilling, billingAmounts[i]);
                    }
                }

                Console.WriteLine("----------------------------");
                Console.WriteLine("System-wide total billing: " + Math.Round(totalBilling, 2) + " OMR");

                if (hasBilling == true)
                {
                    Console.WriteLine("Highest individual billing: " + Math.Round(maxBilling, 2) + " OMR");
                    Console.WriteLine("Lowest individual billing: " + Math.Round(minBilling, 2) + " OMR");
                }
            }
            else if (billingOption == 2)
            {
                Console.Write("Enter patient ID or Name: ");
                string billingInput = (Console.ReadLine() ?? "").Trim();

                int billingFound = SearchPatient(billingInput);

                if (billingFound == -1)
                {
                    Console.WriteLine("No billing records found for this patient");
                }
                else
                {
                    if (billingAmounts[billingFound] > 0)
                    {
                        double roundedBilling = Math.Round(billingAmounts[billingFound], 2);

                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("Billing amount for " + patientNames[billingFound] + " : " + roundedBilling + " OMR");

                        Random rand = new Random();
                        int discountPercent = rand.Next(5, 21);

                        double discountAmount = billingAmounts[billingFound] * discountPercent / 100.0;
                        double finalAmount = billingAmounts[billingFound] - discountAmount;

                        Console.WriteLine("Discount applied: " + discountPercent + "% - Amount after discount: " + Math.Round(finalAmount, 2) + " OMR");

                        if (lastVisitDate[billingFound] == DateTime.MinValue)
                        {
                            Console.WriteLine("Last Visit Date: No admission recorded");
                        }
                        else
                        {
                            Console.WriteLine("Last Visit Date: " + lastVisitDate[billingFound].ToString("yyyy-MM-dd HH:mm"));
                        }

                        Console.WriteLine("Total Days: " + daysInHospital[billingFound]);
                    }
                    else
                    {
                        Console.WriteLine("No billing records found for this patient");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter 1 or 2.");
            }
        }

        static void AddDoctor()
        {
            Console.Write("Enter doctor name: ");
            string doctorNameInput = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(doctorNameInput))
            {
                Console.WriteLine("Doctor name cannot be empty.");
                return;
            }

            Console.Write("Enter number of available slots: ");
            string slotsInput = (Console.ReadLine() ?? "").Trim();

            int slotCount;

            if (int.TryParse(slotsInput, out slotCount) == false || slotCount < 1)
            {
                Console.WriteLine("Invalid slot count. Doctor not registered.");
                return;
            }

            bool doctorExists = false;

            for (int i = 0; i <= lastDoctorIndex; i++)
            {
                if (doctorNames[i].ToLower() == doctorNameInput.ToLower())
                {
                    doctorExists = true;
                    break;
                }
            }

            if (doctorExists == true)
            {
                Console.WriteLine("Doctor already exists in the system");
                return;
            }

            if (lastDoctorIndex >= doctorNames.Length - 1)
            {
                Console.WriteLine("Doctor storage is full. Cannot register more doctors.");
                return;
            }

            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = doctorNameInput;
            doctorAvailableSlots[lastDoctorIndex] = slotCount;
            doctorVisitCount[lastDoctorIndex] = 0;

            Console.WriteLine($"Doctor {doctorNameInput} registered successfully with {slotCount} available slots.");
        }

        static void DoctorSalaryReport()
        {
            if (doctorNames.Count == 0)
            {
                Console.WriteLine("No doctors registered in the system");
                return;
            }

            Console.WriteLine("Doctor Salary Report");
            Console.WriteLine("----------------------------------------------");



            double highestSalary = BASE_SALARY + (doctorVisitCount[0] * BONUS_PER_VISIT);
            highestSalary = Math.Round(highestSalary, 2);
            int highestDoctorIndex = 0;



            for (int i = 0; i < doctorNames.Count; i++)
            {
                double salary = BASE_SALARY + (doctorVisitCount[i] * BONUS_PER_VISIT);
                salary = Math.Round(salary, 2);

                Console.WriteLine($"Name: {doctorNames[i]} | Visits: {doctorVisitCount[i]} | Available Slots: {doctorAvailableSlots[i]} | Salary: {salary} OMR");


                double highestSalary = BASE_SALARY + (doctorVisitCount[0] * BONUS_PER_VISIT);
                if (salary > highestSalary)
                {
                    highestSalary = salary;
                    highestDoctorIndex = i;
                }
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Highest earning doctor: {doctorNames[highestDoctorIndex]} - {Math.Round(highestSalary, 2)} OMR");

        }



        static void Main(string[] args)
        {
            SeedData();

            bool exit = false;

            while (exit == false)
            {
                DisplayMenu();

                Console.Write("Choose option: ");

                int choice = 0;
                try
                {
                    choice = int.Parse((Console.ReadLine() ?? "").Trim());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please choose a number from 1 to 10.");
                }

                switch (choice)
                {
                    case 1:

                        RegisterPatient();
                        break;

                    case 2: // Admit Patient Updated
                        AdmitPatient();
                        break;

                    case 3: // Discharge Patient Updated
                        DischargePatient();
                        break;

                    case 4: // Search Patient
                        Console.Write("Enter patient ID or Name: ");
                        string searchInput = (Console.ReadLine() ?? "").Trim();

                        int searchFound = SearchPatient(searchInput);

                        if (searchFound == -1)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        else
                        {
                            PrintPatientDetails(searchFound);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Admitted Patients:");
                        Console.WriteLine("------------------------------");

                        Console.Write("Filter by name keyword (press Enter to skip): ");
                        string keyword = (Console.ReadLine() ?? "").Trim().ToLower();

                        bool hasAdmitted = false;
                        int admittedCount = 0;
                        double highestBilling = 0;

                        for (int i = 0; i < patientNames.Count; i++)

                        {
                            if (admitted[i])
                            {
                                bool matchKeyword = keyword == "" || patientNames[i].ToLower().Contains(keyword);

                                if (matchKeyword)
                                {
                                    string admittedSince = lastVisitDate[i] == DateTime.MinValue
                                        ? "No admission recorded"
                                        : lastVisitDate[i].ToString("yyyy-MM-dd");

                                    Console.WriteLine($"Name: {patientNames[i]} | ID: {patientIDs[i]} | Diagnosis: {diagnoses[i]} | Department: {departments[i]} | Doctor: {assignedDoctors[i]} | Admitted Since: {admittedSince}");

                                    hasAdmitted = true;
                                    admittedCount++;
                                    highestBilling = Math.Max(highestBilling, billingAmounts[i]);
                                }
                            }
                        }

                        if (!hasAdmitted)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }
                        else
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine($"Total Admitted Patients: {admittedCount}");
                            Console.WriteLine($"Highest billing among admitted patients: {Math.Round(highestBilling, 2)} OMR");
                        }
                        break;

                    case 6:
                        Console.Write("Enter current doctor name: ");
                        string currentDoctor = (Console.ReadLine() ?? "").Trim();

                        Console.Write("Enter New Doctor Name: ");
                        string newDoctor = (Console.ReadLine() ?? "").Trim();

                        currentDoctor = currentDoctor.Replace("Dr ", "Dr. ");
                        newDoctor = newDoctor.Replace("Dr ", "Dr. ");

                        if (currentDoctor.ToLower() == newDoctor.ToLower())
                        {
                            Console.WriteLine("Current doctor and new doctor names are the same.");
                            break;
                        }

                        int newDoctorIndex = SearchDoctor(newDoctor);
                        if (newDoctorIndex == -1)
                        {
                            Console.WriteLine("New doctor not found in the system.");
                            break;
                        }

                        if (doctorAvailableSlots[newDoctorIndex] <= 0)
                        {
                            Console.WriteLine($"{doctorNames[newDoctorIndex]} has no available slots.");
                            break;
                        }

                        bool transferFound = false;

                        for (int i = 0; i <= patientNames.Count; i++)
                        {
                            if (assignedDoctors[i].ToLower() == currentDoctor.ToLower() && admitted[i])
                            {
                                transferFound = true;

                                int oldDoctorIndex = SearchDoctor(currentDoctor);
                                if (oldDoctorIndex != -1)
                                {
                                    doctorAvailableSlots[oldDoctorIndex]++;
                                }

                                assignedDoctors[i] = doctorNames[newDoctorIndex];
                                doctorAvailableSlots[newDoctorIndex]--;

                                Console.WriteLine($"Patient '{patientNames[i]}' has been transferred to {newDoctor}");

                                string lastDate = lastVisitDate[i] == DateTime.MinValue
                                    ? "No admission recorded"
                                    : lastVisitDate[i].ToString("yyyy-MM-dd");

                                Console.WriteLine($"Patient last admitted on: {lastDate}");
                                break;
                            }
                        }

                        if (!transferFound)
                        {
                            Console.WriteLine("No admitted patient found under this doctor");
                        }
                        break;

                    case 7: // View Most Visited Patients
                        Console.WriteLine("Most Visited Patients:");
                        Console.WriteLine("----------------------------------");

                        int maxVisits = 0;

                        for (int i = 0; i <= patientNames.Count; i++)
                        {
                            if (visitCount[i] > maxVisits)
                            {
                                maxVisits = visitCount[i];
                            }
                        }

                        for (int count = maxVisits; count >= 0; count--)
                        {
                            for (int i = 0; i <= patientNames.Count; i++)
                            {
                                if (visitCount[i] == count)
                                {
                                    Console.WriteLine($"ID: {patientIDs[i]} | Name: {patientNames[i]} | Department: {departments[i]} | Diagnosis: {diagnoses[i]} | Visits: {visitCount[i]}");
                                }
                            }
                        }
                        break;

                    case 8:
                        Console.Write("Enter department name: ");
                        string searchDep = (Console.ReadLine() ?? "").Trim();

                        bool depFound = false;

                        Console.WriteLine($"Patients in department '{searchDep.ToUpper()}':");
                        Console.WriteLine("----------------------------------------");

                        for (int i = 0; i < patientNames.Count; i++)
                        {
                            if (departments[i].ToLower().Contains(searchDep.ToLower()))
                            {
                                depFound = true;

                                string status = admitted[i] ? "Admitted" : "Not Admitted";

                                string displayDiagnosis = diagnoses[i].Length > 15
                                    ? diagnoses[i].Substring(0, 15) + "..."
                                    : diagnoses[i];

                                Console.WriteLine($"ID: {patientIDs[i]} | Name: {patientNames[i]} | Diagnosis: {displayDiagnosis} | Blood Type: {bloodType[i]} | Status: {status}");
                            }
                        }

                        if (!depFound)
                        {
                            Console.WriteLine("No patients found in this department");
                        }
                        break;

                    case 9: // Billing Report
                        BillingReport();
                        break;


                    case 10: // Exit
                        Console.Write("Are you sure you want to exit? (yes/no): ");
                        string exitInput = (Console.ReadLine() ?? "").ToLower();

                        if (exitInput == "yes")
                        {
                            Console.WriteLine("Exiting system...");
                            Console.WriteLine("Thank you for using the Healthcare");
                            Console.WriteLine("Management System!");
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Exit cancelled. Returning to main menu...");
                        }
                        break;


                    case 11:
                        AddDoctor();
                        break;

                    case 12:
                        DoctorSalaryReport();
                        break;



                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
