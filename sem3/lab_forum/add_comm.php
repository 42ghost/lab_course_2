<?php
	if (isset($_POST["comm"])){
		$comment = $_POST["comm"];
		$note_id = $_POST["note_id"];
	
		$con = mysqli_connect("localhost", 'root', "", "posts");
		$sql = "INSERT INTO comments (text, note_id) VALUES ('$comment', $note_id);";
		mysqli_query($con, $sql);
		
		header("Location: http://lab.local/index.php?page=".$_POST["page"]);	
	} else if (isset($_POST["subcomm"])){
		$comment = $_POST["subcomm"];
		$comment_id = $_POST["comment_id"];
	
		$con = mysqli_connect("localhost", 'root', "", "posts");
		$sql = "INSERT INTO sub_comments (text, comment_id) VALUES ('$comment', $comment_id);";
		mysqli_query($con, $sql);
		
		header("Location: http://lab.local/index.php?page=".$_POST["page"]);	
	}
?>
