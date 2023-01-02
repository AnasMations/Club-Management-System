<?php
include('connection.php');

$Type = $_POST['selectType'];
$ID = $_POST['selectID'];

if (!$connect) {
    die("ERROR Connection failed: " . mysqli_connect_error());
}

$sql = "DELETE FROM $Type WHERE ".$Type."ID = $ID";

if(mysqli_query($connect, $sql))
{
    echo "DELETED Successfully";
}else
{
    echo "ERROR Query: " . $connect -> error;
}
?>