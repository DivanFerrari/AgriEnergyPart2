# 🌱 Agri-Energy Connect Web App – Prototype

Welcome to the **Agri-Energy Connect** prototype! This application is part of a digital platform that aims to support sustainable farming practices by connecting farmers and agricultural products with a centralized system.

---

## 🚀 About the Project

This web app was developed as a prototype for a proposed enterprise solution that integrates **green energy practices** with **agriculture**. It uses **two APIs** for managing:

- 🥬 **Products** – Fully working: view products that are stored to SQL Server database from web app (MVC).
- 🧑‍🌾 **Farmers** – Not fully working: allows interface-based farmer creation, but **does not save** to the database.

---

## ❌ Known Limitations

> ⚠️ **Important Note:**  
> Currently, the **login system is not implemented or functional**.  
> All functionality is accessed **without authentication** at this stage of development.

---

## 🔧 Features Overview

### 🥬 Product API (Working)
- ✅ View all products.
- ✅ Add a new product with fields like name, category, and production date.
- 💾 Data is saved directly to the SQL Server database.

### 🧑‍🌾 Farmer API (Not working)
- ⚠️ UI allows form-based creation of farmer profiles.
- ❌ Data is **not inserted into the database** yet.

---

## 🛠️ Tech Stack

| Layer        | Technology               |
|--------------|--------------------------|
| Frontend     | ASP.NET MVC (Razor Pages)|
| Backend      | C#, .NET                 |
| Database     | SQL Server Management Studio |
| APIs         | RESTful (Product + Farmer) |

---

## 🗂️ Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/agri-energy-connect.git
cd agri-energy-connect
