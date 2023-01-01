<?php
include('connection.php');

$StudentID = $_POST['selectStudentID'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql = 
"SELECT 
s.StudentID, s.FirstName, s.LastName, s.Email, s.Password, s.Position, s.Gender, s.Birthdate, 
w.WorkStatus, w.RecruitmentDate, w.CommitteName,
p.PhoneNumber,
c.Major, c.Graduationyear,
cm.Role
FROM Student s
LEFT JOIN WorksFor w ON s.StudentID = w.StudentID
LEFT JOIN PhoneNumber p ON s.StudentID = p.StudentID
LEFT JOIN College c ON s.StudentID = c.StudentID
LEFT JOIN CommitteMember cm ON s.StudentID = cm.StudentID
WHERE s.StudentID = $StudentID
LIMIT 1";

$result = mysqli_query($connect, $sql);
if(mysqli_num_rows($result)>0)
{
    while($row = mysqli_fetch_assoc($result))
    {
        echo 
        $row['StudentID']."|".
        $row['FirstName']."|".
        $row['LastName']."|".
        $row['Email']."|".
        $row['Password']."|".
        $row['Position']."|".
        $row['Gender']."|".
        $row['Birthdate']."|".
        
        $row['WorkStatus']."|".
        $row['RecruitmentDate']."|".
        $row['CommitteName']."|".    

        $row['PhoneNumber']."|". 

        $row['Major']."|". 
        $row['Graduationyear']."|". 

        $row['Role']."|" 
        ;
    }
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>