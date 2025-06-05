# GiftelleCMS 🎁

GiftelleCMS is a Content Management System built using ASP.NET Core and Entity Framework Core. It allows administrators to manage vendors, products, orders, and order items for a gifting platform.

## 📌 Features

- 🔒 Authentication-ready (ASP.NET Identity scaffolding included)
- 🛍️ Vendor and Product management
- 🧾 Orders and Order Items tracking
- ⚙️ RESTful API with CRUD functionality
- 📦 Code-first database setup using EF Core with SQL Server Express

---

## 🚀 Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core (Code First)
- SQL Server 2022 Express
- C#

---

## 🧱 Entity Relationships

- `Vendor` ↔ `Product` — One-to-Many
- `Order` ↔ `OrderItem` ↔ `Product` — Many-to-Many (via bridge `OrderItem`)
