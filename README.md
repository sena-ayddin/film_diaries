# 🎬 FilmDiaries (ASP.NET MVC 5)

FilmDiaries is a movie and series platform: users browse titles by genre, keep a watchlist, and rent (subscription) or buy what they want to watch. Admins manage the catalog, users and notifications.

Built for **COM5005 Web Programming – Group 16** (2026).
The static Task 1 version lives in the separate `FilmDiaries` repository.

---

## 🚀 How to Run

1. Clone the repo: **Git → Clone Repository** in Visual Studio.
2. Open `film_diaries.sln`.
3. Restore NuGet packages (Visual Studio does this on build).
4. Make sure SQL Server LocalDB is installed. The connection string is in `Web.config` (`FilmDiariesContext`).
5. Press **F5**. The database is created and seeded on first run.

---

## 🛠️ Tech Stack

- ASP.NET MVC 5 (.NET Framework 4.7.2), C#, Razor
- Entity Framework 6 (Code First), Microsoft SQL Server
- HTML, CSS, JavaScript, jQuery

---

## 📐 Team Conventions (everyone follows these names)

> Names marked **(proposed)** are suggestions. If the team changes one, update this file in the same commit.

### Models (`Models/` folder)

Property names are exactly the field names in the Task 1 analysis report.

| Class | Database table | Primary key | Notes |
| :--- | :--- | :--- | :--- |
| `User` | User | `UserID` (long) | `UserName`, `UserEmail`, `UserPasswordHash`, `CreatedAt` |
| `Admin` | Admin | `AdminID` (int) | `AdminName`, `AdminEmail`, `AdminPasswordHash` |
| `Genre` | Genre | `GenreID` (int) | `GenreName`, `GenreDescription` |
| `Content` | Content | `ContentID` (long) | `ContentTitle`, `ContentDuration`, `ContentDescription`, `ContentType`, `ContentAccessType`, `ContentReleaseDate`, `PosterURL`, `MediaURL` |
| `ContentGenre` | ContentGenre | `ContentID` + `GenreID` | composite key |
| `WatchList` | WatchList | `WatchListID` (int) | FK `UserID` |
| `WatchListItem` | WatchListItems | `WatchListID` + `ContentID` | composite key, `AddedAt` |
| `WatchHistory` | WatchHistory | `WatchHistoryID` (int) | FK `UserID` |
| `WatchHistoryItem` | WatchHistoryItems | `WatchHistoryID` + `ContentID` | composite key, `Completed`, `LastWatchedAt`, `StoppedAt`, `SeasonNumber`, `EpisodeNumber` |
| `Subscription` | Subscription | `SubscriptionID` (int) | FK `UserID`, `StartAt`, `EndAt`, `CancelledAt`, `MonthlyFee`, `Status` |
| `Purchase` | Purchase | `PurchaseID` (int) | FK `UserID`, `ContentID`, `PurchaseDate`, `PurchasePrice` |
| `Notification` | Notifications | `NotificationID` (int) | FK `AdminID`, `Title`, `Message`, `SendAt` |
| `UserNotification` | UserNotification | `NotificationID` + `UserID` | composite key, `IsRead`, `ReadAt` |

Rules:
- Composite keys use `[Key, Column(Order = 0)]` and `[Key, Column(Order = 1)]`.
- Use `[Table("...")]` so database table names match the table names above.
- Validation rules go on the model with Data Annotations (`[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`).

### Database
- DbContext class: `FilmDiariesContext` **(proposed)**, file `Models/FilmDiariesContext.cs`.
- Connection string name: `FilmDiariesContext` **(proposed)**.
- Seed data (genres, sample content, one admin, one test user) lives in the DbContext initializer.

### Roles and authorization
- Role names are exactly `"Admin"` and `"User"` (case-sensitive).
- Admin pages: `[Authorize(Roles = "Admin")]`.
- Pages that need a login (My List, Watch History, Settings, Profile): `[Authorize]`.
- Login checks the `User` table, then the `Admin` table, and stores the role on sign-in **(proposed)**.

### Controllers and views **(proposed)**

| Area | Controllers | Owner |
| :--- | :--- | :--- |
| Login / Register | `AccountController` | Authentication |
| Database and models | `Models/` folder, `FilmDiariesContext` | Database |
| User pages | `HomeController`, `MoviesController`, `SeriesController`, `WatchListController`, `WatchHistoryController`, `ProfileController` | User pages |
| Admin pages | `AdminDashboardController`, `AdminContentController`, `AdminGenreController`, `AdminUserController`, `AdminNotificationController` | Admin |

- Public layout: `Views/Shared/Layout.cshtml`. Admin layout: `Views/Shared/AdminLayout.cshtml`.
- Page-specific CSS goes in `@section Styles`, page-specific JS in `@section Scripts`.

### Folders
```
film_diaries/
├── Controllers/
├── Models/
├── Views/            (Shared/, Home/, Movies/, Admin*/ ...)
├── Content/
│   ├── css/
│   └── images/
├── Scripts/
└── App_Start/
```

---

## 🔀 Git Rules

1. **Git → Pull** before you start working.
2. Commit small and often, then **Commit All and Push**.
3. Only edit your own files. Tell the team before changing `Layout.cshtml`, `Web.config` or `FilmDiariesContext.cs`, because these cause merge conflicts.
4. Never commit `bin/`, `obj/` or `.vs/` (the `.gitignore` already excludes them).

---

## 📅 Deadline

Task 2 (final project as a RAR file, including the SQL Server database): **Friday, 04 December 2026, 23:55**.

---

## 👥 Group 16

Buket Pehlivanoğlu (Team Captain), Sena Yavuzer, İdil Kılıç, Sena Aydın, Azad Altuntop.

## 📄 License

Created for educational purposes under the COM5005 Web Programming course. © 2026 Group 16.
