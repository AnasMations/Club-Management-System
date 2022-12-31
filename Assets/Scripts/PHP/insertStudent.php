<?php
include('connection.php');

$StudentID = $_POST['addStudentID'];
$FirstName = $_POST['addFirstName'];
$LastName = $_POST['addLastName'];
$Email = $_POST['addEmail'];
$Password = $_POST['addPassword'];
$Position = $_POST['addPosition'];
$Gender = $_POST['addGender'];
$Birthdate = $_POST['addBirthdate'];

$sql = 
"INSERT INTO Student (StudentID, FirstName, LastName, Email, Password, Position, Gender, Birthdate) 
VALUES ($StudentID, '$FirstName', '$LastName', '$Email', '$Password', '$Position', '$Gender', '$Birthdate')";

echo "$StudentID $FirstName $LastName $Email $Password $Position $Gender $Birthdate\n";

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$result = mysqli_query($connect, $sql);
if($result)
{
    echo "Student '$FirstName' $StudentID was created successfully!";
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>