<!DOCTYPE>

<html>
	<head>
		<title> Main page </title>
		<link rel="stylesheet" href="/includes/styles.css">
	</head>
	<body>
		<?php
			$user = "root";
			$database = "posts";
			$table = "posts";
			$text = $_POST['note'];
			
			if (!(isset($_POST['note'])) || strlen($text) == 0){
				header("Location: http://lab.local/index.php");
				die();			
			}
			
			try {
				$con = mysqli_connect("localhost", "root", "", "posts");			
				$allowed_types = array("image/jpeg", "image/jpg");
				if ($_FILES["image"]["error"] == 0)
				{
					$name = $_POST["id"] . '.jpg';
					copy($_FILES["image"]["tmp_name"], "images/".$name);
					
					$sql = "INSERT INTO `$table` (`text`, `picture`) VALUES ('$text', '1')";
					mysqli_query($con, $sql);
				}
				else
				{
					$sql = "INSERT INTO `$table` (`text`) VALUES ('$text')";
					mysqli_query($con, $sql);
				}
				header("Location: http://lab.local/index.php");
			} catch (PDOException $e) {
				print_r("Error!: " . $e->getMessage() . "<br/>");
				die();
			}
		?>
	</body>
</html>
