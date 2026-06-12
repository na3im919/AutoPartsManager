# AutoPartsManager

AutoPartsManager is a desktop business management system developed using C#, Windows Forms, and SQL Server for an automotive spare parts business.

The application was built as a freelance solution to help automate and manage daily store operations such as inventory control, sales processing, invoicing, customer and supplier management, reporting, and data backup.

The system is designed with a layered architecture to ensure scalability, maintainability, and separation of concerns.

---

## 🚀 Features

### 📊 Dashboard
- Overview of business statistics
- Quick navigation to main modules
- Real-time inventory insights

---

### 📦 Product Management
- Add, update, and delete products
- Categorize products
- Track stock quantities
- Search and filter products
- Low-stock alerts

---

### 👤 Customer Management
- Manage customer records
- Store contact details
- Fast search and updates

---

### 🚚 Supplier Management
- Manage supplier information
- Store supplier contacts
- Update and maintain supplier records

---

### 💰 Sales & Invoicing
- Create and manage invoices
- Add multiple products per invoice
- Automatic total calculation
- Customer selection system
- Automatic stock updates after sales

---

### 📑 Reports
- Sales reports
- Inventory reports
- Customer & supplier reports
- Export reports to PDF

---

### 💾 Database Management
- Backup and restore database
- Local database initialization
- Data recovery and protection system

---

## 🛠️ Technologies Used

- C#
- Windows Forms (.NET Framework)
- SQL Server / LocalDB
- ADO.NET
- Multi-Layer Architecture
- PDF Reporting

---

## 🏗️ Architecture

The system follows a layered architecture to ensure clean separation of responsibilities:

### Presentation Layer
Handles user interface, forms, and user interactions.

### Business Layer
Contains business rules, validations, and application logic.

### Data Access Layer
Manages database operations and SQL queries.

### Model Layer
Defines entities and data structures used across the system.

---

## 📂 Project Structure

```plaintext
AutoPartsManager/
│
├── PresentationLayer
│   ├── Forms
│   ├── Controls
│   └── Reports
│
├── BusinessLayer
│   ├── Services
│   └── Validation
│
├── DataAccessLayer
│   ├── Repositories
│   ├── Database
│   └── SQL
│
├── ModelLayer
│   └── Entities
│
└── Database
    ├── AutoPartsManager.mdf
    └── Backup
