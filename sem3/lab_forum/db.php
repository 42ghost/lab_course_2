<?php

	$con = mysqli_connect("localhost", "root", "", "posts");
	if (!$con)
	{
		die("Connection failed: ".mysqli_connect_error());
	}
	
	mysqli_set_charset($con, "utf8");

	$sql = "SELECT * FROM posts ORDER BY time DESC";
	
	
	$info = mysqli_query($con, $sql);
	$notes_amnt = mysqli_num_rows($info);
	$note_list = mysqli_fetch_all($info, MYSQLI_ASSOC);
	
	mysqli_close($con);
?>
