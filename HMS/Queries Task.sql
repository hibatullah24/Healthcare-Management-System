-- ============================================
-- Hospital Management System - SQL Assessment
-- 20 Practical Scenarios
-- ============================================

USE HospitalManagementSystem;
GO

-- ============================================
-- INSTRUCTIONS FOR solving
-- ============================================
-- Write SQL queries to solve each scenario below.
-- Test your queries to ensure they work correctly.
-- Each scenario describes a real-world task you need to accomplish.
-- ============================================


-- SCENARIO 1
-- A new patient named "Yasmin Khaled" needs to be registered in the system.
-- Her phone number is 0121111111, email is yasmin.khaled@email.com
-- She was born on 1997-06-15, has blood group AB+, and is female.
-- Address: "888 Helwan St, Cairo"
-- Write a query to add this patient to the database.

INSERT INTO PATIENT (F_name, L_name, Phone_no, Email, Address, DOB, Blood_group, Gender)
VALUES
('Yasmin',  'Khaled', '0121111111', 'yasmin.khaled@email.com', '888 Helwan St, Cairo', '1997-06-15', 'AB+', 'F');

SELECT  * FROM PATIENT;

-- SCENARIO 2
-- The hospital is opening a new department called "Dermatology"
-- Location: "Building E - Floor 2"
-- Contact number: 0221234572
-- Initially it will have 0 doctors and no manager yet
-- Write a query to add this new department.

INSERT INTO DEPARTMENT (Dept_name, Location, No_of_doctors, Contact_number, Manager_ID)
VALUES 
('Dermatology', 'Building E - Floor 2', NULL, '0221234572', NULL);

SELECT  * FROM DEPARTMENT;
----------------------------------------------------------------------------------------------------------------------
-- SCENARIO 3
-- Patient with ID 8 has changed their phone number to 0188888888
-- Write a query to update this patient's phone number.

SELECT  * FROM PATIENT
WHERE Patient_ID = 8 ;

UPDATE PATIENT
SET Phone_no = '0188888888'
WHERE Patient_ID = 8;

SELECT  * FROM PATIENT
WHERE Patient_ID = 8 ;
-----------------------------------------------------------------------------------------------------------------------
-- SCENARIO 4
-- All appointments scheduled for Doctor ID 3 on 2024-03-02 
-- need to be rescheduled to 2024-03-09 (same time, same patients)
-- Write a query to update these appointments.

SELECT  * FROM APPOINTMENT
WHERE Doctor_ID = 3 ;

UPDATE APPOINTMENT
SET Date = '2024-03-09'
WHERE Doctor_ID =3 AND Date = '2024-02-03';

SELECT  * FROM APPOINTMENT
WHERE Doctor_ID = 3 ;

---------------------------------------------------------------------------------------------------------------- --------

-- SCENARIO 5
-- The Cardiology department (Dept_ID = 1) wants to increase 
-- all their service prices by 15% due to new equipment costs.
-- Write a query to update all service prices for this department.

SELECT  * FROM SERVICE
WHERE Dept_ID = 1 ;

UPDATE SERVICE
SET Unit_price = Unit_price * 1.15
WHERE Dept_ID = 1;

SELECT  * FROM SERVICE
WHERE Dept_ID = 1 ;
------------------------------------------------------------------------------------------
-- SCENARIO 6
-- Generate a report showing all scheduled appointments with:
-- - Appointment ID
-- - Appointment date and time
-- - Patient full name (first name + last name)
-- - Patient phone number
-- - Doctor name
-- - Doctor specialization
-- Order the results by appointment date and time.

SELECT A.APPT_ID , A.Date, A.Time,
CONCAT (P.F_name , ' ' ,  P.L_name) AS Patiant_Name, P.Phone_no, D.Name, D.Specialization
FROM APPOINTMENT A JOIN PATIENT P
ON A.Patient_ID = P.Patient_ID
JOIN DOCTOR D
ON A.Doctor_ID = D.Doctor_ID
ORDER BY A.Date, A.Time;

-----------------------------------------------------------------------------------------------
-- SCENARIO 7
-- The hospital needs a list of all doctors showing:
-- - Doctor name
-- - Their department name
-- - Their department manager's name
-- - Number of appointments they have handled
-- Only include doctors who have at least one appointment.
-- Order by number of appointments (highest first).


