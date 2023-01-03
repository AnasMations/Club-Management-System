<?php
include('connection.php');

$TaskID = $_POST['selectTaskID'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql = 
"SELECT t.TaskID, t.TaskName, t.CommitteName, a.TaskDate, a.TaskStatus, s.FirstName, s.LastName 
FROM Task t
LEFT JOIN Assigned a ON t.TaskID = a.TaskID
LEFT JOIN Student s ON s.StudentID = a.StudentID
WHERE t.TaskID = $TaskID";

$result = mysqli_query($connect, $sql);
if(mysqli_num_rows($result)>0)
{
    while($row = mysqli_fetch_assoc($result))
    {
        echo 
        $row['TaskID']."|".
        $row['TaskName']."|".
        $row['CommitteName']."|".
        $row['TaskDate']."|".
        $row['TaskStatus']."|".
        $row['FirstName']."|".
        $row['LastName']
        ;
    }
}else
{
    echo mysqli_num_rows($result);
    echo "ERROR Query: " . $connect -> error;
}
?>