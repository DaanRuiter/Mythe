<?php
	include 'config.php';
	
	$username = $_REQUEST['username'];
	$deviceId = $_REQUEST['deviceId'];
	$score = $_REQUEST['score'];
	$screenshot = $_REQUEST['fileToUpload'];
		
	$sql = "INSERT INTO Users (Username, DeviceId, HighScore)
	VALUES ('$username', '$deviceId', '$score')";

	if ($conn->query($sql) === TRUE) {
	    echo "New record created successfully";
	} else {
	    echo "Error: " . $sql . "<br>" . $conn->error;
	}
?>