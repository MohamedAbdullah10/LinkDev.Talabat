 Talabat E-Commerce API
Modern E-Commerce API built with ASP.NET Core 8 & modern Onion Architecture

A production-ready e-commerce platform demonstrating clean code principles and enterprise-level features.

🚀 Key Features
🧅 Onion Architecture with clean separation of concerns
🔐 JWT Authentication with ASP.NET Core Identity
🛍️ Complete E-Commerce Flow (Products, Cart, Orders, Payments)
💳 Stripe Payment Integration with webhooks
💾 Multi-Database Support (SQL Server + Redis)
📚 Auto-Generated API Documentation with Swagger
🚀 High Performance with caching and async operations
🏗️ Architecture
📁 Core Layer
├── Domain/                    # Entities & Business Rules
├── Application/               # Business Logic & Services  
└── Application.Abstraction/   # Interfaces & DTOs

📁 Infrastructure Layer
├── Persistence/               # Data Access & EF Core
└── Infrastructure/            # External Services (Redis, Stripe)

📁 Presentation Layer
├── APIs/                      # RESTful Web API
└── Controllers/               # API Controllers
✨ Main Features
🛍️ E-Commerce
Product Management - Browse, search, filter products
Shopping Cart - Redis-based cart persistence
Order Management - Complete order workflow
Payment Processing - Secure Stripe integration
User Authentication - Registration, login, profile management
🔧 Technical
Repository Pattern with Unit of Work
Specification Pattern for complex queries
Global Exception Handling with custom middleware
Response Caching with Redis
Database Migrations with seed data
🛠️ Tech Stack
ASP.NET Core 8.0 - Web API framework
Entity Framework Core 8.0 - ORM with SQL Server
ASP.NET Core Identity - Authentication
AutoMapper - Object mapping
Redis - Caching and sessions
Stripe - Payment processing
JWT - Token authentication
🏃‍♂️ Quick Start
Prerequisites
.NET 8 SDK
SQL Server (LocalDB/Express)
Redis Server
📚 API Endpoints
Authentication
POST /api/account/register    # Register user
POST /api/account/login       # User login
GET  /api/account            # Get current user
PUT  /api/account/address    # Update address
Products
GET  /api/products           # Get products (paginated)
GET  /api/products/{id}      # Get product by ID
GET  /api/products/brands    # Get brands
GET  /api/products/categories # Get categories
Shopping Cart
GET    /api/basket/{id}      # Get basket
POST   /api/basket          # Update basket
DELETE /api/basket/{id}     # Delete basket
Orders
GET  /api/orders            # Get user orders
POST /api/orders            # Create order
GET  /api/orders/{id}       # Get order details
Payments
POST /api/payments/{basketId} # Create payment intent
POST /api/payments/webhook   # Stripe webhook
🏗️ Project Structure
📁 LinkDev.Talabat/
├── 🎯 LinkDev.Talabat.APIs/              # Web API Entry Point
├── 🎮 LinkDev.Talabat.APIs.Controllers/  # Controllers & DTOs
├── 🧠 LinkDev.Talabat.Core.Domain/       # Domain Entities
├── 🔧 LinkDev.Talabat.Core.Application/  # Business Services
├── 📋 LinkDev.Talabat.Core.Application.Abstraction/ # Interfaces
├── 💾 LinkDev.Talabat.Infrastructure.Persistence/   # Data Access
├── 🔌 LinkDev.Talabat.Infrastructure/    # External Services
├── 🖥️ LinkDev.Talabat.Dashboard/        # Admin Dashboard
└── 🧪 LinkDev.Talabat.Application.Tests/ # Tests
🔒 Security Features
JWT token-based authentication
Password hashing with Identity
Role-based authorization
Account lockout protection
Input validation
CORS configuration
🚀 Performance Features
Redis distributed caching
Response caching middleware
Async/await throughout
Entity Framework optimizations
Connection pooling
⭐ Star this repository if you find it helpful!

Built with ❤️ using ASP.NET Core 8 and Onion Architecture
