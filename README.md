# FlowerStore - An e-commerce web application for flower shopping

## 🌺 Overview
FlowerStore is a MVC application built to manage an online flower shop. It allows users to browse a catalog of flowers, add products to their shopping cart, place orders and more. Admins can manage products, view customer orders, assign roles and etc. </br>
</br>

⚠️ _The web project is created for the Project-Defence assignment at SoftUni in ASPT.NET Advanced 2024 course. It's still under development!_

⚠️ OldMigrations.zip in FlowerStore.Infrastructure contains migrations. They are ignored by the project, but still saved as .zip file. The reason behind this is orphaned tables, old relationships and testing records clearing and etc. Upon running the application for the first time the database should be clear as possible without any orders existing. 

## Features
💁 **_User Features:_**
  - Browse a paginated catalog with sorting options
  - Add or remove products to a shopping cart
  - Place orders and choose payment with card or cash (**⚠️NEVER SUBMIT REAL INFORMATION!⚠️**)
  - Have order history at the _**Account**_ page
  - Writing reviews (also editing and deleting own reviews)
  - Search products by name or category
  - Friendly error pages
  </br>
  
👑 **_Admin Features:_**
  - Add, edit and delete products
  - View paginated customer orders
  - Change statuses of customer orders
  - View and manage user roles
  - Have additional sorting options for product quantity
  - View all low-stock products (if any)
 </br>
 
## 💻 Used Technologies
  - C#
  - ASP.NET Core MVC
  - .NET 6
  - Entity Framework Core (Code-First approach)
  - Microsoft SQL Server
  - HTML5 & CSS3
  - Bootstrap 5
  - JavaScript
  </br>

## 🔒 Accounts
- Admin account:
Email: _admin@mail.com_  Password: _admin123_
- Guest account:
Email: _guest@guest.com_ Password: _guest123_
- Test account:
Email: _test@test.com_   Password: _test123_
- Random account:
Email: _random@random.com_ Password: _random123_

## 📷 Screenshots
Logged-out user in Reviews view:
![noReviews-logouted-scr](https://github.com/user-attachments/assets/39f92954-cba1-454a-88a5-c43b7650fda2)

User order history at Account page:
![ordersAccount-scr](https://github.com/user-attachments/assets/934357c2-ae8e-471b-b7d6-076bf1f2fe37)

All orders at Admin area with pagination:
![order-history-admin-scr](https://github.com/user-attachments/assets/8818f39e-640a-4a8a-9b4b-6ca6e0b281f4)

Search example (by name): 
![search-scr](https://github.com/user-attachments/assets/a2ff5a16-9ad6-4f52-949a-0ca2e8619e36)

Additional sorting options at Admin area:
![additionalOptsSort-scr](https://github.com/user-attachments/assets/e1fb0096-af78-4a93-8651-3bcc24e6435c)

Empty list of low-stock products at Admin area:
![noLowStockProds-scr](https://github.com/user-attachments/assets/ba4965dc-c55d-443f-ac5c-92e19d36e2ae)

