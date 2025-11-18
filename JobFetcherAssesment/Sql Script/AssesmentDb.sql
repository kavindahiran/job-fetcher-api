CREATE DATABASE JobShedularDb;

	CREATE TABLE Machines (
		MachineId INT IDENTITY(1,1) PRIMARY KEY,
		MachineName VARCHAR(100) NOT NULL,
		Description VARCHAR(255),
		Capacity INT NULL, 
		Status VARCHAR(50) NOT NULL DEFAULT 'Active',
		CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
		UpdatedAt DATETIME NULL
	);    

	CREATE TABLE Jobs (
    JobId INT IDENTITY(1,1) PRIMARY KEY,
    JobName VARCHAR(100) NOT NULL,
    DurationInMinutes INT NOT NULL,
    StartTime DATETIME NULL,
    EndTime DATETIME NULL,
    Priority INT NOT NULL DEFAULT 1,
    Status VARCHAR(50) NOT NULL DEFAULT 'Pending',
    MachineId INT NULL,  
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    FOREIGN KEY (MachineId) REFERENCES Machines(MachineId)
);


INSERT INTO Machines (MachineName, Description, Capacity)
VALUES 
('Machine A', 'High speed cutter', 10),
('Machine B', 'Laser engraver', 5);


INSERT INTO Jobs (JobName, DurationInMinutes, Priority)
VALUES
('Job 1', 120, 2),
('Job 2', 45, 1),
('Job 3', 300, 3);