<?php
	include 'config.php';
	
	$sql = "SELECT Username, HighScore FROM Users";
	$result = $conn->query($sql);

	if ($result->num_rows > 0) {
	    // output data of each row
	    while($row = $result->fetch_assoc()) {
	        echo "Username : " . $row["Username"]. "<br> Score : " . $row["HighScore"]. "<br><br>";
			
	    }
	} else {
	    echo "0 results";
	}
	$conn->close();
	
?>