# Reset (Delete migrations folder, delete database)
Enable-Migrations -ContextTypeName RestaurantEntity -EnableAutomaticMigrations  -Force
Add-Migration Initial


Update-Database