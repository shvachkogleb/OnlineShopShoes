🛍️ OnlineShop — ASP.NET Core E-Commerce Project

📖 Project Overview

OnlineShop is a modern e-commerce web application built with ASP.NET Core MVC and Entity Framework Core, using SQLite as the database.
It provides a full user experience — from registration and login to adding items to a cart and completing payment through a modal checkout form.

🚀 Main Features

👤 User Management

- User registration and login

- Session-based authentication (HttpContext.Session)

- Each user has a unique shopping session

🛒 Shopping Cart

- Add products to the cart

- Automatically calculate total quantity

- Entity Framework Core foreign key relationships between Users, Products, and CartItems

- View and manage user’s cart contents

💳 Checkout & Payment

- Payment modal opens upon clicking Buy

- Form includes cardholder name, card number, and CVV fields

- Data submission to the PaymentController for processing

- Ready for integration with real payment systems (Stripe, PayPal, etc.)

🔍 Product Search

- Search bar in the navigation bar

- Real-time JavaScript filtering by product name

- Highlights matching text dynamically

📦 Product Catalog

- Products stored in the Products table

Each card includes:

- Product image

- Name

- Price

- “Buy” and “Add to Cart” buttons

- Dynamically rendered using Razor Views

⚙️ Technologies Used

Category	Technologies:

Backend -	ASP.NET Core MVC (C#)

Database - ORM	Entity Framework Core, SQLite

Frontend - HTML, CSS, Bootstrap, JavaScript

Authentication	ASP.NET Session (HttpContext.Session)

Architecture	MVC (Model-View-Controller)


💾 Setup and Run Instructions
1. Clone the repository
git clone https://github.com/yourusername/OnlineShop.git

2. Install dependencies
dotnet restore

3. Apply database migrations
dotnet ef database update

4. Run the application
dotnet run

Then open http://localhost:5000
 in your browser.

🛠️ Possible Future Improvements:

Integrate real payment gateway (Stripe / PayPal)
Add order history per user
Implement filters (by price, brand, category)
Add user roles (Admin / Customer) and an admin dashboard
