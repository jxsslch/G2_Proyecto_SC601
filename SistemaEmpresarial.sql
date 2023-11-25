-- Crear la base de datos
CREATE DATABASE SistemaEmpresarial;
USE SistemaEmpresarial;

-- Crear tabla Empresa
CREATE TABLE Empresa (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
	numTelefono INT NOT NULL,
	email VARCHAR(100) NOT NULL,
);

-- Crear tabla MetodoPago
CREATE TABLE MetodoPago (
    ID INT PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL
);

-- Crear tabla Provincia
CREATE TABLE Provincia (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Crear tabla Canton
CREATE TABLE Canton (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    ProvinciaID INT,
    CONSTRAINT FK_PROVINCIA FOREIGN KEY (ProvinciaID) REFERENCES Provincia(ID)
);

-- Crear tabla Lenguaje
CREATE TABLE Lenguaje (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Crear tabla Moneda
CREATE TABLE Moneda (
    ID INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Crear tabla Cliente
CREATE TABLE Cliente (
    Cedula INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	numTelefono INT NOT NULL,
    EmpresaID INT,
    ProvinciaID INT,
    CantonID INT,
    CONSTRAINT FK_EMPRESA FOREIGN KEY (EmpresaID) REFERENCES Empresa(ID),
    CONSTRAINT FK_PROVINCIA_CLIENTE FOREIGN KEY (ProvinciaID) REFERENCES Provincia(ID),
    CONSTRAINT FK_CANTON FOREIGN KEY (CantonID) REFERENCES Canton(ID)
);

-- Crear tabla Transacciones
CREATE TABLE Transacciones (
    ID INT PRIMARY KEY,
    ClienteID INT,
    LenguajeID INT,
    MonedaID INT,
    MetodoPagoID INT,
    Monto DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_CLIENTE FOREIGN KEY (ClienteID) REFERENCES Cliente(Cedula),
    CONSTRAINT FK_LENGUAJE FOREIGN KEY (LenguajeID) REFERENCES Lenguaje(ID),
    CONSTRAINT FK_MONEDA FOREIGN KEY (MonedaID) REFERENCES Moneda(ID),
    CONSTRAINT FK_METODOPAGO FOREIGN KEY (MetodoPagoID) REFERENCES MetodoPago(ID)
);
