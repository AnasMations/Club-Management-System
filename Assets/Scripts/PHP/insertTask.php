<?php
include('connection.php');

$StudentID = $_POST['addStudentID'];
$TaskName = $_POST['addTaskName'];
$CommitteName = $_POST['addCommitteName'];
$TaskDate = $_POST['addTaskDate'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql1 = "INSERT INTO Task (TaskName, CommitteName) 
VALUES ('$TaskName', '$CommitteName')";

if(!mysqli_query($connect, $sql1)){
    echo "ERROR Query 1: " . $connect -> error;
}

$sql2 = "SELECT t.TaskID, s.FirstName, s.LastName FROM Task t
LEFT JOIN Assigned a ON t.TaskID = a.TaskID
LEFT JOIN Student s ON s.StudentID = a.StudentID
ORDER BY TaskID DESC LIMIT 1";
$TaskID;

$result = mysqli_query($connect, $sql2);
if($result){
    while($row = mysqli_fetch_assoc($result))
    {
        echo $row['TaskID']."|".$row['FirstName']."|".$row['LastName'];

        $TaskID = $row['TaskID'];
    }
    
}else{
    echo "ERROR Query 2: " . $connect -> error;
}

$sql3 = "INSERT INTO Assigned (TaskDate, TaskStatus, StudentID, TaskID) 
VALUES ('$TaskDate', 'Not Started', $StudentID, $TaskID)";

if(!mysqli_query($connect, $sql3)){
    echo "ERROR Query 3: " . $connect -> error; 
}

?>