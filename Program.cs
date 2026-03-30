using System.Diagnostics;

namespace Healthcare_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];
            string[] assignedDoctors = new string[100];
            string[] departments =  new string[100];
            int[] visitCount =  new int[100];
            double[] billingAmounts = new double[100];

            int patientIndex = -1;

            //seed data for testing
            patientIndex++;
            patientNames[patientIndex] = "Ali Hassan ";
            patientIDs[patientIndex] = "P001";
            diagnoses[patientIndex] = "Flu";
            departments[patientIndex] = "General";
            admitted[patientIndex] = false;
            assignedDoctors[patientIndex] = " ";
            visitCount[patientIndex] = 2;
            billingAmounts[patientIndex] = 0;

            //seed data patient 2
            patientIndex++;
            patientNames[patientIndex] = "Sara Ahmed";
            patientIDs[patientIndex] = "P002";
            diagnoses[patientIndex] = "Fracture";
            departments[patientIndex] = "Orthopedics";
            admitted[patientIndex] = true;
            assignedDoctors[patientIndex] = "Dr. Noor";
            visitCount[patientIndex] = 4;
            billingAmounts[patientIndex] = 0;

            //seed data patient 3
            patientIndex++;
            patientNames[patientIndex] = "Omar Khalid";
            patientIDs[patientIndex] = "P003";
            diagnoses[patientIndex] = "Diabetes";
            departments[patientIndex] = "Cardiology";
            admitted[patientIndex] = false;
            assignedDoctors[patientIndex] = " ";
            visitCount[patientIndex] = 1;
            billingAmounts[patientIndex] = 0;


            bool exit = false;

            while (exit == false)
            {

                Console.WriteLine("===== Healthcare Management System =====");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Admit PAtient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. List All Admitted Patients");
                Console.WriteLine("6. Transfer Patient to Another Doctor");
                Console.WriteLine("7. View Most Visited Patients");
                Console.WriteLine("8. Search Patients by Department");
                Console.WriteLine("9. Billing Report");
                Console.WriteLine("10. Exit");

                Console.Write("choose option:");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: // Register New Patient

                        patientIndex++;

                        Console.Write(" Patient Name:");
                        patientNames[patientIndex] = Console.ReadLine();

                        Console.Write("Patient ID:");
                        patientIDs[patientIndex] = Console.ReadLine();

                        Console.Write("Diagnosis:");
                        diagnoses[patientIndex] = Console.ReadLine();

                        Console.Write("Department:");
                        departments[patientIndex] = Console.ReadLine();

                        admitted[patientIndex] = false;
                        assignedDoctors[patientIndex] = "";
                        visitCount[patientIndex] = 0;
                        billingAmounts[patientIndex] = 0;

                        Console.WriteLine("Patient registered successfully!");

                        break;

                    case 2: // Admit patient

                        Console.Write("Enter Patient ID or Name: ");
                        string admitInput = Console.ReadLine();

                        bool admitFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                            {
                                admitFound = true;

                                if (admitted[i] == false)
                                {
                                    Console.Write("Enter Doctor Name:");
                                    string doctorName = Console.ReadLine();

                                    admitted[i] = true;
                                    assignedDoctors[i] = doctorName;
                                    visitCount[i]++;

                                    Console.WriteLine("Patient admitted successfully and assigned to" + doctorName);
                                    Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");

                                }
                                else
                                {
                                    Console.WriteLine("Patient is already admitted under" + assignedDoctors[i]);
                                }
                                break;
                            }
                        }
                        if (admitFound == false)
                        {
                            Console.WriteLine("Patient not found");

                        }
                        break;

                    case 3: //Discharge patient

                        Console.Write("Enter Patient IS or Name:");
                        string DischargeInput = Console.ReadLine();

                        bool dischargeFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if(patientNames[i] == DischargeInput || patientIDs[i] == DischargeInput)
                            {
                                dischargeFound = true;
                                if (admitted[i] == true)
                                {
                                    double visitCharges = 0;

                                    //consutation fee
                                    Console.Write(" Was there a consulation fee? (yes/no):");
                                    string consultation = Console.ReadLine().ToLower();

                                    if (consultation == "yes")
                                    {
                                        Console.Write("Enter Consultation fee amount:");
                                        double consultAmount = double.Parse(Console.ReadLine());
                                        visitCharges += consultAmount;
                                    }

                                    // Medication charges
                                    Console.Write(" Was there a medication fee? (yes/no):");
                                    string medication = Console.ReadLine().ToLower();

                                    if (medication == "yes")
                                    {
                                        Console.Write("Enter medication fee amount:");
                                        double medtAmount = double.Parse(Console.ReadLine());
                                        visitCharges += medtAmount;
                                    }

                                    // Add to total billing
                                    billingAmounts[i] += visitCharges;

                                    //Discharge patient
                                    admitted[i] = false;
                                    assignedDoctors[i] = "";

                                    //output

                                    if(visitCharges > 0)
                                    {
                                        Console.WriteLine("Total charges added this visit:" + visitCharges + "OMR");
                                    }

                                    else
                                    {
                                        Console.WriteLine("No charges recored for this visit");

                                    }
                                    Console.WriteLine("Patient discharged successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("This patient is not currently admitted");

                                }

                                break;
                            }

                        }

                        if(dischargeFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }


                        break;

                    case 4://Sreach Patient
                        Console.Write("Enter patient ID or Name:");
                        string searchInput = Console.ReadLine();

                        bool searchFound = false;

                        for(int i=0; i<=patientIndex; i++)
                        {
                            if (patientNames[i] == searchInput || patientIDs[i] == searchInput)
                            {
                                searchFound = true;

                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("Patient Name:" + patientNames[i]);
                                Console.WriteLine("Patient ID:" + patientIDs[i]);
                                Console.WriteLine("Diagnosis:" + diagnoses[i]);
                                Console.WriteLine("Department:" + departments[i]);
                                Console.WriteLine("Admitted:" + admitted[i]);
                                Console.WriteLine("Visit Count:" + visitCount[i]);
                                Console.WriteLine("Total Billing Amount:" + billingAmounts[i]);

                                if (admitted[i] == true)
                                {
                                    Console.WriteLine("Assigned Doctor:" + assignedDoctors[i]);

                                }
                                Console.WriteLine("--------------------------------------------");

                            }
                        }
                        if (searchFound == false)
                        {
                            Console.WriteLine("Patient Not Found");
                        }

                        break;

                    case 5: // List All Admitted Patients 
                        Console.WriteLine("Admitted Patients:");
                        Console.WriteLine("------------------------------");

                        bool hasAdmitted = false;

                        for(int i=0; i<=patientIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                Console.WriteLine("Name:" + patientNames[i] +
                                                  " | ID:" + patientIDs[i] +
                                                  " |Diagnosis: " + diagnoses[i] +
                                                  " |Department:" + departments[i] +
                                                  " |Doctor:" + assignedDoctors[i]);

                                hasAdmitted = true;
                            }
                        }

                        if (hasAdmitted == false)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }
                        break;

                    case 6: // Trabsfer patient to Another Doctor

                        Console.Write("Enter current doctor name:");
                        string currentDoctor = Console.ReadLine();

                        Console.Write("Enter New Doctor Name:");
                        string newDoctor = Console.ReadLine();

                        bool transferFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if (assignedDoctors[i] == currentDoctor && admitted[i] ==true)
                            {
                                transferFound = true;

                                assignedDoctors[i] = newDoctor;

                                Console.WriteLine("Patient ' " + patientNames[i] + " ' has been transferred to" + newDoctor);

                            }
                        }
                        if(transferFound == false)
                        {
                            Console.WriteLine(" No admitted patient found under this doctor");
                        }

                        break;

                    case 7: // View Most Visited Patients
                        Console.WriteLine("Most Visted Patients:");
                        Console.WriteLine("----------------------------------");

                        for ( int count=100; count >=0; count--)
                        {
                            for (int i=0; i<= patientIndex; i++)
                            {
                                if (visitCount[i] == count)
                                {
                                    Console.WriteLine("ID:  " + patientIDs[i] +
                                                      " |Name:  " + patientNames[i] +
                                                      " |Department:  " + departments[i] +
                                                      " |Diagnosis:  " + diagnoses[i] +
                                                      " |Visits:  " + visitCount[i]);
                                }
                            }
                        }

                        break;

                    case 8: // Search Patients by Department
                        Console.Write("Enter department name:");
                        string searchDep = Console.ReadLine();

                        bool DepFound = false;

                        Console.WriteLine("Patients in department '" + searchDep + " ':");
                        Console.WriteLine("----------------------------------------");

                        for (int i=0; i<=patientIndex; i++)
                        {
                            if (departments[i].ToLower() == searchDep.ToLower())
                            {
                                DepFound = true;

                                string status;
                                if (admitted[i] == true)
                                {
                                    status = "Admitted";
                                }
                                else
                                {
                                    status = " Not Admitted";
                                }

                                Console.WriteLine("ID: " + patientIDs[i] +
                                                  " | Name: " + patientNames[i] +
                                                  " | Diagnosis: " + diagnoses[i] +
                                                  " | Status: " + status);
                            }
                        }

                        if(DepFound == false)
                        {
                            Console.WriteLine("No Patients found in this departments");
                        }
                        break;

                    case 9:

                        Console.WriteLine("Billing Report:");
                        Console.WriteLine(" 1. System-wide total");
                        Console.WriteLine(" 2. Individual patient");
                        Console.Write("Choose option:");
                        int billingOption = int.Parse(Console.ReadLine());

                        if(billingOption == 1)
                        {
                            double totalBilling = 0;

                            for(int i=0; i<=patientIndex; i++)
                            {
                                totalBilling += billingAmounts[i];
     
                            }
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("System-wide total billing:" + totalBilling + "OMR");

                        }
                        else if (billingOption == 2)
                        {
                            Console.Write("Enter patient ID or Name:");
                            string billingInput = Console.ReadLine();

                            bool billingFound = false;

                            for ( int i = 0; i <= patientIndex; i++)
                            {
                                if (patientNames[i] == billingInput || patientIDs[i] == billingInput)
                                {
                                    billingFound = true;

                                    if (billingAmounts[i] > 0)
                                    {
                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.WriteLine("Billing amount for" + patientNames[i] + ": " + billingAmounts[i] + " OMR");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No billing records found for this patient");
                                    }
                                    break;
                                }
                            }

                            if (billingFound == false)
                            {
                                Console.WriteLine(" No billing records found for this patient");
                            }
                        }
                            break;

                    case 10:

                        Console.WriteLine("Exiting system...");
                        Console.WriteLine("Thank you for using the Healthcare");
                        Console.WriteLine("Management System!");
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
