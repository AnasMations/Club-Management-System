<?php
include('connection.php');

$CommitteName = $_POST['selectCommitteName'];

$sql = 
"SELECT StudentID, CommitteName FROM WorksFor
WHERE CommitteName = $CommitteName";

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$result = mysqli_query($connect, $sql);
if(mysqli_num_rows($result)>0)
{
    while($row = mysqli_fetch_assoc($result))
    {
        echo $row['StudentID'];
    }
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>