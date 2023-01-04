DROP DATABASE IF EXISTS `id20082774_club_management_system`;
CREATE DATABASE IF NOT EXISTS `id20082774_club_management_system`;
USE `id20082774_club_management_system`;

CREATE TABLE IF NOT EXISTS Student
(
  StudentID INT NOT NULL,
  FirstName VARCHAR(200) NOT NULL,
  LastName VARCHAR(200),
  Email VARCHAR(200) NOT NULL,
  Password VARCHAR(200) NOT NULL,
  Position VARCHAR(200) NOT NULL,
  Gender VARCHAR(200) NOT NULL,
  Birthdate VARCHAR(200),
  PRIMARY KEY (StudentID)
);

CREATE TABLE IF NOT EXISTS Committe
(
  CommitteName VARCHAR(200) NOT NULL,
  PRIMARY KEY (CommitteName)
);

CREATE TABLE IF NOT EXISTS Task
(
  TaskID INT NOT NULL AUTO_INCREMENT,
  TaskName VARCHAR (200) NOT NULL,
  CommitteName VARCHAR (200) NOT NULL,
  PRIMARY KEY (TaskID),
  FOREIGN KEY (CommitteName) REFERENCES Committe(CommitteName) ON DELETE CASCADE ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS Assigned
(
  TaskDate VARCHAR(200),
  TaskStatus VARCHAR(200) NOT NULL,
  StudentID INT NOT NULL,
  TaskID INT NOT NULL,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) 
	ON DELETE CASCADE 
	ON UPDATE NO ACTION,
  FOREIGN KEY (TaskID) REFERENCES Task(TaskID) 
	ON DELETE CASCADE 
	ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS College
(
  Major VARCHAR(200) NOT NULL,
  Graduationyear INT,
  StudentID INT NOT NULL,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS CommitteMember
(
  Role VARCHAR(200),
  StudentID INT NOT NULL,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS CommitteLeader
(
  CommitteName VARCHAR(200) NOT NULL,
  StudentID INT NOT NULL,
  FOREIGN KEY (CommitteName) REFERENCES Committe(CommitteName) ON DELETE CASCADE,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS PhoneNumber
(
  PhoneNumber VARCHAR(200) NOT NULL,
  StudentID INT NOT NULL,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS WorksFor
(
  WorkStatus VARCHAR(200) NOT NULL,
  RecruitmentDate VARCHAR(200) NOT NULL,
  CommitteName VARCHAR(200) NOT NULL,
  StudentID INT NOT NULL,
  FOREIGN KEY (CommitteName) REFERENCES Committe(CommitteName) ON DELETE CASCADE,
  FOREIGN KEY (StudentID) REFERENCES Student(StudentID) ON DELETE CASCADE
);

INSERT INTO Committe (CommitteName)
VALUES ('Media'), ('Public Relations'), ('Operations'), ('Technical'), ('Human Resources'), ('Marketing');

INSERT INTO Student (StudentID, FirstName, LastName, Email, Password, Position, Gender, Birthdate) VALUES 
(1, 'ADMIN', 'ADMIN', 'ADMIN@ADMING.COM', 'ADMIN1234', 'Leader', 'Male', '25-1-2002'), 
(202000005, 'Anas', 'Ahmed', 'A.Sayed@nu.edu.eg', 'anas1234', 'Leader', 'Male', '25-1-2002'),
(202000038, 'Youssef', 'Hisham', 'Y.Hisham@nu.edu.eg', 'youssef1234', 'Member', 'Male', '1-11-2002');

INSERT INTO WorksFor (WorkStatus, RecruitmentDate, CommitteName, StudentID) VALUES 
('Working', '01-01-2023', 'Technical', 202000005),
('Working', '01-02-2023', 'Media', 202000038);

INSERT INTO PhoneNumber (PhoneNumber, StudentID) VALUES
('01005828252', 202000005),
('01111161033', 202000005),
('01203737389', 202000038);

INSERT INTO College (Major, Graduationyear, StudentID) VALUES
('ITCS', 2024, 202000005),
('ENG', 2025, 202000038);

INSERT INTO CommitteMember (Role, StudentID) VALUES
('Graphic design', 202000038);

INSERT INTO CommitteLeader (CommitteName, StudentID) VALUES 
('Technical', 202000005);

INSERT INTO Task (TaskName, CommitteName) VALUES 
('Finish SQL task', 'Technical'),
('Design UGRF Poster', 'Media'),
('Video editing', 'Media');

INSERT INTO Assigned (TaskDate, TaskStatus, StudentID, TaskID) VALUES
('30-1-2023', 'Not Started', 202000005, 1),
('30-1-2023', 'In Progress', 202000038, 2),
('30-1-2023', 'Finished', 202000038, 3);

SELECT 
s.StudentID , s.FirstName , s.LastName , s.Email , s.Password , s.Position , s.Gender , s.Birthdate, 
w.WorkStatus, w.RecruitmentDate, w.CommitteName,
p.PhoneNumber,
c.Major, c.Graduationyear, 
cm.Role,
( SELECT COUNT(TaskStatus) FROM Assigned a WHERE a.TaskStatus='Not Started'AND s.StudentID= a.StudentID) AS 'Tasks Not Started', 
( SELECT COUNT(TaskStatus) FROM Assigned a WHERE a.TaskStatus='In Progress' AND s.StudentID= a.StudentID) AS 'Tasks In Progress', 
( SELECT COUNT(TaskStatus) FROM Assigned a WHERE a.TaskStatus='Finished' AND s.StudentID= a.StudentID) AS 'Tasks Finished'
FROM Student s 
LEFT JOIN WorksFor w ON s.StudentID = w.StudentID
LEFT JOIN PhoneNumber p ON s.StudentID = p.StudentID
LEFT JOIN College c ON s.StudentID = c.StudentID
LEFT JOIN CommitteMember cm ON s.StudentID = cm.StudentID
JOIN Assigned a ON s.StudentID = a.StudentID
WHERE s.StudentID = 202000038 Limit 1;

SELECT StudentID FROM WorksFor WHERE CommitteName = 'Media';

SELECT t.TaskID, s.FirstName, s.LastName FROM Task t
LEFT JOIN Assigned a ON t.TaskID = a.TaskID
LEFT JOIN Student s ON s.StudentID = a.StudentID
ORDER BY TaskID DESC LIMIT 1;

UPDATE Assigned
SET TaskStatus = "In Progress"
WHERE TaskID = 1;

SELECT t.TaskID, t.TaskName, t.CommitteName, a.TaskDate, a.TaskStatus, s.FirstName, s.LastName 
FROM Task t
LEFT JOIN Assigned a ON t.TaskID = a.TaskID
LEFT JOIN Student s ON s.StudentID = a.StudentID
WHERE t.TaskID = 1;