SELECT d.Name AS Doctor_Name, dep.Dept_name AS Department_Name, mgr.Name AS Department_Manager_Name,
COUNT(a.APPT_ID) AS Appointments_Count
FROM DOCTOR d INNER JOIN DEPARTMENT dep
ON dep.Dept_ID = d.Dept_ID
INNER JOIN DOCTOR mgr
ON mgr.Doctor_ID = dep.Manager_ID
INNER JOIN APPOINTMENT a
ON a.Doctor_ID = d.Doctor_ID
GROUP BY d.Doctor_ID, d.Name, dep.Dept_name, mgr.Name
HAVING COUNT(a.APPT_ID) >= 1
ORDER BY Appointments_Count DESC;

----------------------------------------------------------------------------------------------------------
-- SCENARIO 8
-- Create a financial summary report showing:
-- - Department name
-- - Total number of completed appointments in that department
-- - Total revenue from paid bills in that department
-- - Average bill amount in that department
-- Only include departments that have generated revenue.
-- Order by total revenue (highest first).

SELECT dep.Dept_name AS Department_Name,
COUNT(a.APPT_ID) AS Completed_Appointments,
SUM(b.Total_amount) AS Total_Revenue,
AVG(b.Total_amount) AS Average_Bill_Amount
FROM DEPARTMENT dep INNER JOIN DOCTOR d
ON d.Dept_ID = dep.Dept_ID
INNER JOIN APPOINTMENT a
ON a.Doctor_ID = d.Doctor_ID
INNER JOIN BILLING b
ON b.APPT_ID = a.APPT_ID
WHERE a.Status = 'Completed' AND b.Payment_status = 'Paid'
GROUP BY dep.Dept_ID, dep.Dept_name
HAVING SUM(b.Total_amount) > 0
ORDER BY Total_Revenue DESC;



-- SCENARIO 9
-- Generate a patient activity report showing:
-- - Patient full name
-- - Patient blood group
-- - Total number of appointments they've had
-- - Total amount they've spent (sum of all their bills)
-- - Their payment status distribution (how many paid, pending, etc.)
-- Only include patients who have had more than 2 appointments.
-- Order by total amount spent (highest first).

SELECT CONCAT(p.F_name, ' ', p.L_name) AS Patient_Full_Name, p.Blood_group,
COUNT(DISTINCT a.APPT_ID) AS Total_Appointments,
SUM(b.Total_amount) AS Total_Amount_Spent, 

SUM ( CASE WHEN b.Payment_status = 'Paid' THEN 1 ELSE 0 END) AS Paid_Count,
SUM ( CASE WHEN b.Payment_status = 'Pending' THEN 1 ELSE 0 END) AS Pending_Count,
SUM ( CASE WHEN b.Payment_status = 'Partial' THEN 1 ELSE 0 END) AS Partial_Count,
SUM ( CASE WHEN b.Payment_status = 'Overdue' THEN 1 ELSE 0 END) AS Overdue_Count

FROM PATIENT p INNER JOIN APPOINTMENT a
ON a.Patient_ID = p.Patient_ID
INNER JOIN BILLING b
ON b.APPT_ID = a.APPT_ID
GROUP BY p.Patient_ID, p.F_name, p.L_name, p.Blood_group
HAVING COUNT(DISTINCT a.APPT_ID) > 2
ORDER BY Total_Amount_Spent DESC;


-- SCENARIO 10
-- Create a detailed service utilization report showing:
-- - Service name
-- - Service type
-- - Department offering the service
-- - Number of times the service was used
-- - Total quantity of service provided
-- - Total revenue generated from this service
-- Only include services that have been used at least once.
-- Order by total revenue generated (highest first).

SELECT s.Service_name AS Service_Name, s.Service_type AS Service_Type, dep.Dept_name  AS Department_Name,
COUNT(*) AS Times_Used,
SUM(APPS.Quantity) AS Total_Quantity,
SUM(APPS.Subtotal) AS Total_Revenue

FROM SERVICE s INNER JOIN DEPARTMENT dep
ON dep.Dept_ID = s.Dept_ID
INNER JOIN APP_SERVICE APPS
ON APPS.Service_ID = s.Service_ID

GROUP BY s.Service_ID, s.Service_name, s.Service_type, dep.Dept_name

HAVING COUNT(*) >= 1

