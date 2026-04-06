using System;
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
            DateTime[] lastVisitDate = new DateTime[100]; // e.g. "2025-08-20"
            DateTime[] lastDischargeDate = new DateTime[100]; // e.g. "2025-08-25"
            int[] daysInHospital = new int[100]; // number of days between admission and discharge
            string[] bloodType = new string[100]; // e.g. "A+", "O-", etc.
            string[] doctorNames = new string[50];
            int[] doctorAvailableSlots = new int[50]; // number of available appointment slots for each doctor
            int [] doctorVisitCount = new int[50];

            int patientIndex = -1;
            int lastDoctorIndex = -1;

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
            lastVisitDate[patientIndex] = new DateTime(2025,01,10);
            lastDischargeDate[patientIndex] = new DateTime(2025,01,15);
            daysInHospital[patientIndex] = 12;
            bloodType[patientIndex] = "A+";
            


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
            lastVisitDate[patientIndex] = new DateTime(2025,03,02);
            lastDischargeDate[patientIndex] = DateTime.MinValue;
            daysInHospital[patientIndex] = 8;
            bloodType[patientIndex] = "O-";
           

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
            lastVisitDate[patientIndex] = new DateTime(2024,12,20);
            lastDischargeDate[patientIndex] = new DateTime(2024,12,28);
            daysInHospital[patientIndex] = 5;
            bloodType[patientIndex] = "B+";


            //seed data doctor 1
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Noor";
            doctorAvailableSlots[lastDoctorIndex] = 5;
            doctorVisitCount[lastDoctorIndex] = 0;

            //seed data doctor 2
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Salem";
            doctorAvailableSlots[lastDoctorIndex] = 3;
            doctorVisitCount[lastDoctorIndex] = 0;

            //seed data doctor 3
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = "Dr. Hana";
            doctorAvailableSlots[lastDoctorIndex] = 8;
            doctorVisitCount[lastDoctorIndex] = 0;









            bool exit = false;

            while (exit == false)
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
                Console.WriteLine("10. Schedule Appointment");
                Console.WriteLine("11. Patient History Report");
                Console.WriteLine("12. Add Doctor");
                Console.WriteLine("13. Doctor Salary Report");
                Console.WriteLine("14. Exit");

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

                        Console.Write("Patient Name:");
                        string nameInput = Console.ReadLine().Trim();

                        Console.Write("Diagnosis:");
                        string diagnosisInput = Console.ReadLine().Trim();

                        Console.Write("Blood Type:");

                        string bloodInput = Console.ReadLine().Trim().ToUpper();

                        Console.Write("Department:");
                        string deptInput = Console.ReadLine().Trim();
                         
                        patientIndex++;

                        patientNames[patientIndex] = nameInput;
                        diagnoses[patientIndex] = diagnosisInput;
                        departments[patientIndex] = deptInput;
                        bloodType[patientIndex] = bloodInput;

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
                        lastVisitDate[patientIndex] = DateTime.MinValue;
                        lastDischargeDate[patientIndex] = DateTime.MinValue;
                        daysInHospital[patientIndex] = 0;

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

                                    DateTime admissionDate = DateTime.Now;
                                    lastVisitDate[i] = admissionDate;

                                    string formattedDate = admissionDate.ToString("yyyy-MM-dd HH:mm");

                                    Console.WriteLine("Patient admitted successfuly!");
                                    Console.WriteLine("Admitted on: " + formattedDate);
                                    Console.WriteLine("Assigned to " + doctorName);


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

                    case 3: // Discharge Patient

                        Console.Write("Enter Patient ID or Name: ");
                        string dischargeInput = Console.ReadLine();

                        bool dischargeFound = false;

                        for (int i = 0; i <= patientIndex; i++)
                        {
                            if (patientNames[i] == dischargeInput || patientIDs[i] == dischargeInput)
                            {
                                dischargeFound = true;

                                if (admitted[i] == true)
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
                                                billingAmounts[i] += consultAmount;
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
                                                billingAmounts[i] += medAmount;
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
                                    lastDischargeDate[i] = dischargeDate;

                                    // Days in hospital
                                    Console.Write("Enter number of days in hospital for this visit: ");
                                    int days;

                                    if (int.TryParse(Console.ReadLine(), out days))
                                    {
                                        if (days > 0)
                                        {
                                            daysInHospital[i] += days;
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

                                    // Discharge
                                    admitted[i] = false;
                                    assignedDoctors[i] = "";

                                    double roundedVisit = Math.Round(visitCharges, 2);
                                    double roundedTotal = Math.Round(billingAmounts[i], 2);

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
                                    Console.WriteLine("Total days in hospital so far: " + daysInHospital[i]);
                                    Console.WriteLine("Patient discharged successfully!");

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("This patient is not currently admitted");
                                    break;
                                }
                            }
                        }

                        if (dischargeFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }

                        break;

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
                                Console.WriteLine("Patient ID:" + patientIDs[i].ToUpper());
                                Console.WriteLine("Diagnosis: " + diagnoses[i] + " (" + diagnoses[i].Length + " characters)");
                                Console.WriteLine("Department:" + departments[i]);
                                Console.WriteLine("Admitted:" + admitted[i]);
                                Console.WriteLine("Visit Count:" + visitCount[i]);
                                string billingText = Convert.ToString(Math.Round(billingAmounts[i], 2));
                                Console.WriteLine("Total Billing Amount: " + billingText + " OMR");
                                Console.WriteLine("Total Days in Hospital: " + daysInHospital[i]);

                                if (admitted[i] == true)
                                {
                                    Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);

                                }
                                else
                                {
                                    Console.WriteLine("Not currently admitted");
                                }
                                   

                                if (lastVisitDate[i] == DateTime.MinValue)
                                {
                                    Console.WriteLine("Last visit Date: No admission recorded");
                                    
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
                                    Console.WriteLine("Last Discharge Date:" + lastDischargeDate[i]);
                                }

                                Console.WriteLine("--------------------------------------------");
                                break;

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

                        Console.Write("Filter by name keyword (press Enter to skip): ");
                        string keyword = Console.ReadLine().Trim().ToLower();

                        bool hasAdmitted = false;
                        int admittedCount = 0;

                        double highestBilling = 0;


                        for (int i=0; i<=patientIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                bool matchKeyword = keyword == "" || patientNames[i].ToLower().Contains(keyword);

                                if (matchKeyword)
                                {
                                    string admittedSince;

                                    if (lastVisitDate[i] == DateTime.MinValue)
                                    {
                                        admittedSince = "No admission recorded";
                                    }
                                    else
                                    {
                                        admittedSince = lastVisitDate[i].ToString("yyyy-MM-dd");
                                    }

                                    Console.WriteLine("Name: " + patientNames[i] +
                                                   " | ID: " + patientIDs[i] +
                                                   " | Diagnosis: " + diagnoses[i] +
                                                   " | Department: " + departments[i] +
                                                   " | Doctor: " + assignedDoctors[i] +
                                                   " | Admitted Since: " + admittedSince);

                                    hasAdmitted = true;
                                    admittedCount++;

                                    highestBilling = Math.Max(highestBilling, billingAmounts[i]);

                                }
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
                            Console.WriteLine("Highest billing among admitted patients: " + Math.Round(highestBilling, 2) + " OMR");
                        }
                        break; //// List All Admitted Patients 

                    case 6: // Trabsfer patient to Another Doctor

                        Console.Write("Enter current doctor name: ");
                        string currentDoctor = Console.ReadLine().Trim();

                        Console.Write("Enter New Doctor Name: ");
                        string newDoctor = Console.ReadLine().Trim();

                        currentDoctor = currentDoctor.Replace("Dr ", "Dr. ");
                        newDoctor = newDoctor.Replace("Dr ", "Dr. ");


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

                                
                               Console.WriteLine("Patient '" + patientNames[i] + "' has been transferred to " + newDoctor);

                                if (lastVisitDate[i] == DateTime.MinValue)
                                {
                                    Console.WriteLine("Patient last admitted on: No admission recorded");
                                }
                                else
                                {
                                    Console.WriteLine("Patient last admitted on: " + lastVisitDate[i].ToString("yyyy-MM-dd"));
                                }
                                    break;

                            }
                        }
                        if(transferFound == false)
                        {
                            Console.WriteLine("No admitted patient found under this doctor");
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

                        Console.WriteLine("Patients in department '" + searchDep.ToUpper() + "':");
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

                                string displayDiagnosis;
                                if (diagnoses[i].Length >15)
                                {
                                    displayDiagnosis = diagnoses[i].Substring(0, 15) + "...";
                                }
                                else
                                {
                                    displayDiagnosis = diagnoses[i];
                                }

                                    Console.WriteLine("ID: " + patientIDs[i] +
                                                      " | Name: " + patientNames[i] +
                                                      " | Diagnosis: " + displayDiagnosis +
                                                      " | Blood Type: " + bloodType[i] +
                                                      " | Status: " + status);
                            }
                        }

                        if(DepFound == false)
                        {
                            Console.WriteLine("No patients found in this department");
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
                            double maxBilling = 0;
                            double minBilling = billingAmounts[0];
                            bool hasBilling = false;


                            for(int i=0; i<=patientIndex; i++)
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
                                        double roundedBilling = Math.Round(billingAmounts[i], 2);

                                        Console.WriteLine("-----------------------------------------------------");
                                        Console.WriteLine("Billing amount for " + patientNames[i] + " : " + roundedBilling + " OMR");


                                        Random rand = new Random();
                                        int discountPercent = rand.Next(5, 21);

                                        double discountAmount = billingAmounts[i] * discountPercent / 100.0;
                                        double finalAmount = billingAmounts[i] - discountAmount;

                                        Console.WriteLine("Discount applied: " + discountPercent + "% - Amount after discount: " + Math.Round(finalAmount, 2) + " OMR");

                                        if (lastVisitDate[i] == DateTime.MinValue)
                                        {
                                            Console.WriteLine("Last Visit Date: No admission recorded");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Last Visit Date: " + lastVisitDate[i]);
                                        }
                                        Console.WriteLine("Total Days: " + daysInHospital[i]);
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

                                    Console.WriteLine("Appointment scheduled for " + patientNames[i] +
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


                    case 12:
                        Console.Write("Enter doctor name: ");
                        string doctorNameInput = Console.ReadLine().Trim();

                        Console.Write("Enter number of available slots: ");
                        string slotsInput = Console.ReadLine();

                        int slotCount;

                        if (int.TryParse (slotsInput, out slotCount) == false || slotCount <1)
                        {
                            Console.WriteLine("Invalid slot count. Doctor not registered.");
                            break;
                        }

                        bool doctorExists = false;

                        for (int i=0; i <= lastDoctorIndex; i++)
                        {
                            if (doctorNames[i].ToLower() == doctorNameInput. ToLower())
                            {
                                doctorExists = true;
                                break;
                            }
                        }

                        if(doctorExists == true)
                        {
                            Console.WriteLine("Doctor already exists in the system");
                            break;
                        }

                        lastDoctorIndex++;
                        doctorNames[lastDoctorIndex] = doctorNameInput;
                        doctorAvailableSlots[lastDoctorIndex] = slotCount;
                        doctorVisitCount[lastDoctorIndex] = 0;

                        Console.WriteLine("Doctor " + doctorNameInput + " registered  successfully with " + slotCount + " available slots.");
                        break; ////Add Doctor
                        



                    case 13:
                        break; ////Doctor Salary Report



                    case 14:

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
