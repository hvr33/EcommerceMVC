# E-Commerce MVC

**Full-Stack E-Commerce Web Application** built with **.NET 8**, **C# 12**, and **ASP.NET Core MVC / Razor Pages**  
A complete online shopping platform with admin dashboard, role-based authorization, order & payment management.

---

## 🔹 Project Overview

- **Purpose**: Online storefront + powerful admin panel for managing products, categories, orders, users and more.
- **Frontend**: Responsive Razor Pages (Bootstrap 5 + jQuery)
- **Backend**: ASP.NET Core MVC, Entity Framework Core, SQL Server
- **Authentication**: Cookie-based with role authorization (Admin / Customer)
- **Payments**: Modular / pluggable (PayPal implemented – easy to extend)

---

## 🔹 Key Features

### Storefront (Customer-facing)
- Browse, search and filter products
- Detailed product pages with images, description & price
- Session-based shopping cart
- Multi-step checkout (address → shipping → payment)

### Products & Inventory Management
- Full CRUD for products, categories and images (admin only)
- Manage stock quantity, pricing, variants

### Orders & Fulfillment
- Order status tracking: Placed → Paid → Shipped → Cancelled → Refunded
- Export orders to CSV / Excel
- Customers can view and track their own orders

### Admin Dashboard
- Manage products, categories, users, roles & permissions
- Sales overview, analytics and reports

### Reporting & Analytics
- Daily, weekly, monthly sales reports
- Simple charts and summary tables

---

## 🔹 Tech Stack

| Layer            | Technology                                      |
|------------------|-------------------------------------------------|
| Backend          | .NET 8, C# 12, ASP.NET Core MVC / Razor Pages   |
| Database         | SQL Server + Entity Framework Core              |
| Frontend         | Bootstrap 5, jQuery, HTML5, CSS3                |
| Authentication   | Cookie Authentication + Role-based              |
| Payments         | PayPal (extensible – Stripe-ready architecture) |
| Development      | Visual Studio 2022, EF Core Migrations          |

---

## 🔹 Project Structure (high-level)
E-Commerce/
├── Controllers/          → MVC Controllers
├── Models/               → Domain models & ViewModels
├── Views/                → Razor views (.cshtml)
├── wwwroot/              → Static files (css, js, images)
├── Areas/                → (optional) Admin / Identity areas
├── Migrations/           → EF Core database migrations
├── App_Data/             → Seed data or config files
└── E-Commerce.sln

---

## 🔹 Database Schema (simplified)

- **Users** → id, username, password, role_id, created_at
- **Roles** → id, name
- **Products** → id, name, description, price, category_id, stock_quantity
- **Categories** → id, name, parent_id
- **ProductImages** → id, product_id, image_url, alt_text
- **Orders** → id, user_id, status, total_amount, shipping_address_id
- **OrderItems** → id, order_id, product_id, quantity, unit_price
- **Payments** → id, order_id, method, status, transaction_id

---

## 🔹 Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 (or later) or VS Code + C# Dev Kit
- SQL Server (Express edition is fine)

### Steps

## Run Entity Framework Migrations
```bash
dotnet ef migrations add InitialCreate 
dotnet ef database update 
```
# 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

---
Built with ❤️ by Asmaa Mostafa
