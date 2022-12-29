<?PHP
include('connection.php');
$FirstName = $_POST['addFirstname'];
$LastName = $_POST['addLastname'];
$Email = $_POST ['addPassword'];
$Password = $_POST['addPassword'];
$Committename = $_POST['addCommittename'];
$Position = $_POST['addPostion'];
$StudentID = $_POST['addStudentID'];
$Majo = $_POST['addMajo'];
$Graduationyear = $_POST['addGraduationyear'];
$Birthdate = $_POST['addBirthdate'];
$sql = "insert into Student (Email, Password,FirstName,LastName,Position,StudentID,Birthdate)  Values ('".$Email."','".$Password."','".$FirstName."','".$LastName."','".$Position."','".$StudentID."','".$Birthdate."')";
$sql = "insert into College  (Majo,Graduationyear)  Values ('".$Majo."','".$Graduationyear."')";
$sql = "insert into Committe  (Committename)  Values ('".$Committename."')";
$result = mysqli_query($connect,$sql);