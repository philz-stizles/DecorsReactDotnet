# Decors

## Migrations

```bash
  Add-Migration Initial

  // Or
  Add-Migration InitialMigration -OutputDir Persistence/Migrations

  Update-Database
```

- Listing all migrations:

```bash
  Get-Migration
```

- Update database to a given migration:

```bash
  Update-database <Migration-Name>
```

- Remove last migration:

```bash
  Remove-Migration
```
