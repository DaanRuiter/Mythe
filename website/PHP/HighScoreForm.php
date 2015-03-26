<?php
	include 'config.php';
	
	$username = $_REQUEST['username'];
	$deviceId = $_REQUEST['deviceId'];
	$score = $_REQUEST['score'];
		
	if($username == null)
	{
		$username = "Default";	
	}
	
	$sql = "INSERT INTO Users (Username, DeviceId, HighScore)
	VALUES ('$username', '$deviceId', '$score')";

	if ($conn->query($sql) === TRUE) {
	    echo "New record created successfully";
	} else {
	    echo "Error: " . $sql . "<br>" . $conn->error;
	}
?>