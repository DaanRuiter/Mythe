<?php
$servername = "localhost";
$username = "MobyleDick";
$password = "MOByleDICkPassWordForPHphiGHSCoreTable751";
$dbName = "DBMobyDick";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbName);

// Check connection
if ($conn->connect_error) 
{
    die("Connection failed: " . $conn->connect_error);
}

?>