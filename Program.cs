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
            string[] appointmentDates = new string[100]; // e.g. "2025-09-15"
            string[] appointmentDoctors = new string[100]; // doctor for the appointment
            string[] appointmentDepts = new string[100]; // department for the appointment
            bool[] hasAppointment = new bool[100]; // true = appointment booked

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
            hasAppointment[patientIndex] = false;


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
            hasAppointment[patientIndex] = false;

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
            hasAppointment[patientIndex] = false;


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
                Console.WriteLine("10. Schedule Appointment");
                Console.WriteLine("11. Patient History Report");
                Console.WriteLine("12. Department Statistics Report");
                Console.WriteLine("13. Exit");

                Console.Write("choose option:");

                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invlid input. Please enter a number corresponding to the menu options.");
                   

                }

                switch (choice)
                {
                    case 1: // Register New Patient

                        Console.Write(" Patient Name:");
                        string nameInput = Console.ReadLine();

                        Console.Write("Diagnosis:");
                        string diagnosisInput = Console.ReadLine();

                        Console.Write("Department:");
                        string deptInput = Console.ReadLine();
                         
                        patientIndex++;

                        patientNames[patientIndex] = nameInput;
                        diagnoses[patientIndex] = diagnosisInput;
                        departments[patientIndex] = deptInput;

                        int num = patientIndex + 1;
                        if (num<10)
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

                        Console.WriteLine("Patient registered successfully!");
                        Console.WriteLine("Generated Patient ID: " + patientIDs[patientIndex]);
                        break;  //// Register New Patient

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
                                    Console.Write("Enter Doctor Name: ");
                                    string doctorName = Console.ReadLine();

                                    admitted[i] = true;
                                    assignedDoctors[i] = doctorName;
                                    visitCount[i]++;

                                    Console.WriteLine("Patient admitted successfully and assigned to Dr." + doctorName);
                                    if(visitCount[i] > 1)
                                    {
                                        Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                                    }
                                    else
                                    {
                                        Console.WriteLine("This is the patient's first admission");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Patient is already admitted under " + assignedDoctors[i]);
                                }
                                break;
                            }
                        }
                        if (admitFound == false)
                        {
                            Console.WriteLine("Patient not found");

                        }
                        break;  //// Admit patient

                    case 3: //Discharge patient

                        Console.Write("Enter Patient ID or Name: ");
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
                                    Console.Write(" Was there a consulation fee? (yes/no): ");
                                    string consultation = Console.ReadLine().ToLower();

                                    if (consultation == "yes")
                                    {
                                        Console.Write("Enter Consultation fee amount: ");
                                        double consultAmount = 0;
                                        try
                                        {
                                            consultAmount = double.Parse(Console.ReadLine());
                                            if(consultAmount >0)
                                            {
                                                
                                                visitCharges += consultAmount;
                                                billingAmounts[i] += consultAmount;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Consultation amount must be positive.");
                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Invalid input for fee amount. Please enter a valid number.");
                                            Console.WriteLine(ex.Message);
                                        }
                                        

                                    }

                         

                                    // Medication charges
                                    Console.Write(" Was there a medication fee? (yes/no): ");
                                    string medication = Console.ReadLine().ToLower();



                                    if (medication == "yes")
                                    {
                                        Console.Write("Enter medication fee amount: ");
                                        double medtAmount = 0;

                                        try
                                        {
                                            medtAmount = double.Parse(Console.ReadLine());

                                            if(medtAmount>0)
                                            {
                                                visitCharges += medtAmount;
                                                billingAmounts[i] += medtAmount;

                                            }
                                            else
                                            {
                                                Console.WriteLine("medication amount must be positive.");
                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Invalid input for fee amount. Please enter a valid number.");
                                            Console.WriteLine(ex.Message);
                                        }



                                    }


                                    

                                    //Discharge patient
                                    admitted[i] = false;
                                    assignedDoctors[i] = "";

                                    //output

                                    if(visitCharges > 0)
                                    {
                                        Console.WriteLine("Total charges added this visit: " + visitCharges + " OMR");
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


                        break; ////Discharge patient

                    case 4://Sreach Patient
                        Console.Write("Enter patient ID or Name: ");
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
                                    Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);

                                }
                                else
                                {
                                    Console.WriteLine("Not currently admitted");
                                }
                                    Console.WriteLine("--------------------------------------------");

                            }
                        }
                        if (searchFound == false)
                        {
                            Console.WriteLine("Patient Not Found");
                        }

                        break; ////Sreach Patient

                    case 5: // List All Admitted Patients 
                        Console.WriteLine("Admitted Patients:");
                        Console.WriteLine("------------------------------");

                        bool hasAdmitted = false;
                        int admittedCount = 0;

                        for (int i=0; i<=patientIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                Console.WriteLine("Name:" + patientNames[i] +
                                                  " | ID:" + patientIDs[i] +
                                                  " |Diagnosis: " + diagnoses[i] +
                                                  " |Department:" + departments[i] +
                                                  " |Doctor:" + assignedDoctors[i]);

                                hasAdmitted = true;
                                admittedCount++;
                            }
                        }

                        if (hasAdmitted == false)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }
                        else
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Total Admitted Patients: " + admittedCount);
                        }
                        break; //// List All Admitted Patients 

                    case 6: // Trabsfer patient to Another Doctor

                        Console.Write("Enter current doctor name: ");
                        string currentDoctor = Console.ReadLine();

                        Console.Write("Enter New Doctor Name: ");
                        string newDoctor = Console.ReadLine();

                        if (currentDoctor.ToLower() == newDoctor.ToLower())
                        {
                            Console.WriteLine("Current doctor and new doctor names are the same.");
                            break;
                        }

                        bool transferFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if (assignedDoctors[i] == currentDoctor && admitted[i] ==true)
                            {
                                transferFound = true;

                                assignedDoctors[i] = newDoctor;

                                Console.WriteLine("Patient ' " + patientNames[i] + " ' has been transferred to " + newDoctor);
                                break;

                            }
                        }
                        if(transferFound == false)
                        {
                            Console.WriteLine(" No admitted patient found under this doctor");
                        }

                        break; //// Trabsfer patient to Another Doctor

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

                        break; //// View Most Visited Patients

                    case 8: // Search Patients by Department
                        Console.Write("Enter department name: ");
                        string searchDep = Console.ReadLine();

                        bool DepFound = false;

                        Console.WriteLine("Patients in department ' " + searchDep + " ': ");
                        Console.WriteLine("----------------------------------------");

                        for (int i=0; i<=patientIndex; i++)
                        {
                            if (departments[i].ToLower().Contains(searchDep.ToLower()))
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
                        break; //// Search Patients by Department

                    case 9:

                        Console.WriteLine("Billing Report: ");
                        Console.WriteLine(" 1. System-wide total");
                        Console.WriteLine(" 2. Individual patient");
                        Console.Write("Choose option:");

                        int billingOption = 0;
                        try
                        {
                            billingOption = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Invalid input. Please enter 1 or 2.");
                        }

                        if (billingOption == 1)
                        {
                            double totalBilling = 0;

                            for(int i=0; i<=patientIndex; i++)
                            {
                                totalBilling += billingAmounts[i];
     
                            }
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("System-wide total billing: " + totalBilling + " OMR");

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
                                        Console.WriteLine("Billing amount for " + patientNames[i] + " : " + billingAmounts[i] + " OMR");
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
                        else
                        {
                            Console.WriteLine("Invalid option. Please enter 1 or 2.");
                        }
                            break; ////Billing Report

                    case 10:  //Schedule Appointment

                        Console.Write("Enter patient ID or Name: ");
                        string appointmentInput = Console.ReadLine();

                        bool appointmentFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if (patientNames[i] == appointmentInput || patientIDs[i] == appointmentInput)
                            {
                                appointmentFound = true;

                                if (hasAppointment[i] == true)
                                {
                                    Console.WriteLine(" Patient already has an appointment on " + appointmentDates[i]);
                                }

                                else
                                {
                                    Console.Write("Enter appointment date:");
                                    appointmentDates[i] = Console.ReadLine();

                                    Console.Write("Enter doctor name:");
                                    appointmentDoctors[i] = Console.ReadLine();

                                    Console.Write("Enter Department: ");
                                    appointmentDepts[i] = Console.ReadLine();

                                    hasAppointment[i] = true;

                                    Console.WriteLine("Appointment scheduled for " + patientNames[1] +
                                                       " on " + appointmentDates[i] +
                                                       " with Doctor " + appointmentDoctors[i] +
                                                       " in " + appointmentDepts[i] + " Department");
                                }

                                break;

                            }
                        }
                        if (appointmentFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }


                        break; ////Schedule Appointment

                    case 11:  //Patient History Report

                        Console.Write("Enter patient ID or Name:");
                        string historyInput = Console.ReadLine();

                        bool historyFound = false;

                        for (int i=0; i<= patientIndex; i++)
                        {
                            if (patientNames[i] == historyInput || patientIDs[i] == historyInput)
                            {
                                historyFound = true;

                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("Patient Name: " + patientNames[i]);
                                Console.WriteLine("Patient ID: " + patientIDs[i]);
                                Console.WriteLine("Diagnosis: " + diagnoses[i]);
                                Console.WriteLine("Department: " + departments[i]);
                                Console.WriteLine("Admission Status: " + admitted[i]);

                                if (admitted[i] == true)
                                {
                                    Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);
                                }

                                Console.WriteLine("Total visits: " + visitCount[i]);
                                Console.WriteLine("Total Biling Amount:" + billingAmounts[i]);

                                if (hasAppointment[i] == true)
                                {
                                    Console.WriteLine("Appointment Date: " + appointmentDates[i]);
                                    Console.WriteLine("Appointment Doctor: " + appointmentDoctors[i]);
                                    Console.WriteLine("Appointment Department: " + appointmentDepts[i]);
                                }

                                else
                                {
                                    Console.WriteLine("No appointment scheduled");
                                }

                                break;
                            }
                        }

                        if (historyFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        break; ////Patient History Report



                    case 13:

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


                            break; ////Exit 

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
