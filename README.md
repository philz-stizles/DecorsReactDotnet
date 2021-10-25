# Decors

## User Secrets

    Open terminal in Project root directory: right-click > Open in Terminal

    Add secret:
      ```bash
       dotnet user-secrets "JwtSettings:SecretKey" "SomeVeryLongSecret"
      ```

    List secrets:
      ```bash
       dotnet user-secrets list
      ```

    Remove secret/clear all secrets:
      ```bash
        <!-- Remove secret -->
        dotnet user-secrets remove "JwtSettings:SecretKey"
        <!-- Clear all secrets -->
        dotnet user-secrets clear
      ```

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

## Payments

    PCI DSS Compliance:

    Web hooks:
