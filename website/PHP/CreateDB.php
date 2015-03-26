<?php
	include 'config.php';
	
	// Create database
	$sql = "CREATE DATABASE DBMobyDick";
	if ($conn->query($sql) === TRUE) {
	    echo "Database created successfully";
	} else {
	    echo "Error creating database: " . $conn->error;
	}

	$conn->close();
?>