ORDER BY Total_Revenue DESC;

-- SCENARIO 11
-- Find all patients who have spent more than the average 
-- total spending across all patients.
-- Show: Patient ID, Patient name, and their total spending.
-- Order by total spending (highest first).

SELECT p.Patient_ID,p.F_name, p.L_name, 
SUM(b.Total_amount) AS Total_Spending
FROM PATIENT p  JOIN BILLING b ON b.Patient_ID = p.Patient_ID
GROUP BY p.Patient_ID, p.F_name, p.L_name
HAVING SUM(b.Total_amount) >
(SELECT AVG(Patient_Total)
 FROM(SELECT SUM(Total_amount) AS Patient_Total
 FROM BILLING
 GROUP BY Patient_ID) AS AvgTable)
ORDER BY Total_Spending DESC;

-- SCENARIO 12
-- Find all doctors who have more appointments than 
-- the doctor with Doctor_ID = 7.
-- Show: Doctor ID, Doctor name, and their appointment count.
-- Order by appointment count (highest first).

SELECT d.Doctor_ID, d.Name AS Doctor_Name,
COUNT(a.APPT_ID) AS Appointment_Count
FROM DOCTOR d  JOIN APPOINTMENT a ON a.Doctor_ID = d.Doctor_ID
GROUP BY d.Doctor_ID, d.Name
HAVING COUNT(a.APPT_ID) >(SELECT COUNT(APPT_ID) FROM APPOINTMENT WHERE Doctor_ID = 7)
ORDER BY Appointment_Count DESC;

-- SCENARIO 13
-- Find all services where the unit price is higher than 
-- the average price of services in the same service type.
-- Show: Service name, Service type, Unit price, 
-- and the average price for that service type.
-- Order by service type, then by unit price (highest first).

SELECT s.Service_name, s.Service_type, s.Unit_price,
(
   SELECT AVG(s2.Unit_price) FROM SERVICE s2
   WHERE s2.Service_type = s.Service_type) AS Avg_Type_Price
FROM SERVICE s WHERE s.Unit_price >
    (
        SELECT AVG(s2.Unit_price)
        FROM SERVICE s2
        WHERE s2.Service_type = s.Service_type
    )
ORDER BY s.Service_type, s.Unit_price DESC;

-- SCENARIO 14
-- Find patients who have appointments but have never 
-- had a completed appointment (all their appointments are 
-- either scheduled, cancelled, or no-show).
-- Show: Patient ID, Patient name, Phone number.
-- Include a count of how many appointments they have.

SELECT p.Patient_ID, p.F_name, p.L_name, p.Phone_no,
COUNT(a.APPT_ID) AS Total_Appointments
FROM PATIENT p  JOIN APPOINTMENT a ON a.Patient_ID = p.Patient_ID
GROUP BY p.Patient_ID, p.F_name, p.L_name, p.Phone_no
HAVING COUNT(a.APPT_ID) > 0
AND (CASE WHEN a.Status = 'Completed' THEN 1 ELSE 0 END) = 0;

-- SCENARIO 15
-- Find the most expensive bill for each payment status category.
-- Show: Payment status, Bill ID, Total amount, Patient name.
-- Include the department name where the appointment took place.
-- Order by total amount (highest first).
 
 --CHATGPT !!!!

 WITH RankedBills AS (
 SELECT b.Payment_status, b.Bill_ID, b.Total_amount,
CONCAT(p.F_name, ' ', p.L_name) AS Patient_Name,
dep.Dept_name AS Department_Name,
ROW_NUMBER() OVER ( PARTITION BY b.Payment_status ORDER BY b.Total_amount DESC, b.Bill_ID DESC) AS rn
FROM BILLING b  JOIN PATIENT p ON p.Patient_ID = b.Patient_ID
 JOIN APPOINTMENT a ON a.APPT_ID = b.APPT_ID
 JOIN DOCTOR d ON d.Doctor_ID = a.Doctor_ID
 JOIN DEPARTMENT dep ON dep.Dept_ID = d.Dept_ID
)
SELECT Payment_status, Bill_ID, Total_amount, Patient_Name, Department_Name
FROM RankedBills
WHERE rn = 1
ORDER BY Total_amount DESC;


-- SCENARIO 16
-- Rank all doctors within their department based on years of experience.
-- Show: Department name, Doctor name, Years of experience, and their rank.
-- The most experienced doctor in each department should have rank 1.
-- Order by department name, then by rank.

