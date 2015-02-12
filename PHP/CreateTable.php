<?php
	include 'config.php';
	
	$sql = "CREATE TABLE Users (
	Id INT(8) UNSIGNED AUTO_INCREMENT PRIMARY KEY, 
	Username VARCHAR(30) NOT NULL,
	DeviceId VARCHAR(30) NOT NULL, 
	HighScore INT(50),
	RegDate TIMESTAMP
	)";
	
	if ($conn->query($sql) === TRUE) {
	    echo "Table MyGuests created successfully";
	} else {
	    echo "Error creating table: " . $conn->error;
	}

	$conn->close();
?>
