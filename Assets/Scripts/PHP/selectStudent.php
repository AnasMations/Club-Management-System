<?php
include('connection.php');

$StudentID = $_POST['selectStudentID'];

$sql = 
"SELECT * FROM Student
WHERE StudentID = $StudentID";

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

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
        $row['Birthdate'];
    }
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>