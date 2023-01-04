<?php
include('connection.php');

$TaskID = $_POST['selectTaskID'];
$TaskStatus = $_POST['updateTaskStatus'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql = "UPDATE Assigned
SET TaskStatus = '$TaskStatus'
WHERE TaskID = $TaskID";

if(mysqli_query($connect, $sql))
{
    echo "UPDATED Successfully";
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>