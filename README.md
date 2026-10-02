# 📦 Stock-er

> A multi-tenant inventory and billing management system designed to simplify inventory operations, billing, and barcode-driven workflows.

Stock-er provides a centralized system for managing inventory, users, billing, and product information across organizations. It combines organization-level data isolation, role-based access control, barcode workflows, and real-time data synchronization into a desktop application.

---

## ✨ Features

### 📦 Inventory Management
- Create, update, and manage inventory items
- Maintain product information, pricing, quantities, and images
- Real-time synchronization of inventory data
- Support for multiple images per inventory item

### 👥 Multi-Tenant Access Control
- Organization-level data segregation
- Role-based access for **Admin, Manager, and Staff**
- Granular permissions for user management
- Organization invitations and account management

### 🏷️ Barcode Workflows
- Generate product barcodes
- Scan and retrieve products using barcode scanners
- Search using barcode strings
- Identify products from uploaded barcode images
- Support for multiple standard barcode formats

### 🧾 Billing
- Create and manage bills
- Apply flat or percentage-based discounts
- Generate and save billing documents as PDFs
- Retrieve inventory items directly during checkout

### 🔐 Authentication
- Secure password handling
- Organization administrator registration
- User invitations
- Password reset workflows
- Role-based authorization

---

## 🏗️ System Overview

```text
                     Stock-er
                        │
          ┌─────────────┴─────────────┐
          │                           │
     User Management             Inventory
          │                           │
    Authentication              Product Data
    Role-based Access           Barcode Data
          │                           │
          └─────────────┬─────────────┘
                        │
                  MongoDB Atlas
                        │
             ┌──────────┴──────────┐
             │                     │
         Billing              Inventory 
             │                     |
      PDF Generation          Synchronization
```

### 🔄 Barcode Workflow

Stock-er supports multiple ways to identify an inventory item:

```text
Physical Barcode Scanner
          │
          ├──────────────┐
          │              │
   Barcode String    Barcode Image
          │              │
          └───────┬──────┘
                  ↓
          Barcode Processing
                  ↓
          Product Retrieval
                  ↓
          Inventory / Billing
```
The application supports barcode generation as well as barcode-based product lookup.

### 👤 User Roles
- **Admin:**	Organization and user management, inventory, billing
- **Manager:**	Inventory, billing, and permitted user management
- **Staff:**	Inventory and billing operations

Access is scoped to the organization to prevent data from one organization being exposed to another.

### 🛠️ Technology

**Application**
C#
.NET / Windows Forms
Guna UI

**Database**
MongoDB
MongoDB Atlas

**Libraries & Tools**
BarcodeLib
ZXing.Net
BCrypt.Net
iTextSharp
Newtonsoft.Json
SkiaSharp
Microsoft.Extensions.Hosting
