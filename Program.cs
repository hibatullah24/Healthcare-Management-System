using System;

namespace HMS_WithFunctions
{
    internal class Program
    {
        // Data storage using parallel arrays ( global scope )
        static string[] patientNames = new string[100];
        static string[] patientIDs = new string[100];
        static string[] diagnoses = new string[100];
        static bool[] admitted = new bool[100];
        static string[] assignedDoctors = new string[100];
        static string[] departments = new string[100];
        static int[] visitCount = new int[100];
        static double[] billingAmounts = new double[100];
        static bool[] hasAppointment = new bool[100];
        static DateTime[] lastVisitDate = new DateTime[100];
        static DateTime[] lastDischargeDate = new DateTime[100];
        static int[] daysInHospital = new int[100];
        static string[] bloodType = new string[100];

        static string[] doctorNames = new string[50];
        static int[] doctorAvailableSlots = new int[50];
        static int[] doctorVisitCount = new int[50];

        static int patientIndex = -1;
        static int lastDoctorIndex = -1;

        /////////////////////////////////////////////////////////////////////////

        static public void seedData()
        {
            // seed data for testing
            patientIndex++;
            patientNames[patientIndex] = "Ali Hassan";
            patientIDs[patientIndex] = "P001";
            diagnoses[patientIndex] = "Flu";
            departments[patientIndex] = "General";
            admitted[patientIndex] = false;
            assignedDoctors[patientIndex] = "";
            visitCount[patientIndex] = 2;
            billingAmounts[patientIndex] = 0;
            hasAppointment[patientIndex] = false;
            lastVisitDate[patientIndex] = new DateTime(2025, 01, 10);
            lastDischargeDate[patientIndex] = new DateTime(2025, 01, 15);
            daysInHospital[patientIndex] = 12;
            bloodType[patientIndex] = "A+";

            // seed data patient 2
            patientIndex++;
            patientNames[patientIndex] = "Sara Ahmed";
            patientIDs[patientIndex] = "P002";
            diagnoses[patientIndex] = "Fracture";
            departments[patientIndex] = "Orthopedics";
            admitted[patientIndex] = true;
            assignedDoctors[patientIndex] = "Dr. Noor";
            visitCount[patientIndex] = 4;
            billingAmounts[patientIndex] = 0;
            hasAppointment[patientIndex] = false;
            lastVisitDate[patientIndex] = new DateTime(2025, 03, 02);
            lastDischargeDate[patientIndex] = DateTime.MinValue;
            daysInHospital[patientIndex] = 8;
            bloodType[patientIndex] = "O-";

            // seed data patient 3
            patientIndex++;
            patientNames[patientIndex] = "Omar Khalid";
            patientIDs[patientIndex] = "P003";
            diagnoses[patientIndex] = "Diabetes";
            departments[patientIndex] = "Cardiology";
            admitted[patientIndex] = false;
            assignedDoctors[patientIndex] = "";
            visitCount[patientIndex] = 1;
            billingAmounts[patientIndex] = 0;
            hasAppointment[patientIndex] = false;
            lastVisitDate[patientIndex] = new DateTime(2024, 12, 20);
            lastDischargeDate[patientIndex] = new DateTime(2024, 12, 28);
            daysInHospital[patientIndex] = 5;
            bloodType[patientIndex] = "B+";

            // seed data doctor 1
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Noor";
            doctorAvailableSlots[lastDoctorIndex] = 5;
            doctorVisitCount[lastDoctorIndex] = 0;

            // seed data doctor 2
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Salem";
            doctorAvailableSlots[lastDoctorIndex] = 3;
            doctorVisitCount[lastDoctorIndex] = 0;

            // seed data doctor 3
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Hana";
            doctorAvailableSlots[lastDoctorIndex] = 8;
            doctorVisitCount[lastDoctorIndex] = 0;
        }

        static public void DisplayMenu()
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
        }

        static public string RegisterPatient(string nameInput, string bloodInput, string deptInput, string diagnosisInput)
        {
            Console.WriteLine("Registering new patient...");
            patientIndex++;

            patientNames[patientIndex] = nameInput;
            diagnoses[patientIndex] = diagnosisInput;
            departments[patientIndex] = deptInput;
            bloodType[patientIndex] = bloodInput;

            int num = patientIndex + 1;
            if (num < 10)
            {
                patientIDs[patientIndex] = "P00" + num;
            }
            else if (num < 100)
            {
                patientIDs[patientIndex] = "P0" + num;
            }
            else
            {
                patientIDs[patientIndex] = "P" + num;
            }

            admitted[patientIndex] = false;
            assignedDoctors[patientIndex] = "";
            visitCount[patientIndex] = 0;
            billingAmounts[patientIndex] = 0;
            lastVisitDate[patientIndex] = DateTime.MinValue;
            lastDischargeDate[patientIndex] = DateTime.MinValue;
            daysInHospital[patientIndex] = 0;

            Console.WriteLine("Patient registered successfully!");
            return patientIDs[patientIndex];
        }

        static public int SearchPatient(string searchInput)
        {
            int found = -1;

            for (int i = 0; i <= patientIndex; i++)
            {
                if (patientNames[i] == searchInput || patientIDs[i] == searchInput)
                {
                    found = i;
                    break;
                }
            }

            return found;
        }

