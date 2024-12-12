# SaintLibrary

La soluzione è progettata per gestire i dati di una libreria, concentrandosi sull'organizzazione e la gestione di tre entità principali: Libri, Autori e Categorie.
La struttura è stata sviluppata in C# con l'obiettivo di mantenere una chiara separazione delle responsabilità e garantire un codice leggibile e manutenibile.

# Architettura del Sistema

## Struttura a tre livelli (Three-Tier Architecture):

**Presentation Layer:**
Responsabile dell'interfaccia utente o dell'interazione con l'utente.

**Business Logic Layer (BLL):** 
Gestisce la logica del dominio, come l'associazione di libri agli autori o la categorizzazione dei libri.

**Data Access Layer (DAL):** 
Fornisce metodi per accedere ai dati dal database, inclusi CRUD (Create, Read, Update, Delete).


# Tecnologie Utilizzate

- Linguaggio: C# 11
- Framework: .NET 8
- Database: SQL Server 
- ORM : Entity Framework
