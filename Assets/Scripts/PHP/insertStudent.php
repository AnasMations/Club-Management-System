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

$WorkStatus = $_POST['addWorkStatus'];
$RecruitmentDate = $_POST['addRecruitmentDate'];
$CommitteName = $_POST['addCommitteName'];

$PhoneNumber = $_POST['addPhoneNumber'];

$Major = $_POST['addMajor'];
$Graduationyear = $_POST['addGraduationyear'];

$Role = $_POST['addRole'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql1 = "INSERT INTO Student (StudentID, FirstName, LastName, Email, Password, Position, Gender, Birthdate) 
VALUES ($StudentID, '$FirstName', '$LastName', '$Email', '$Password', '$Position', '$Gender', '$Birthdate')";

$sql2 = "INSERT INTO WorksFor (WorkStatus, RecruitmentDate, CommitteName, StudentID) 
VALUES ('$WorkStatus', '$RecruitmentDate', '$CommitteName', $StudentID)";

$sql3 = "INSERT INTO PhoneNumber (PhoneNumber, StudentID) 
VALUES ('$PhoneNumber', $StudentID)";

$sql4 = "INSERT INTO College (Major, Graduationyear, StudentID)
VALUES ('$Major', $Graduationyear, $StudentID)";

if($Position == "Member"){
    $sql5 = "INSERT INTO CommitteMember (Role, StudentID)
    VALUES ('$Role', $StudentID)";
} else{
    $sql5 = "INSERT INTO CommitteLeader (CommitteName, StudentID) 
    VALUES ('$CommitteName', $StudentID)";
}

if(mysqli_query($connect, $sql1)){
    echo "Query 1 successful!";
}else{
    echo "ERROR Query 1: " . $connect -> error;
}

if(mysqli_query($connect, $sql2)){
    echo "Query 2 successful!";
}else{
    echo "ERROR Query 2: " . $connect -> error;
}

if(mysqli_query($connect, $sql3)){
    echo "Query 3 successful!";
}else{
    echo "ERROR Query 3: " . $connect -> error;
}

if(mysqli_query($connect, $sql4)){
    echo "Query 4 successful!";
}else{
    echo "ERROR Query 4: " . $connect -> error;
}

if(mysqli_query($connect, $sql5)){
    echo "Query 5 successful!";
}else{
    echo "ERROR Query 5: " . $connect -> error;
}

?>