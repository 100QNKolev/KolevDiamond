# KolevDiamond
**Име:** Стоян Колев
**Факултетен номер:** 2401322004

## Описание на проекта

KolevDiamond е уеб приложение за онлайн магазин за бижута и инвестиционни продукти. Проектът предлага каталог с пръстени, колиета, кюлчета, инвестиционни диаманти и инвестиционни монети. Разполага с публична част за разглеждане на продуктите и административен панел за управление на каталога (добавяне, редактиране и изтриване на продукти).

Проектът е изграден върху разделена архитектура:
- **KolevDiamond** — REST API backend (ASP.NET Core Web API, JWT автентикация, MySQL)
- **KolevDiamond.Web** — MVC frontend (ASP.NET Core MVC, cookie authentication, комуникация с API)
- **KolevDiamond.Core** — бизнес логика, услуги и модели
- **KolevDiamond.Infrastructure** — база данни, Entity Framework Core, миграции

## Изисквания

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (порт 3306)

## Инсталация

1. Клонирайте хранилището:
   ```bash
   git clone <repository-url>
   cd course-work/Implementations/KolevDiamond
   ```

2. Конфигурирайте връзката към базата данни в `appsettings.json` (API проект):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;port=3306;database=KolevDiamondApi;user=root;password=<вашата-парола>;"
   }
   ```

3. Приложете миграциите за създаване на базата данни:
   ```bash
   dotnet ef database update --project KolevDiamond.Infrastructure --startup-project .
   ```

## Стартиране

Проектът изисква едновременно стартиране на два сървъра.

**1. Стартирайте API-то** (в нова конзола):
```bash
cd course-work/Implementations/KolevDiamond
dotnet run
```
API-то ще се стартира на `http://localhost:5111`.  
Swagger UI е достъпен на: `http://localhost:5111/swagger`

**2. Стартирайте уеб приложението** (в нова конзола):
```bash
cd course-work/Implementations/KolevDiamond/KolevDiamond.Web
dotnet run
```

Приложението ще бъде достъпно на `https://localhost:<port>` (портът се изписва в конзолата при стартиране).