        static public int SearchDoctor(string doctorInput)
        {
            int found = -1;

            for (int i = 0; i <= lastDoctorIndex; i++)
            {
                if (doctorNames[i].ToLower() == doctorInput.ToLower())
                {
                    found = i;
                    break;
                }
            }

            return found;
        }

        static public void PrintPatientDetails(int index)
        {
            Console.WriteLine("Patient Name: " + patientNames[index]);
            Console.WriteLine("Patient ID: " + patientIDs[index]);
            Console.WriteLine("Diagnosis: " + diagnoses[index]);
            Console.WriteLine("Department: " + departments[index]);
            Console.WriteLine("Admitted: " + admitted[index]);
            Console.WriteLine("Assigned Doctor: " + assignedDoctors[index]);
            Console.WriteLine("Visit Count: " + visitCount[index]);
            Console.WriteLine("Total Billing Amount: " + billingAmounts[index] + " OMR");
        }

        static void Main(string[] args)
        {
            seedData();

            bool exit = false;

            while (exit == false)
            {
                DisplayMenu();

                Console.Write("choose option: ");

                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the menu options.");
                }

                switch (choice)
                {
                    case 1: // Register New Patient
                        Console.Write("Patient Name: ");
                        string nameInput = Console.ReadLine().Trim();

                        Console.Write("Diagnosis: ");
                        string diagnosisInput = Console.ReadLine().Trim();

                        Console.Write("Blood Type: ");
                        string bloodInput = Console.ReadLine().Trim().ToUpper();

                        Console.Write("Department: ");
                        string deptInput = Console.ReadLine().Trim();

                        string PId = RegisterPatient(nameInput, bloodInput, deptInput, diagnosisInput);
                        Console.WriteLine("Generated Patient ID: " + PId);
                        break;

                    case 2: // Admit Patient [Updated]
                        Console.Write("Enter Patient ID or Name: ");
                        string admitInput = Console.ReadLine();

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
                                string doctorName = Console.ReadLine().Trim();

                                int doctorIndex = SearchDoctor(doctorName);

                                // doctor validation
                                if (doctorIndex == -1)
                                {
                                    Console.WriteLine("Doctor not found in the system. Please register the doctor first.");
                                    break;
                                }

                                // slot check
                                if (doctorAvailableSlots[doctorIndex] <= 0)
                                {
                                    Console.WriteLine(doctorNames[doctorIndex] + " has no available slots at this time.");
                                    break;
                                }

                                // admit and update registry
                                admitted[admitFound] = true;
                                assignedDoctors[admitFound] = doctorNames[doctorIndex];
                                visitCount[admitFound]++;

                                DateTime admissionDate = DateTime.Now;
                                lastVisitDate[admitFound] = admissionDate;

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
                        break;

                    case 3: // Discharge Patient [Updated]
                        Console.Write("Enter Patient ID or Name: ");
                        string dischargeInput = Console.ReadLine();

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

                                // Consultation fee
                                Console.Write("Was there a consultation fee? (yes/no): ");
                                string consultation = Console.ReadLine().ToLower();

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

                                // Medication fee
                                Console.Write("Was there a medication fee? (yes/no): ");
                                string medication = Console.ReadLine().ToLower();

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

                                // Auto discharge date
                                DateTime dischargeDate = DateTime.Now;
                                lastDischargeDate[dischargeFound] = dischargeDate;

                                // Days in hospital
                                Console.Write("Enter number of days in hospital for this visit: ");
                                int days;

                                if (int.TryParse(Console.ReadLine(), out days))
                                {
                                    if (days > 0)
                                    {
                                        daysInHospital[dischargeFound] += days;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Days must be greater than zero");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number");
                                }

                                // Find doctor in registry and restore slot
                                string assignedDoctorName = assignedDoctors[dischargeFound];
                                int doctorIndex = -1;

                                for (int i = 0; i <= lastDoctorIndex; i++)
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

                                // Discharge
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

                                Console.WriteLine("Discharge date recorded: " + dischargeDate.ToString("yyyy-MM-dd HH:mm"));
                                Console.WriteLine("Total days in hospital so far: " + daysInHospital[dischargeFound]);
                                Console.WriteLine("Patient discharged successfully!");
                            }
                            else
                            {
                                Console.WriteLine("This patient is not currently admitted");
                            }
                        }
                        break;

                    case 4: // Search Patient
                        Console.Write("Enter patient ID or Name: ");
                        string searchInput = Console.ReadLine();

                        int searchFound = SearchPatient(searchInput);

                        if (searchFound == -1)
                        {
                            Console.WriteLine("Patient Not Found");
                        }
                        else
                        {
                            PrintPatientDetails(searchFound);
                        }
                        break;

                    case 5:
                        Console.WriteLine("You can keep your existing Case 5 here.");
                        break;

                    case 6:
                        Console.WriteLine("You can keep your existing Case 6 here.");
                        break;

                    case 7:
                        Console.WriteLine("You can keep your existing Case 7 here.");
                        break;

                    case 8:
                        Console.WriteLine("You can keep your existing Case 8 here.");
                        break;

                    case 9:
                        Console.WriteLine("You can keep your existing Case 9 here.");
                        break;

                    case 10: // Exit
                        Console.Write("Are you sure you want to exit? (yes/no): ");
                        string exitInput = Console.ReadLine().ToLower();

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

                    default:
                        Console.WriteLine("Invalid option. please try again.");
                        break;
                }

                Console.WriteLine("Press any key continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}