SELECT dep.Dept_name AS Department_Name, d.Name AS Doctor_Name, d.Years_of_experience,
RANK() OVER ( PARTITION BY dep.Dept_ID ORDER BY d.Years_of_experience DESC) AS Doctor_Rank
FROM DOCTOR d  JOIN DEPARTMENT dep ON dep.Dept_ID = d.Dept_ID
ORDER BY dep.Dept_name, Doctor_Rank;

-- SCENARIO 17
-- Create a ranking of patients based on their total spending.
-- Show: Patient name, Total amount spent, and their spending rank.
-- Include only patients who have at least one bill.
-- Use a ranking method that doesn't skip numbers (dense ranking).
-- Order by rank.

WITH PatientSpending AS ( 
SELECT p.Patient_ID, 
CONCAT(p.F_name, ' ', p.L_name) AS Patient_Name,
SUM(b.Total_amount) AS Total_Spent
FROM PATIENT p INNER JOIN BILLING b ON b.Patient_ID = p.Patient_ID
GROUP BY p.Patient_ID, p.F_name, p.L_name)
SELECT Patient_Name,Total_Spent,
DENSE_RANK() OVER (ORDER BY Total_Spent DESC) AS Spending_Rank
FROM PatientSpending
ORDER BY Spending_Rank;


-- SCENARIO 18
-- Rank all services by their utilization (how many times they've been used).
-- Show: Service name, Department name, Times used, and rank.
-- Partition the ranking by department (rank within each department).
-- Show all services, even those never used (times used = 0).
-- Order by department name, then by rank.

WITH ServiceUsage AS (
SELECT s.Service_ID, s.Service_name, dep.Dept_name AS Department_Name,
COUNT(aps.APPT_ID) AS Times_Used
FROM SERVICE s  JOIN DEPARTMENT dep ON dep.Dept_ID = s.Dept_ID
LEFT JOIN APP_SERVICE aps ON aps.Service_ID = s.Service_ID
GROUP BY s.Service_ID, s.Service_name, dep.Dept_name, dep.Dept_ID)
SELECT Service_name, Department_Name, Times_Used,
DENSE_RANK() OVER ( PARTITION BY Department_Name ORDER BY Times_Used DESC) AS Utilization_Rank
FROM ServiceUsage
ORDER BY Department_Name, Utilization_Rank;



-- SCENARIO 19
-- A patient (Patient_ID = 12) is booking a new appointment with Doctor_ID = 4
-- for 2024-03-28 at 16:00:00. The appointment is for a "Routine" checkup
-- with reason "Annual physical examination", and status should be "Scheduled".
-- At the same time, create a bill for this appointment with:
-- - Bill amount: 500.00
-- - Payment status: Pending
-- - Due date: 2024-04-15
-- Write a transaction that creates both the appointment and the bill together.
-- Make sure both are saved or both are cancelled if there's an error.

BEGIN TRANSACTION;

BEGIN TRY

    INSERT INTO APPOINTMENT
    VALUES
    ('2024-03-28', '16:00:00', 'Scheduled','Routine', 'Annual physical examination', 12, 4);

    DECLARE @ApptID INT;
    SET @ApptID = SCOPE_IDENTITY();

    INSERT INTO BILLING
    VALUES
    (GETDATE(), 500.00, 'Pending',NULL, '2024-04-15', @ApptID, 12);

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;

END CATCH;

-- SCENARIO 20
-- The hospital needs to cancel an appointment and all related records.
-- For Appointment_ID = 30:
-- - First, delete any services linked to this appointment (from APP_SERVICE)
-- - Then update the appointment status to 'Cancelled'
-- - Then update the corresponding bill's payment status to 'Cancelled'
-- Write a transaction that performs all three operations together.
-- All changes should be committed together or rolled back if any step fails.

BEGIN TRANSACTION;

BEGIN TRY

    DELETE FROM APP_SERVICE
    WHERE APPT_ID = 30;

    UPDATE APPOINTMENT
    SET Status = 'Cancelled'
    WHERE APPT_ID = 30;

    UPDATE BILLING
    SET Payment_status = 'Pending'
    WHERE APPT_ID = 30;

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH;

-- ============================================
-- END OF ASSESSMENT
-- ============================================
