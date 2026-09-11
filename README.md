# I-Attendance System

> **Intellectual Property Notice**
> The comprehensive system design, workflow and accompanying official user manual for this project are registered and protected under copyright with the Intellectual Property Corporation of Malaysia (MyIPO). To protect proprietary assets, the full documentation is withheld from this public repository.

## Overview

The I-Attendance System is a Windows desktop application that replaces manual student attendance with a fingerprint scanner. Built using Visual Basic and SQL Server, this system connects directly to the device to track attendance easily, securely and accurately.

The system supports two primary roles :
- **Administrator**
- **Teacher**

---

## Demo Video

Watch the system demo here :
**[Insert YouTube Link Here]**

This demo shows how the whole system works including how to add students, scan fingerprints, record attendance and use the admin dashboard.

---

## Objectives

- Automate student attendance using fingerprint scanning
- Minimize manual mistakes and reduce physical paperwork
- Provide secure access levels for administrators and teachers
- Present attendance data and student information using visual dashboards

---

## Features

### Administrator Module
- Secure administrator login
- Register student profiles and capture photos
- Enroll and manage student fingerprints
- Manage classes and academic standards
- Start and end classes to track attendance and late status
- Manage student and user profiles
- Register new teacher accounts
- Export attendance records and print reports

### Teacher Module
- Secure teacher login
- Register student profiles and enroll fingerprints
- Start and end classes to track attendance
- Export attendance records and print reports
- Manage personal account passwords

---

## Data Visualization & Analytics

The system integrates with **Microsoft Power BI** (located in the `powerbi-dashboard` folder) to visualize attendance and student data.
- **Power BI Desktop**: Used to design and view comprehensive dashboards for student attendance reports, time logs and demographic charts.
- **Power BI Mobile**: Fully supported for viewing interactive dashboards on mobile devices for on-the-go data tracking.
---

## Technologies Used

**Frontend & Backend**
- Visual Basic (VB.NET)

**Hardware Integration**
- Fingerprint Scanner 

**Database**
- SQL Server

**Analytics**
- Microsoft Power BI

---

## System Screenshots

### Landing Page
![Landing Page](screenshots/landing-page.png)

---

## Installation & Setup

1. Clone the repository :
   ```bash
   git clone [https://github.com/IrsyaShah/i-attendance-system.git](https://github.com/IrsyaShah/i-attendance-system.git)
   ```

2. Open the project solution file (`.sln`) in **Visual Studio**

3. Setup the SQL Server database :
   - Open SQL Server Management Studio (SSMS)
   - Create a new database for the system
   - Execute the provided SQL script to generate the required tables

4. Update the database connection string in the VB configuration file to match your local SQL Server instance name and credentials

5. Connect the compatible fingerprint scanner to your machine via USB

6. Build and run the project in Visual Studio

---

## Author

### Team SYAGONA

This project was designed and developed as a Final Year Project (FYP) for Saint International School by :
- Muhammad Irsyaruddin Shah Bin Abdul Halim Shah
- Govinesh Sarma A/L Velayutam
- Sneha Seenivasan
- Tan Rhu Choon

Software Developer

LinkedIn : [Irsya Shah](https://www.linkedin.com/in/irsyashah/)
