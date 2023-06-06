<?php
	if ($_POST["reaction"] == 'like')
	{	
		$id = $_POST["id"];
		$sql = "UPDATE posts SET likes=".($_POST["amount"] + 1)." WHERE id=".$id;
	} else if ($_POST["reaction"] == 'dislike')
	{
		$id = $_POST["id"];
		$sql = "UPDATE posts SET dislikes=".($_POST["amount"] + 1)." WHERE id=".$id;
	} else if ($_POST["reaction"] == 'indifference')
	{
		$id = $_POST["id"];
		$sql = "UPDATE posts SET indifference=".($_POST["amount"] + 1)." WHERE id=".$id;
	}
	
	$con = mysqli_connect("localhost", "root", "", "posts");
	if (!$con)
	{
		die("Connection failed: ".mysqli_connect_error());
	}
	
	mysqli_query($con, $sql);
	mysqli_close($con);
	
	header("Location: index.php?page=".$_POST["page"]);
?>
