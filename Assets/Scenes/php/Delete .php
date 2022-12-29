<?php
include('connection.php');
$whereFiled = $_POST['whereField'];
$whereCondtion= $_POST['whereCondition'];
$sql= "delete from users where".$whereFiled."='".$whereCondtion."'";
$result = mysqli_query($connect,$sql);
?>