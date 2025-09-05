# 📚 QuanlyThuvien — ASP.NET MVC
> Ứng dụng quản lý thư viện: sách, độc giả, mượn–trả, phạt trễ hạn, báo cáo thống kê.

![.NET](https://img.shields.io/badge/.NET-8.0_or_4.8-512BD4)
![ASP.NET MVC](https://img.shields.io/badge/Framework-ASP.NET%20MVC-blue)
![SQL Server](https://img.shields.io/badge/DB-SQL%20Server-informational)
![Build](https://img.shields.io/badge/build-passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-inactive)


## ✨ Tính năng chính
- [ ] **Quản lý sách** (ISBN, tiêu đề, thể loại, tác giả, NXB, số lượng)
- [ ] **Quản lý độc giả** (thông tin, thẻ thư viện, trạng thái)
- [ ] **Mượn/Trả** (ngày mượn, hạn trả, gia hạn, trả quá hạn)
- [ ] **Tính phạt trễ** (quy tắc tính, miễn/giảm phạt theo quyền)
- [ ] **Tìm kiếm & lọc** (theo tên sách, tác giả, thể loại, trạng thái)
- [ ] **Báo cáo** (top sách mượn nhiều, tồn kho, độc giả hoạt động)
- [ ] **Phân quyền** (Admin/Nhân viên)

---

## 🧱 Kiến trúc & Công nghệ
- **Web**: ASP.NET Core MVC **(khuyến nghị)** hoặc ASP.NET MVC 5
- **ORM**: Entity Framework Core / EF6
- **CSDL**: SQL Server
- **UI**: Razor Views, Bootstrap/Tailwind, jQuery/Alpine
- **Auth**: ASP.NET Identity / Cookie Auth / OpenID Connect


##  Yêu cầu hệ thống
**ASP.NET Core MVC:**
- .NET SDK ≥ 8.0
- Visual Studio 2022 (hoặc VS Code + C# Dev Kit)
- SQL Server (Developer/Express) / Docker

**ASP.NET MVC 5:**
- .NET Framework 4.8 Developer Pack
- Visual Studio 2019/2022
- SQL Server (LocalDB/Express)

---

##  Cài đặt & Chạy (local)

**Mẫu `appsettings.json`:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Phương án B — ASP.NET MVC 5
1) Mở solution bằng **Visual Studio** → **Restore NuGet Packages**  
2) Cập nhật `web.config` connection string  
3) Chạy với **IIS Express** (F5)

**Trích đoạn `web.config` (`connectionStrings`):**
```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDb;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

## 🔐 Seed dữ liệu & Tài khoản mẫu
- Thêm `DbInitializer`/`SeedData` để tạo **Role** (Admin/Librarian/Reader) và user mặc định.
- Gợi ý tài khoản demo:
  - **Admin**: `admin` / `123456`

---

## 🧰 Entity Framework nhanh (Code First)
**EF Core:**
```bash
dotnet ef migrations add Init --project src/Infrastructure --startup-project src/WebApp
dotnet ef database update --project src/Infrastructure --startup-project src/WebApp
```

**EF6 (MVC5):** dùng **Package Manager Console**  
```
Enable-Migrations
Add-Migration Init
Update-Database
```


## 🧪 Kiểm thử
```bash
dotnet test   # với dự án test .NET
```
Hoặc chạy NUnit/xUnit/MSTest trong Visual Studio.

---

## 🚢 Triển khai
1. Cài **ASP.NET Core Hosting Bundle** trên máy chủ Windows
2. `dotnet publish -c Release -o publish`
3. Trỏ IIS tới thư mục `publish`, cấu hình biến môi trường (ASPNETCORE_ENVIRONMENT, ConnectionStrings__DefaultConnection)

### IIS (MVC 5)
- Publish từ Visual Studio (Web Deploy/File System), App Pool .NET v4.0

### Azure App Service
- Publish profile từ VS, hoặc GitHub Actions

**Mẫu GitHub Actions (.NET build & test):**
```yaml
name: ci
on: [push, pull_request]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'
      - run: dotnet restore
      - run: dotnet build --configuration Release --no-restore
      - run: dotnet test --no-build --verbosity normal
```

### Docker (ASP.NET Core)
```Dockerfile
# build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish src/WebApp -c Release -o /app

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "WebApp.dll"]
```

---

## 🗂️ Mô hình dữ liệu (gợi ý)
- `Book` (Id, Isbn, Title, CategoryId, AuthorId, PublisherId, Quantity, Available, ...)
- `Reader` (Id, Name, Email, Phone, CardNumber, Status, ...)
- `Loan` (Id, BookId, ReaderId, BorrowedAt, DueAt, ReturnedAt, FineAmount, ...)
- `Author`, `Publisher`, `Category`
- `User`, `Role` (nếu dùng Identity)

---

## 🗺️ Roadmap
- [ ] Tra cứu tồn kho theo vị trí kệ
- [ ] Quy tắc phạt tuỳ biến
- [ ] Xuất PDF/Excel báo cáo
- [ ] Audit log & bảng hoạt động gần đây
- [ ] API phục vụ mobile

---

## 🤝 Đóng góp thêm
1. Fork repo
2. Tạo nhánh: `feat/ten-tinh-nang`
3. Commit có ý nghĩa
4. Mở Pull Request

---

## 📬 Liên hệ
- Tác giả: Trần Phúc Bình
- Email: tranphucbinh201@gmail.com
