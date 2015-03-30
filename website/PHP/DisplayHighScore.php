<?php
	include 'config.php';
	
	$sql = "SELECT Username, HighScore FROM Users";
	$result = $conn->query($sql);
	$rang = 1;

	if ($result->num_rows > 0) {
	    // output data of each row
	    while($row = $result->fetch_assoc()) {
	        echo $rang . ". " . $row["Username"] . "\n" . "Score : " . $row["HighScore"] . "\n \n";
			$rang += 1;
	    }
	} else {
	    echo "0 results";
	}
	$conn->close();
	
?>